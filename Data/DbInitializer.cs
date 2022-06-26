using finanzas_backend_app.Models;

namespace finanzas_backend_app.Data
{
    public static class DbInitializer
    {
        public static async void Initialize(EasyFinanzasContext context)
        {
            context.Database.EnsureCreated();
            if (context.Bonistas.Any())
            {
                return; //DB has been seeded
            }
            var userDefault = new Bonista {
                nombre = "",
                apellido = "",
                DNI = "",
                correo = "",
                celular = "",
                usuario = "",
                contrasenia = "",
                RUC = "",
                direccion = "",
                region = "",
                provincia = "",
                distrito = ""
            };
            
            context.Bonistas.Add(userDefault);
            await context.SaveChangesAsync();
        }
    }
}