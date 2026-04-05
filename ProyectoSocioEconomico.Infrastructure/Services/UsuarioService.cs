using Microsoft.EntityFrameworkCore;
using ProyectoSocioEconomico.Application.Interfaces;
using ProyectoSocioEconomico.Domain.Entities;
using ProyectoSocioEconomico.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSocioEconomico.Infrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UsuarioService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Usuario>> ObtenerTodos()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> ObtenerPorId(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Usuarios.FindAsync(id);
        }

        public async Task Crear(Usuario usuario)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
        }

        public async Task Actualizar(Usuario usuario)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task ActualizarPassword(int usuarioId, string passwordHash)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var user = await context.Usuarios.FindAsync(usuarioId);
            if (user != null)
            {
                user.PasswordHash = passwordHash;
                await context.SaveChangesAsync();
            }
        }

        public string HashPassword(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public async Task<Usuario?> VerificarCredenciales(string email, string password)
        {
            var passwordHash = HashPassword(password);
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Usuarios
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(u => 
                    u.Email.ToLower() == email.Trim().ToLower() && 
                    u.PasswordHash == passwordHash);
        }
    }
}
