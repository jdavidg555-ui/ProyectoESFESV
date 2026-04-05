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
        private readonly AppDbContext _context;

        public ProgramaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Programa>> ObtenerTodosConCasosAsync()
        {
            return await _context.Programas
                .Include(p => p.IdCasos)
                    .ThenInclude(c => c.Donaciones)
                .ToListAsync();
        }

        public async Task<Programa?> ObtenerPorIdConDetallesAsync(int id)
        {
            return await _context.Programas
                .Include(p => p.IdCasos)
                    .ThenInclude(c => c.Donaciones)
                .Include(p => p.IdCasos)
                    .ThenInclude(c => c.IdCategoriaNavigation)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
