using System;
using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar los servicios de sesi�n
builder.Services.AddDistributedMemoryCache();  // Para almacenar la sesi�n en memoria
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tiempo de expiraci�n de la sesi�n
    options.Cookie.HttpOnly = true; // Seguridad
    options.Cookie.IsEssential = true; // Esencial para que funcione incluso con restricciones de cookies
});

//INICIO CONTEXTOS DE DATOS

// Configurar el contexto de base de datos
builder.Services.AddDbContext<ServicioContextDAL>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cn"))
);


builder.Services.AddDbContext<EstadoContextDAL>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cn"))
);

builder.Services.AddScoped<EstadoBL>();
builder.Services.AddScoped<ServiciosBL>();
builder.Services.AddScoped<RegistroSocialDAL>();
builder.Services.AddScoped<RegistroSocialBL>();

//FIN CONTEXTOS DE DATOS


// Configure the HTTP request pipeline.
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es 30 d�as. Puedes cambiarlo para escenarios de producci�n.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Habilitar el middleware de sesi�n
app.UseSession();

// Configurar el enrutamiento de las solicitudes HTTP
app.UseRouting();

// Habilitar la autorizaci�n 
app.UseAuthorization();

// Configurar la ruta predeterminada del controlador
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run();
