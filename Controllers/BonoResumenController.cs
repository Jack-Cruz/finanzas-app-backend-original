using finanzas_backend_app.Services;
using finanzas_backend_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace finanzas_backend_app.Controllers;

[ApiController]
[Route("[controller]")]
public class BonoResumenController : ControllerBase
{
    BonoResumenService _bonoResumenService;

    public BonoResumenController(BonoResumenService bonoResumenService)
    {
        _bonoResumenService = bonoResumenService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BonoResumen>>> GetAll()
    {
        return await _bonoResumenService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BonoResumen>> GetById(int id)
    {
        var bonoResumen = await _bonoResumenService.GetById(id);
        if(bonoResumen is not null){
            return bonoResumen;
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