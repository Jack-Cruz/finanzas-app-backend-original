using finanzas_backend_app.Models;
using finanzas_backend_app.Data;
using Microsoft.EntityFrameworkCore;


namespace finanzas_backend_app.Services;

public class BonoResumenService {
    private readonly EasyFinanzasContext _context;
    public BonoResumenService(EasyFinanzasContext context)
    {
        _context = context;
    }
    
    public async Task<BonoResumen> GetByBono(int idbono)
    {
        var bonoresumen =  await _context.BonoResumenes.SingleOrDefaultAsync(b => b.idbono == idbono);
        if(bonoresumen is null){
            throw new Exception("Bono no encontrado");
        }
        return bonoresumen;
    }
    
    public async Task<List<BonoResumen>> GetAll()
    {
        var bonoresumen = await _context.BonoResumenes.ToListAsync();
        return bonoresumen;
    }
    public async Task<BonoResumen> Create(BonoResumen bonoResumen)
    {
        _context.BonoResumenes.Add(bonoResumen);
        await _context.SaveChangesAsync();
        return bonoResumen;
    }
    public async Task<BonoResumen> Update(BonoResumen bonoResumen)
    {
        _context.BonoResumenes.Update(bonoResumen);
        await _context.SaveChangesAsync();
        return bonoResumen;
    }
    public async Task<BonoResumen> Delete(int idbono)
    {
        var bonoresumen =  await _context.BonoResumenes.SingleOrDefaultAsync(b => b.idbono == idbono);
        if(bonoresumen is null){
            throw new Exception("Bono no encontrado");
        }
        _context.BonoResumenes.Remove(bonoresumen);
        await _context.SaveChangesAsync();
        return bonoresumen;
    }
}