using finanzas_backend_app.Services;
using finanzas_backend_app.Models;
using Microsoft.AspNetCore.Mvc;
using Excel.FinancialFunctions;
using System;

namespace finanzas_backend_app.Controllers;

[ApiController]
[Route("[controller]")]
public class BonoController : ControllerBase
{
    BonoService _bonoService;
    BonoResumenService _bonoResumenService;
    FlujoService _flujoService;
    BonistaService _bonistaService;


    public BonoController(BonoService bonoService, BonoResumenService bonoResumenService, FlujoService flujoService, BonistaService bonistaService)
    {
        _bonoService = bonoService;
        _bonoResumenService = bonoResumenService;
        _flujoService = flujoService;
        _bonistaService = bonistaService;
    }
    
    [HttpGet("{idbono}")]
    public async Task<ActionResult<Bono>> GetById(int idbono)
    {
        var bono = await _bonoService.GetById(idbono);
        if(bono is null){
            return NotFound();
        }
        return bono;
    }

    [HttpGet]
    [Route("getall/{idbonista}")]
    public async Task<ActionResult<List<Bono>>> GetBonosByBonista(int idbonista){
        var bonista = await _bonistaService.GetById(idbonista);
        if(bonista is null){
            return NotFound();
        }

        var bonos = await _bonoService.GetAllByBonista(idbonista);
        if(bonos is null)
        {
            return NotFound();
        }
        return bonos.ToList();
    }

    [HttpPost]
    [Route("{idbonista}")]
    public async Task<ActionResult<Bono>> AddBonoByBonista([FromBody] Bono bono,  int idbonista)
    {
        var bonista = await _bonistaService.GetById(idbonista);
        if(bonista is null){
            return NotFound("Bonista no encontrado");
        }

        bono.idbonista = idbonista;
        var newbono = await _bonoService.Create(bono);
        

        // Calcular el flujo de caja
        int n_periodos_anio = 360 / bono.frecpago;
        int n_total_periodos = (int)(n_periodos_anio * bono.anios);
        double tasa_efectiva_anual = 0.0f;

        if(bono.tipotasa is not null){
            if(bono.tipotasa == "efectiva")
            {
                tasa_efectiva_anual = bono.tasainteres;
            }
            else {
                int n = 360 / bono.capitalizacion;
                int m = 360 / bono.capitalizacion;

                tasa_efectiva_anual = tnominal_tefectiva(bono.tasainteres, n, m);
            }
        }
        Double tasa_efectiva_periodo = tefectiva1_tefectiva2(tasa_efectiva_anual, bono.frecpago, 360);
        Double COK_periodo = tefectiva1_tefectiva2(bono.tasadescuento, bono.frecpago, 360);
        Double costes_iniciales_emisor = (bono.percestructuracion + bono.perccolocacion + bono.percflotacion + bono.perccavali) * bono.valcomercial;
        Double costes_iniciales_bonista = (bono.percflotacion + bono.perccavali) * bono.valcomercial;

        // calcular el flujo
        int i = 1;
        List<Flujo> flujos = new List<Flujo>();
        Double saldo = bono.valnominal;

        // M??todo frances
        Double cuota = - bono.valnominal * (tasa_efectiva_periodo * Math.Pow(1 + tasa_efectiva_periodo, n_total_periodos)) / (Math.Pow(1 + tasa_efectiva_periodo, n_total_periodos) - 1);
        Double valorbono = bono.valnominal;
        Double flujo_emisor_inicial = bono.valcomercial - costes_iniciales_emisor;
        Double flujo_emisor_inicial_escudo = flujo_emisor_inicial;
        Double flujo_bonista1 = -costes_iniciales_bonista - bono.valcomercial;
        Double interes = 0.0f;
        Double amortizacion = 0.0f;
        Double escudo = 0.0f;
        Double prima = 0.0f;
        Double flujo_emisor = 0.0f;
        Double flujo_emisor_escudo = 0.0f;
        Double flujo_bonista = 0.0f;
        Double flujo_actual = 0.0f;
        Double fa_plazo = 0.0f;
        Double convexidad = 0.0f;
        
        Flujo flujo = new Flujo();
        flujo.idbono = bono.idbono;
        flujo.flujoemisor = bono.valcomercial - costes_iniciales_emisor;
        flujo.flujoemisorescudo = flujo.flujoemisor;
        flujo.flujobonista = -costes_iniciales_bonista - bono.valcomercial;
        await _flujoService.Create(flujo);

        flujos.Add(flujo);

        while(i < n_total_periodos + 1)
        {
            flujo = new Flujo();
            
            interes = - valorbono * tasa_efectiva_periodo;
            amortizacion = -cuota  + interes;
            escudo = -interes*bono.imprenta;
            prima = 0.0f;
            
            if (i == n_total_periodos)
            {
                prima = -bono.valnominal * bono.percprima;
            }

            flujo_emisor = cuota + prima;
            flujo_emisor_escudo = flujo_emisor + escudo;
            flujo_bonista = -flujo_emisor;
            flujo_actual = flujo_bonista / (Math.Pow(1 + COK_periodo, i));
            fa_plazo = flujo_actual * i * bono.frecpago / 360;
            convexidad = flujo_actual * i * (1 + i);

            flujo.n = i;
            flujo.bono = valorbono;
            flujo.interes = interes;
            flujo.cuota = cuota;
            flujo.amortizacion = amortizacion;
            flujo.prima = prima;
            flujo.escudo = escudo;
            flujo.flujoemisor = flujo_emisor;
            flujo.flujoemisorescudo = flujo_emisor_escudo;
            flujo.flujobonista = flujo_bonista;
            flujo.flujoactual = flujo_actual;
            flujo.faplazo = fa_plazo;
            flujo.convexidad = convexidad;
            flujo.idbono = bono.idbono;

            
            await _flujoService.Create(flujo); 
            flujos.Add(flujo);          

            valorbono = valorbono - amortizacion;
            i++;
        }


        // Bono resumen
        var newbonoresumen = new BonoResumen();
        
        List<Flujo> flujonocero = flujos.Where(x => x.n != 0).ToList();
        List<Double> flujobonista = flujonocero.Select(f => f.flujobonista).ToList();
        List<Double> flujofaplazo = flujonocero.Select(f => f.faplazo).ToList();
        List<Double> flujoactual = flujonocero.Select(f => f.flujoactual).ToList();
        List<Double> flujoconvexidad = flujonocero.Select(f => f.convexidad).ToList();
        List<Double> flujoemisorcompleted = flujos.Select(f => f.flujoemisor).ToList();
        List<Double> flujoemisorescudocompleted = flujos.Select(f => f.flujoemisorescudo).ToList();
        List<Double> flujobonistacompleted = flujos.Select(f => f.flujobonista).ToList();
        

        Double van = Financial.Npv(COK_periodo, flujobonista);
        Double tiremisor = Financial.Irr(flujoemisorcompleted, 0.001);
        Double tiremisorescudo = Financial.Irr(flujoemisorescudocompleted);
        Double tirbonista = Financial.Irr(flujobonistacompleted);

        Console.WriteLine("tiremisor: " + tiremisor);

        newbonoresumen.idbono = bono.idbono;
        newbonoresumen.precio = van;
        newbonoresumen.utilidad_perdida = van + flujo_bonista1;
        newbonoresumen.duracion = flujonocero.Count();
        newbonoresumen.convexidad = flujoconvexidad.Sum() / (Math.Pow(1+COK_periodo, 2) * flujoactual.Sum()*Math.Pow(360/bono.frecpago, 2));
        newbonoresumen.total = newbonoresumen.duracion + newbonoresumen.convexidad;
        newbonoresumen.duracionmod = newbonoresumen.duracion / (1 + COK_periodo);
        newbonoresumen.TCEAemisor = Math.Pow(tiremisor + 1, 360 / bono.frecpago) - 1;
        newbonoresumen.TCEAemisorescudo = Math.Pow(tiremisorescudo + 1, 360 / bono.frecpago) - 1;
        newbonoresumen.TREAbonista = Math.Pow(tirbonista + 1, 360 / bono.frecpago) - 1;
        newbonoresumen.tirbonista = tirbonista;
        newbonoresumen.moneda = bono.moneda;

        await _bonoResumenService.Create(newbonoresumen);

        if(newbono is null)
        {
            return NotFound("No se ha podido crear el bono");
        }
        
        return newbono;
    }

    [HttpPut]
    [Route("{idbonista}/{idbono}")]
    public async Task<ActionResult<Bono>> UpdateBonoByBonista([FromBody] Bono bono, int idbono, int idbonista)
    {
        bono.idbono = idbono;
        bono.idbonista = idbonista;
        var newbono = await _bonoService.Update(bono);

        await _flujoService.DeleteByBono(idbono);

        // Calcular el flujo de caja
        int n_periodos_anio = 360 / bono.frecpago;
        int n_total_periodos = (int)(n_periodos_anio * bono.anios);
        double tasa_efectiva_anual = 0.0f;

        if(bono.tipotasa is not null){
            if(bono.tipotasa == "efectiva")
            {
                tasa_efectiva_anual = bono.tasainteres;
            }
            else {
                int n = 360 / bono.capitalizacion;
                int m = 360 / bono.capitalizacion;

                tasa_efectiva_anual = tnominal_tefectiva(bono.tasainteres, n, m);
            }
        }
        Double tasa_efectiva_periodo = tefectiva1_tefectiva2(tasa_efectiva_anual, bono.frecpago, 360);
        Double COK_periodo = tefectiva1_tefectiva2(bono.tasadescuento, bono.frecpago, 360);
        Double costes_iniciales_emisor = (bono.percestructuracion + bono.perccolocacion + bono.percflotacion + bono.perccavali) * bono.valcomercial;
        Double costes_iniciales_bonista = (bono.percflotacion + bono.perccavali) * bono.valcomercial;

        // calcular el flujo
        int i = 1;
        List<Flujo> flujos = new List<Flujo>();
        Double saldo = bono.valnominal;

        // M??todo frances
        Double cuota = - bono.valnominal * (tasa_efectiva_periodo * Math.Pow(1 + tasa_efectiva_periodo, n_total_periodos)) / (Math.Pow(1 + tasa_efectiva_periodo, n_total_periodos) - 1);
        Double valorbono = bono.valnominal;
        Double flujo_emisor_inicial = bono.valcomercial - costes_iniciales_emisor;
        Double flujo_emisor_inicial_escudo = flujo_emisor_inicial;
        Double flujo_bonista1 = -costes_iniciales_bonista - bono.valcomercial;
        Double interes = 0.0f;
        Double amortizacion = 0.0f;
        Double escudo = 0.0f;
        Double prima = 0.0f;
        Double flujo_emisor = 0.0f;
        Double flujo_emisor_escudo = 0.0f;
        Double flujo_bonista = 0.0f;
        Double flujo_actual = 0.0f;
        Double fa_plazo = 0.0f;
        Double convexidad = 0.0f;
        
        Flujo flujo = new Flujo();
        flujo.idbono = bono.idbono;
        flujo.flujoemisor = bono.valcomercial - costes_iniciales_emisor;
        flujo.flujoemisorescudo = flujo.flujoemisor;
        flujo.flujobonista = -costes_iniciales_bonista - bono.valcomercial;
        await _flujoService.Create(flujo);

        flujos.Add(flujo);

        while(i < n_total_periodos + 1)
        {
            flujo = new Flujo();
            
            interes = - valorbono * tasa_efectiva_periodo;
            amortizacion = -cuota  + interes;
            escudo = -interes*bono.imprenta;
            prima = 0.0f;
            
            if (i == n_total_periodos)
            {
                prima = -bono.valnominal * bono.percprima;
            }

            flujo_emisor = cuota + prima;
            flujo_emisor_escudo = flujo_emisor + escudo;
            flujo_bonista = -flujo_emisor;
            flujo_actual = flujo_bonista / (Math.Pow(1 + COK_periodo, i));
            fa_plazo = flujo_actual * i * bono.frecpago / 360;
            convexidad = flujo_actual * i * (1 + i);

            flujo.n = i;
            flujo.bono = valorbono;
            flujo.interes = interes;
            flujo.cuota = cuota;
            flujo.amortizacion = amortizacion;
            flujo.prima = prima;
            flujo.escudo = escudo;
            flujo.flujoemisor = flujo_emisor;
            flujo.flujoemisorescudo = flujo_emisor_escudo;
            flujo.flujobonista = flujo_bonista;
            flujo.flujoactual = flujo_actual;
            flujo.faplazo = fa_plazo;
            flujo.convexidad = convexidad;
            flujo.idbono = bono.idbono;

            
            await _flujoService.Create(flujo); 
            flujos.Add(flujo);          

            valorbono = valorbono - amortizacion;
            i++;
        }


        // Bono resumen
        var newbonoresumen = await _bonoResumenService.GetByBono(idbono);
        
        List<Flujo> flujonocero = flujos.Where(x => x.n != 0).ToList();
        List<Double> flujobonista = flujonocero.Select(f => f.flujobonista).ToList();
        List<Double> flujofaplazo = flujonocero.Select(f => f.faplazo).ToList();
        List<Double> flujoactual = flujonocero.Select(f => f.flujoactual).ToList();
        List<Double> flujoconvexidad = flujonocero.Select(f => f.convexidad).ToList();
        List<Double> flujoemisorcompleted = flujos.Select(f => f.flujoemisor).ToList();
        List<Double> flujoemisorescudocompleted = flujos.Select(f => f.flujoemisorescudo).ToList();
        List<Double> flujobonistacompleted = flujos.Select(f => f.flujobonista).ToList();
        

        Double van = Financial.Npv(COK_periodo, flujobonista);
        Double tiremisor = Financial.Irr(flujoemisorcompleted, 0.001);
        Double tiremisorescudo = Financial.Irr(flujoemisorescudocompleted);
        Double tirbonista = Financial.Irr(flujobonistacompleted);

        newbonoresumen.idbono = bono.idbono;
        newbonoresumen.precio = van;
        newbonoresumen.utilidad_perdida = van + flujo_bonista1;
        newbonoresumen.duracion = flujonocero.Count();
        newbonoresumen.convexidad = flujoconvexidad.Sum() / (Math.Pow(1+COK_periodo, 2) * flujoactual.Sum()*Math.Pow(360/bono.frecpago, 2));
        newbonoresumen.total = newbonoresumen.duracion + newbonoresumen.convexidad;
        newbonoresumen.duracionmod = newbonoresumen.duracion / (1 + COK_periodo);
        newbonoresumen.TCEAemisor = Math.Pow(tiremisor + 1, 360 / bono.frecpago) - 1;
        newbonoresumen.TCEAemisorescudo = Math.Pow(tiremisorescudo + 1, 360 / bono.frecpago) - 1;
        newbonoresumen.TREAbonista = Math.Pow(tirbonista + 1, 360 / bono.frecpago) - 1;
        
        await _bonoResumenService.Update(newbonoresumen);

        if(newbono is null)
        {
            return NotFound("No se ha podido crear el bono");
        }
        
        return CreatedAtAction("GetById", new {idbono = idbonista}, newbono);



        // if(bonista is null){
        //     return NotFound("Bonista not found");
        // }

        // var oldbono = await _bonoService.GetById(idbono);
        // if(oldbono is null)
        // {
        //     return NotFound("Bono not found");
        // }

        // var bonos = await _bonoService.GetAllByBonista(idbonista);
        // var hasbono = await _bonoService.hasBono(idbono, idbonista);
        
        // if(hasbono == false){
        //     return NotFound("No tienes permiso para editar este bono");
        // }
        // bono.idbonista = idbonista;
        // await _bonoService.Update(bono);

    }

    [HttpDelete]
    [Route("{idbonista}/{idbono}")]
    public async Task<IActionResult> DeleteBonoByBonista(int idbonista, int idbono)
    {
        var bonista = await _bonistaService.GetById(idbonista);
        if(bonista is null){
            return NotFound("Bonista not found");
        }

        var deletebono = await _bonoService.GetById(idbono);
        if(deletebono is null)
        {
            return NotFound("Bono not found");
        }
        
        await _bonoService.Delete(deletebono);
        await _flujoService.DeleteByBono(idbono);
        await _bonoResumenService.Delete(idbono);
        return CreatedAtAction("GetById", new {idbono = idbonista}, deletebono);
    }

    // helper functions
    private Double tnominal_tefectiva(Double tnominal, int n, int m) 
    {
        return Math.Pow((1 + tnominal / m),  n) - 1;
    }

    private Double tefectiva1_tefectiva2(Double tefectiva, int n2, int n1)
    {
        return Math.Pow((1+tefectiva), n2/n1) - 1;
    }    

}