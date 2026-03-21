using ProyectoSocioEconomico.Domain.Entities;

namespace ProyectoSocioEconomico.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ObtenerTodos();
        Task<Usuario> ObtenerPorId(int id);
        Task Crear(Usuario usuario);
    }
}