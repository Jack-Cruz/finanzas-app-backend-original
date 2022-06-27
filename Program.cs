using finanzas_backend_app.Data;
using finanzas_backend_app.Services;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSqlite<EasyFinanzasContext>("Data Source=EasyFinanzas.db");
// Add the EasyFinanzas context
builder.Services.AddDbContext<EasyFinanzasContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BonistaService>();
builder.Services.AddScoped<BonoService>();
builder.Services.AddScoped<BonoResumenService>();
builder.Services.AddScoped<FlujoService>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options => {
    options.AddPolicy(MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

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


app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Add the createDbIfNotExists method call to the pipeline.
//app.CreateDbIfNotExists();

app.Run();
