using Microsoft.EntityFrameworkCore;
using ProyectoSocioEconomico.Application.Services;
using ProyectoSocioEconomico.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

// Registrar DbContext (conexión a SQL Server)
builder.Services.AddDbContext<ProyectoSocioEconomicoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios para Dependency Injection
builder.Services.AddScoped<AuthService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();