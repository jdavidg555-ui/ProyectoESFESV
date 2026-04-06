using Microsoft.EntityFrameworkCore;
using ProyectoSocioEconomico.Application.Interfaces;
using ProyectoSocioEconomico.Domain.Entities;
using ProyectoSocioEconomico.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdCasos)
                    .ThenInclude(c => c.Donaciones)
                .ToListAsync();
        }

        public async Task<Programa?> ObtenerPorIdConDetallesAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Programas
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdCasos)
                    .ThenInclude(c => c.Donaciones)
                .Include(p => p.IdCasos)
                    .ThenInclude(c => c.IdCategoriaNavigation)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CrearAsync(Programa programa)
        {
            ArgumentNullException.ThrowIfNull(programa);

            using var context = await _contextFactory.CreateDbContextAsync();
            context.Programas.Add(programa);
            await context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var programa = await context.Programas
                .Include(p => p.IdCasos)
                .Include(p => p.InscripcionesVoluntarios)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (programa is null)
            {
                return;
            }

            if (programa.IdCasos.Any())
            {
                programa.IdCasos.Clear();
            }

            if (programa.InscripcionesVoluntarios.Any())
            {
                context.InscripcionesVoluntarios.RemoveRange(programa.InscripcionesVoluntarios);
            }

            context.Programas.Remove(programa);
            await context.SaveChangesAsync();
        }
    }
}
