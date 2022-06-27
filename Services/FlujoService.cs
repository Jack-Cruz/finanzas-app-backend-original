using finanzas_backend_app.Models;
using finanzas_backend_app.Data;
using Microsoft.EntityFrameworkCore;

namespace finanzas_backend_app.Services;

public class FlujoService {
    private readonly EasyFinanzasContext _context;
    public FlujoService(EasyFinanzasContext context)
    {
        _context = context;
    }
        
    public async Task<List<Flujo>> GetFlujosByBono(int idbono)
    {
        List<Flujo> listaflujos = await _context.Flujos.Where(f => f.idbono == idbono).ToListAsync();

        return listaflujos;
    }
    public async Task<Flujo> Create(Flujo flujo)
    {
        _context.Flujos.Add(flujo);
        await _context.SaveChangesAsync();
        return flujo;
    }
    public async Task<Flujo> Update(Flujo flujo)
    {
        _context.Flujos.Update(flujo);
        await _context.SaveChangesAsync();
        return flujo;
    }
    public async Task<Flujo> Delete(Flujo flujo)
    {
        _context.Flujos.Remove(flujo);
        await _context.SaveChangesAsync();
        return flujo;
    }
    public async Task DeleteByBono(int idbono)
    {
        var flujos = await GetFlujosByBono(idbono);
        flujos.ForEach(flujo => _context.Flujos.Remove(flujo));
        await _context.SaveChangesAsync();
    }
}