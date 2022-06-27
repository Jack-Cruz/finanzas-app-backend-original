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

    [HttpGet("{id}")]
    public async Task<ActionResult<Bonista>> GetById(int id)
    {
        var bonista = await _bonistaService.GetById(id);
        if(bonista is null){
            return NotFound();
        }
        return bonista;
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
        if(bonistaActual is null){
            return NotFound();
        }

        bonista.idbonista = idbonista;
        await _bonistaService.Update(bonista);
        return CreatedAtAction("GetById", new {id = bonista!.idbonista}, bonista);
    }

    [HttpGet("credential/{username}/{password}")]
    public async Task<IActionResult> Credential(string username, string password)
    {
        var bonista = await _bonistaService.Validate(username, password);
        if(bonista is null){
            return BadRequest();
        }
        
        return CreatedAtAction("GetById", new {id = bonista!.idbonista}, bonista);
    }
    
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> Delete(int id)
//     {
//         var bonista = await _bonistaService.GetById(id);
//         if(bonista is null)
//         {
//             return NotFound();
//         }
        
//         await _bonistaService.Delete(bonista);
//     }
}