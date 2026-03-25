using ProyectoSocioEconomico.Domain.Entities;

namespace ProyectoSocioEconomico.Application.Interfaces
{
    public interface ICasoService
    {
        Task<List<Caso>> ObtenerTodos();
        Task<List<Caso>> ObtenerActivosParaHome(int cantidad);
        Task Crear(Caso caso);
    }
}