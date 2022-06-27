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
    
    public async Task<Bonista> GetById(int idbonista)
    {
        var bonista = await _context.Bonistas.FindAsync(idbonista); 
        if(bonista is null){
            throw new Exception("Bonista no encontrado");
        }
        return bonista;
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
    public async Task<Bonista> Delete(Bonista bonista)
    {
        _context.Bonistas.Remove(bonista);
        await _context.SaveChangesAsync();
        return bonista;
    }

    public async Task<Bonista> Validate(string username, string password)
    {
        var bonista = await _context.Bonistas.FirstOrDefaultAsync(b => b.usuario == username && b.contrasenia == password);
        if(bonista is null)
        {
            throw new Exception("Usuario o contraseña incorrectos");
        }
        return bonista;
    }
}