using Lab04_WillianKana.Data;
using Lab04_WillianKana.Interfaces.Repositories;
using Lab04_WillianKana.Interfaces.Services;
using Lab04_WillianKana.Repositories;
using Lab04_WillianKana.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//agregar Repositorios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//agregar servicios
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IOrdeneService, OrdeneService>();
builder.Services.AddScoped<IPagoService, PagoService>();
// servicios con un servicio base
builder.Services.AddScoped<IDetallesordenService, DetallesodenService>();
builder.Services.AddScoped<IProductoService, ProductoService>();

// Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Agregar DbContext con PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// instalacion swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
    // uso de swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = string.Empty; // ← Esto hace que Swagger esté en "/"
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//necesario para swagger
app.MapControllers();

app.Run();