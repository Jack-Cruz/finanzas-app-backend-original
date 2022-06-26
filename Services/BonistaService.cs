using finanzas_backend_app.Models;
using finanzas_backend_app.Data;
using Microsoft.EntityFrameworkCore;


namespace finanzas_backend_app.Services;

public class BonistaService
{
    private readonly EasyFinanzasContext _context;
    public BonistaService(EasyFinanzasContext context)
    {
        _context = context;
    }
    public async Task<List<Bonista>> GetAll()
    {
        return await _context.Bonistas.ToListAsync();
    }
    public async Task<Bonista> GetById(int id)
    {
        return await _context.Bonistas.FindAsync(id);
    }

    public async Task<Bonista> Create(Bonista bonista)
    {
        _context.Bonistas.Add(bonista);
        await _context.SaveChangesAsync();
        return bonista;
    }
    public async Task<Bonista> Update(Bonista bonista)
    {
        _context.Bonistas.Update(bonista);
        await _context.SaveChangesAsync();
        return bonista;
    }
    public async Task<Bonista> Delete(int id)
    {
        var bonista = await _context.Bonistas.FindAsync(id);
        _context.Bonistas.Remove(bonista);
        await _context.SaveChangesAsync();
        return bonista;
    }
}