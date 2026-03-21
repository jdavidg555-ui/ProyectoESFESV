using Microsoft.EntityFrameworkCore;
using ProyectoSocioEconomico.Application.Interfaces;
using ProyectoSocioEconomico.Domain.Entities;
using ProyectoSocioEconomico.Infrastructure.Data;

namespace ProyectoSocioEconomico.Infrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerTodos()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObtenerPorId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task Crear(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}