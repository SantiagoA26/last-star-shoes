using Microsoft.EntityFrameworkCore;
using LastStarShoesAPI.Models;
using LastStarShoesAPI.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



// 1. Configuración de cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<ICompraService, CompraService>();

// 2. Controladores con manejo de ciclos (ACTUALIZADO)
builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Conexión a Base de Datos
builder.Services.AddDbContext<LaststarShoesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");



app.UseAuthorization();

app.MapControllers();

app.Run();