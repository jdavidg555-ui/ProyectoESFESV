using Microsoft.AspNetCore.Mvc;
using ProyectoSocioEconomico.Application.Services;

namespace ProyectoSocioEconomico.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}