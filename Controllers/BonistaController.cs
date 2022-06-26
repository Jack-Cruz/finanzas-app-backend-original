using finanzas_backend_app.Services;
using finanzas_backend_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace finanzas_backend_app.Controllers;

[ApiController]
[Route("[controller]")]
public class BonistaController : ControllerBase
{
    BonistaService _bonistaService;

    public BonistaController(BonistaService bonistaService)
    {
        _bonistaService = bonistaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bonista>>> GetAll()
    {
        return await _bonistaService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bonista>> GetById(int id)
    {
        var bonista = await _bonistaService.GetById(id);
        if(bonista is not null){
            return bonista;
        }
        else{
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(Bonista newBonista)
    {
        var bonista = await _bonistaService.Create(newBonista);
        return CreatedAtAction("GetById", new {id = bonista!.idbonista}, bonista);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int idbonista, Bonista bonista)
    {
        var bonistaActual = await _bonistaService.GetById(idbonista);
        if(bonistaActual is not null){
            bonista.idbonista = idbonista;
            await _bonistaService.Update(bonista);
            return NoContent();
        }
        else{
            return NotFound();
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var bonista = await _bonistaService.GetById(id);
        if(bonista is not null){
            await _bonistaService.Delete(id);
            return NoContent();
        }
        else{
            return NotFound();
        }
    }

}