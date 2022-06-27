using finanzas_backend_app.Services;
using finanzas_backend_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace finanzas_backend_app.Controllers;

[ApiController]
[Route("[controller]")]
public class BonoResumenController : ControllerBase
{
    BonoResumenService _bonoResumenService;
    BonoService _bonoService;

    public BonoResumenController(BonoResumenService bonoResumenService, BonoService bonoService)
    {
        _bonoResumenService = bonoResumenService;
        _bonoService = bonoService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BonoResumen>> GetById(int id)
    {
        var bonoResumen = await _bonoResumenService.GetByBono(id);
        if(bonoResumen is not null){
            return bonoResumen;
        }
        else{
            return NotFound();
        }
    }
    
    [HttpGet("idbonista/{idbonista}")]
    public async Task<ActionResult<List<BonoResumen>>> GetByUserId(int idbonista){
        var bonos = await _bonoService.GetAllByBonista(idbonista);
        var bonosResumenes = await _bonoResumenService.GetAll();

        var query = from bono in bonos
                    join bonoResumen in bonosResumenes
                    on bono.idbono equals bonoResumen.idbono
                    select bonoResumen;

        // List<BonoResumen> bonosresumen = new List<BonoResumen>();
        // bonosresumen = bonos.ForEach(x => bonosresumen = await _bonoResumenService.GetByBono(x.idbono)).ToList();
        // bonosresumen = bonoresumenService

        // var bonoResumen = await _bonoResumenService.(iduser);
        if(query is not null){
            return query.ToList();
        }
        else{
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(BonoResumen newBonoResumen)
    {
        var bonoResumen = await _bonoResumenService.Create(newBonoResumen);
        return CreatedAtAction("GetById", new {id = bonoResumen!.idresumen}, bonoResumen);
    }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> Update(int idbonoResumen, BonoResumen bonoResumen)
    // {
    //     var bonoResumenActual = await _bonoResumenService.GetById(idbonoResumen);
    //     if(bonoResumenActual is not null){
    //         bonoResumen.idbonoResumen = idbonoResumen;
    //         await _bonoResumenService.Update(bonoResumen);
    //         return NoContent();
    //     }
    //     else{
    //         return NotFound();
    //     }
    // }
}