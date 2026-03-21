using Microsoft.EntityFrameworkCore;
using ProyectoSocioEconomico.Application.Interfaces;
using ProyectoSocioEconomico.Domain.Entities;
using ProyectoSocioEconomico.Infrastructure.Data;

namespace ProyectoSocioEconomico.Infrastructure.Services
{
    public class CasoService : ICasoService
    {
        private readonly AppDbContext _context;

        public CasoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Caso>> ObtenerTodos()
        {
            return await _context.Casos
                .Include(c => c.IdCategoriaNavigation)
                .Include(c => c.IdBeneficiadoNavigation)
                .ToListAsync();
        }

        public async Task Crear(Caso caso)
        {
            _context.Casos.Add(caso);
            await _context.SaveChangesAsync();
        }
    }
}