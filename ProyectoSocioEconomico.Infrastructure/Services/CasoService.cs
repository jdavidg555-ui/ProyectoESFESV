using Microsoft.EntityFrameworkCore;
using ProyectoSocioEconomico.Application.Interfaces;
using ProyectoSocioEconomico.Domain.Entities;
using ProyectoSocioEconomico.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSocioEconomico.Infrastructure.Services
{
    public class CasoService : ICasoService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public CasoService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Caso>> ObtenerTodos()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Casos
                .Include(c => c.IdCategoriaNavigation)
                .Include(c => c.IdBeneficiadoNavigation)
                .ToListAsync();
        }

        public async Task<List<Caso>> ObtenerTodosConDetallesAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Casos
                .Include(c => c.IdCategoriaNavigation)
                .Include(c => c.IdBeneficiadoNavigation)
                .Include(c => c.Donaciones)
                .ToListAsync();
        }

        public async Task<List<Caso>> ObtenerActivosParaHome(int cantidad)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Casos
                .Include(c => c.Donaciones)
                .Where(c => c.Estado == "Activo")
                .OrderByDescending(c => c.FechaCreacion)
                .Take(cantidad)
                .ToListAsync();
        }

        public async Task<Caso?> ObtenerPorIdConDetallesAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Casos
                .Include(c => c.IdCategoriaNavigation)
                .Include(c => c.IdBeneficiadoNavigation)
                .Include(c => c.Donaciones)
                    .ThenInclude(d => d.IdDonadorNavigation)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Crear(Caso caso)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.Casos.Add(caso);
            await context.SaveChangesAsync();
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Categorias.ToListAsync();
        }
    }
}
