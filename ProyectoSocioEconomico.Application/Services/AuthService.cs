using ProyectoSocioEconomico.Domain.Entities;
using ProyectoSocioEconomico.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSocioEconomico.Application.Services
{
    public class AuthService
    {
        private readonly ProyectoSocioEconomicoDbContext _context;

        public AuthService(ProyectoSocioEconomicoDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> Login(string correo, string password)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == correo && u.PasswordHash == password);

            return usuario;
        }
    }
}