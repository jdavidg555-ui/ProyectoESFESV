using ProyectoSocioEconomico.Domain.Entities;

namespace ProyectoSocioEconomico.Application.Interfaces
{
    public interface ICasoService
    {
        Task<List<Caso>> ObtenerTodos();
        Task Crear(Caso caso);
    }
}