using finanzas_backend_app.Data;

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        using (var scope = host.Services.CreateAsyncScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<EasyFinanzasContext>();
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }
    }
}