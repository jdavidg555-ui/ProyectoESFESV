using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ProyectoSocioEconomico.Domain.Entities;
using System.Security.Claims;
using System.Text.Json;

namespace ProyectoSocioEconomico.WebUI.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedLocalStorage _localStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedLocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _localStorage.GetAsync<string>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                if (string.IsNullOrWhiteSpace(userSession))
                    return new AuthenticationState(_anonymous);

                var usuario = JsonSerializer.Deserialize<Usuario>(userSession);
                if (usuario == null)
                    return new AuthenticationState(_anonymous);

                var claimsPrincipal = CreateClaimsPrincipalFromUser(usuario);
                return new AuthenticationState(claimsPrincipal);
            }
            catch
            {
                return new AuthenticationState(_anonymous);
            }
        }

        public async Task NotifyUserLogin(Usuario usuario)
        {
            var userSession = JsonSerializer.Serialize(usuario);
            await _localStorage.SetAsync("UserSession", userSession);

            var claimsPrincipal = CreateClaimsPrincipalFromUser(usuario);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task NotifyUserLogout()
        {
            await _localStorage.DeleteAsync("UserSession");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
        }

        private ClaimsPrincipal CreateClaimsPrincipalFromUser(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("ImagenPerfil", usuario.ImagenPerfil ?? "uploads/profiles/DefaultProfile.png")
            };

            // If the role name is known (e.g. from a join or property), add it here.
            // For now, let's use a generic role or handle it based on IdRol if we had a mapping.
            // Since we want to check for "beneficiado", we'll add the claim.
            // Note: Ideally, 'usuario' should have a 'Role' navigation property loaded.
            if (usuario.IdRol == 1) claims.Add(new Claim(ClaimTypes.Role, "beneficiado"));
            else claims.Add(new Claim(ClaimTypes.Role, "Usuario"));

            var identity = new ClaimsIdentity(claims, "CustomAuth");
            return new ClaimsPrincipal(identity);
        }
    }
}
