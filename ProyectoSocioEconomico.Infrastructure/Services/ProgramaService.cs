using Microsoft.EntityFrameworkCore;
using ProyectoSocioEconomico.Application.Interfaces;
using ProyectoSocioEconomico.Domain.Entities;
using ProyectoSocioEconomico.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoSocioEconomico.Infrastructure.Services
{
    public class ProgramaService : IProgramaService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ProgramaService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Programa>> ObtenerTodosConCasosAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Programas
                .Include(p => p.IdCasos)
                    .ThenInclude(c => c.Donaciones)
                .ToListAsync();
        }

        public async Task<Programa?> ObtenerPorIdConDetallesAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Programas
                .Include(p => p.IdCasos)
                    .ThenInclude(c => c.Donaciones)
                .Include(p => p.IdCasos)
                    .ThenInclude(c => c.IdCategoriaNavigation)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
