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
        Task<bool> UsuarioYaTieneCasoAsync(int usuarioId);
        Task Crear(Caso caso);
        Task<List<Categoria>> ObtenerCategorias();
    }
}
