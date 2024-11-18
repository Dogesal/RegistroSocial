using System;
using Capa_Datos;
using Capa_Negocio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar los servicios de sesión
builder.Services.AddDistributedMemoryCache();  // Para almacenar la sesión en memoria
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tiempo de expiración de la sesión
    options.Cookie.HttpOnly = true; // Seguridad
    options.Cookie.IsEssential = true; // Esencial para que funcione incluso con restricciones de cookies
});

// Configurar el contexto de base de datos
builder.Services.AddDbContext<ServicioContextDAL>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cn"))
);
builder.Services.AddScoped<ServiciosBL>();
// Configure the HTTP request pipeline.
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es 30 días. Puedes cambiarlo para escenarios de producción.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Habilitar el middleware de sesión
app.UseSession();

// Configurar el enrutamiento de las solicitudes HTTP
app.UseRouting();

// Habilitar la autorización (si la usas)
app.UseAuthorization();

// Configurar la ruta predeterminada del controlador
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run();
