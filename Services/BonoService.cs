using finanzas_backend_app.Models;
using finanzas_backend_app.Data;
using Microsoft.EntityFrameworkCore;


namespace finanzas_backend_app.Services;

public class BonoService {
    private readonly EasyFinanzasContext _context;
    public BonoService(EasyFinanzasContext context)
    {
        _context = context;
    }

    public async Task<List<Bono>> GetAll()
    {
        return await _context.Bonos.ToListAsync();
    }
    public async Task<Bono> GetById(int id)
    {
        return await _context.Bonos.FindAsync(id);
    }
    public async Task<Bono> Create(int idbonista, Bono bono)
    {
        bono.idbonista = idbonista;

        _context.Bonos.Add(bono);
        await _context.SaveChangesAsync();
        return bono;
    }
    public async Task<Bono> Update(int idbono, Bono bono)
    {
        var bonoActual = await _context.Bonos.FindAsync(idbono);
        if(bonoActual is null)
        {
            throw new Exception("Bono no encontrado");
        }
        _context.Bonos.Update(bono);
        await _context.SaveChangesAsync();
        return bono;
    }
    public async Task<Bono> Delete(int id)
    {
        var bono = await _context.Bonos.FindAsync(id);
        _context.Bonos.Remove(bono);
        await _context.SaveChangesAsync();
        return bono;
    }
    // public async Task AddBonosByBonista(int idbonista, int idbono)
    // {
    //     var bonista = await _context.Bonistas.FindAsync(idbonista);
    //     var bono = await _context.Bonos.FindAsync(idbono);

    //     await _context.SaveChangesAsync();
    // }
    
    public async Task<List<Bono>> GetBonosByBonista(int idbonista)
    {
        
        List<Bono> listabonos = _context.Bonos.Where(b => b.idbonista == idbonista).ToList();

        return listabonos;
    }
    
    public async Task RemoveBonosByBonista(int idbonista, int idbono)
    {
        var bonista = await _context.Bonistas.FindAsync(idbonista);
        var bono = await _context.Bonos.FindAsync(idbono);

        if( bonista is null || bono is null)
        {
            throw new Exception("Bonista o Bono no encontrado");
        }
        
        await _context.SaveChangesAsync();
    }
}