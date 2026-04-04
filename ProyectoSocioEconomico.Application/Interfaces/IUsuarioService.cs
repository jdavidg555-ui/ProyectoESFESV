using ProyectoSocioEconomico.Domain.Entities;

namespace ProyectoSocioEconomico.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ObtenerTodos();
        Task<Usuario> ObtenerPorId(int id);
        Task Crear(Usuario usuario);
        Task Actualizar(Usuario usuario);
        Task ActualizarPassword(int usuarioId, string passwordHash);
        string HashPassword(string password);
        Task<Usuario?> VerificarCredenciales(string email, string password);
    }
}