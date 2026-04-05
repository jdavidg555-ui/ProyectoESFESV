using ProyectoSocioEconomico.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoSocioEconomico.Application.Interfaces
{
    public interface ICasoService
    {
        Task<List<Caso>> ObtenerTodos();
        Task<List<Caso>> ObtenerTodosConDetallesAsync();
        Task<List<Caso>> ObtenerActivosParaHome(int cantidad);
        Task<Caso?> ObtenerPorIdConDetallesAsync(int id);
        Task Crear(Caso caso);
    }
}
