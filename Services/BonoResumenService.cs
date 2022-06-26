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
    public async Task<List<BonoResumen>> GetAll()
    {
        return await _context.BonoResumenes.ToListAsync();
    }
    public async Task<BonoResumen> GetById(int id)
    {
        return await _context.BonoResumenes.FindAsync(id);
    }
    public async Task<BonoResumen> Create(BonoResumen bonoResumen)
    {
        _context.BonoResumenes.Add(bonoResumen);
        await _context.SaveChangesAsync();
        return bonoResumen;
    }
    public async Task<BonoResumen> Update(int idbonoResumen, BonoResumen bonoResumen)
    {
        var bonoResumenActual = await _context.BonoResumenes.FindAsync(idbonoResumen);
        if(bonoResumenActual is null)
        {
            throw new Exception("BonoResumen no encontrado");
        }
        _context.BonoResumenes.Update(bonoResumen);
        await _context.SaveChangesAsync();
        return bonoResumen;
    }
    public async Task<BonoResumen> Delete(int id)
    {
        var bonoResumen = await _context.BonoResumenes.FindAsync(id);
        _context.BonoResumenes.Remove(bonoResumen);
        await _context.SaveChangesAsync();
        return bonoResumen;
    }
}