using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using finanzas_backend_app.Models;

namespace finanzas_backend_app.Data 
{
    public class EasyFinanzasContext : DbContext
    {
        public EasyFinanzasContext(DbContextOptions<EasyFinanzasContext> options)
        : base(options) {}
        
        public DbSet<Bono> Bonos => Set<Bono>();
        public DbSet<Bonista> Bonistas => Set<Bonista>();
        public DbSet<BonoResumen> BonoResumenes => Set<BonoResumen>();
        public DbSet<Flujo> Flujos => Set<Flujo>();
    }
}