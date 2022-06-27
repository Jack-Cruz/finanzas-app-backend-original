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

    public async Task<Bono> GetById(int idbono)
    {
        var bono = await _context.Bonos.FindAsync(idbono);
        if(bono is null){
            throw new Exception("Bono no encontrado");
        }
        return bono;
    }
    public async Task<List<Bono>> GetAllByBonista(int idbonista)
    {
        List<Bono> listabonos = await _context.Bonos.Where(b => b.idbonista == idbonista).ToListAsync();
        
        return listabonos;
    }
    public async Task<Bono> Create(Bono bono)
    {
        _context.Bonos.Add(bono);
        await _context.SaveChangesAsync();
        return bono;
    }
    public async Task<Bono> Update(Bono bono)
    {
        _context.Bonos.Update(bono);
        await _context.SaveChangesAsync();
        return bono;
    }
    public async Task<Bono> Delete(Bono bono)
    {
        _context.Bonos.Remove(bono);
        await _context.SaveChangesAsync();
        return bono;
    }
    public async Task<bool> hasBono(int idbono, int idbonista)
    {
        var bono = await _context.Bonos.FindAsync(idbono);
        if(bono is null){
            throw new Exception("Bono no encontrado");
        }
        if(bono.idbonista == idbonista){
            return true;
        }
        return false;
    }
}