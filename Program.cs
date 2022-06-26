using finanzas_backend_app.Data;
using finanzas_backend_app.Services;

var builder = WebApplication.CreateBuilder(args);

// Add the EasyFinanzas context
builder.Services.AddSqlite<EasyFinanzasContext>("Data Source=EasyFinanzas.db");
// builder.Services.AddDbContext<EasyFinanzasContext>(options => options.UseSqlServer("Server = Desktop-Jack; Database = LetSkoleDb2; Integrated Security = true;"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BonistaService>();
builder.Services.AddScoped<BonoService>();
builder.Services.AddScoped<BonoResumenService>();
builder.Services.AddScoped<FlujoService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Add the createDbIfNotExists method call to the pipeline.
app.CreateDbIfNotExists();

app.Run();
