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
    public async Task<List<Flujo>> GetAll()
    {
        return await _context.Flujos.ToListAsync();
    }
    
    public async Task<Flujo> Create(Flujo flujo)
    {
        _context.Flujos.Add(flujo);
        await _context.SaveChangesAsync();
        return flujo;
    }
    public async Task<Flujo> Update(int idflujo, Flujo flujo)
    {
        var flujoActual = await _context.Flujos.FindAsync(idflujo);
        if(flujoActual is null)
        {
            throw new Exception("Flujo no encontrado");
        }
        _context.Flujos.Update(flujo);
        await _context.SaveChangesAsync();
        return flujo;
    }
    public async Task<Flujo> Delete(int id)
    {
        var flujo = await _context.Flujos.FindAsync(id);
        _context.Flujos.Remove(flujo);
        await _context.SaveChangesAsync();
        return flujo;
    }

    public async Task AddFlujosByBono(int idbono, int idflujo)
    {
        var bono = await _context.Bonos.FindAsync(idbono);
        var flujo = await _context.Flujos.FindAsync(idflujo);
        if(bono is null || flujo is null)
        {
            throw new Exception("Bono o Flujo no encontrado");
        }
        // bono.flujos.Add(flujo);
        await _context.SaveChangesAsync();
    }
       
    public async Task<List<Flujo>> GetFlujosByBono(int idbono)
    {
        List<Flujo> listaflujos = _context.Flujos.Where(f => f.idbono == idbono).ToList();

        return listaflujos;
    }
    
    public async Task RemoveFlujosByBono(int bono, int idflujo)
    {
        var bonoActual = await _context.Bonos.FindAsync(bono);
        var flujoActual = await _context.Flujos.FindAsync(idflujo);
        if(bonoActual is null || flujoActual is null)
        {
            throw new Exception("Bono o Flujo no encontrado");
        }
        // bonoActual.flujos.Remove(flujoActual);
    }

}