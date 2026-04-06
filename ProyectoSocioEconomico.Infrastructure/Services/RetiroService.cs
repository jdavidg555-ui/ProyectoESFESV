using Microsoft.EntityFrameworkCore;
using ProyectoSocioEconomico.Application.Interfaces;
using ProyectoSocioEconomico.Domain.Entities;
using ProyectoSocioEconomico.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSocioEconomico.Infrastructure.Services
{
    public class RetiroService : IRetiroService
    {
        private readonly AppDbContext _context;

        public RetiroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Retiro>> ObtenerPorBeneficiadoIdAsync(int beneficiadoId)
        {
            return await _context.Retiros
                .Where(r => r.IdBeneficiado == beneficiadoId)
                .OrderByDescending(r => r.FechaSolicitud)
                .ToListAsync();
        }

        public async Task<decimal> ObtenerTotalRetiradoPorCasoAsync(int casoId)
        {
            return await _context.Retiros
                .Where(r => r.IdCaso == casoId && r.Estado != "Rechazado")
                .SumAsync(r => r.Monto);
        }

        public async Task<decimal> ObtenerBalanceDisponibleAsync(int casoId)
        {
            var totalDonado = await _context.Donaciones
                .Where(d => d.IdCaso == casoId && d.Estado == "Completado")
                .SumAsync(d => d.Monto);

            var totalRetirado = await ObtenerTotalRetiradoPorCasoAsync(casoId);

            return totalDonado - totalRetirado;
        }

        public async Task Crear(Retiro retiro)
        {
            _context.Retiros.Add(retiro);
            await _context.SaveChangesAsync();
        }
    }
}
