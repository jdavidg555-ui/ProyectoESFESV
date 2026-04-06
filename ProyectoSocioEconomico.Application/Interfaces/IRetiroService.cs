using ProyectoSocioEconomico.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoSocioEconomico.Application.Interfaces
{
    public interface IRetiroService
    {
        Task<List<Retiro>> ObtenerPorBeneficiadoIdAsync(int beneficiadoId);
        Task<decimal> ObtenerTotalRetiradoPorCasoAsync(int casoId);
        Task<decimal> ObtenerBalanceDisponibleAsync(int casoId);
        Task Crear(Retiro retiro);
    }
}
