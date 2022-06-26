using finanzas_backend_app.Services;
using finanzas_backend_app.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace finanzas_backend_app.Controllers;

[ApiController]
[Route("[controller]")]
public class FLujoController : ControllerBase
{
    FlujoService _flujoService;

    public FLujoController(FlujoService flujoService)
    {
        _flujoService = flujoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flujo>>> GetAll()
    {
        return await _flujoService.GetAll();
    }
    [HttpGet]
    [Route("{idbono}")]
    public async Task<ActionResult<List<Flujo>>> GetFlujosByBono(int idbono){
        var flujos = await _flujoService.GetFlujosByBono(idbono);
        if(flujos is not null)
        {
            return flujos.ToList();
        }
        else{
            return NotFound();
        }
    }
}