using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using finanzas_backend_app.Models;

namespace finanzas_backend_app.Data 
{
    public class EasyFinanzasContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public EasyFinanzasContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }
        
        public DbSet<Bono> Bonos => Set<Bono>();
        public DbSet<Bonista> Bonistas => Set<Bonista>();
        public DbSet<BonoResumen> BonoResumenes => Set<BonoResumen>();
        public DbSet<Flujo> Flujos => Set<Flujo>();
    }
}