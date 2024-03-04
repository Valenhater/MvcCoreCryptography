using Microsoft.AspNetCore.Mvc;
using MvcCoreCryptography.Models;
using MvcCoreCryptography.Repositories;

namespace MvcCoreCryptography.Controllers
{
    public class UsuariosController : Controller
    {
        private RepositoryUsuarios repo;

        public UsuariosController (RepositoryUsuarios repo)
        {
            this.repo = repo;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string nombre, string email, string password, string imagen)
        {
            await this.repo.RegisterUser(nombre, email, password, imagen);
            ViewData["MENSAJE"] = "Usuario registrado correctamente";
            return View();

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            Usuario usuario = await this.repo.LogInUser(email, password);
            if (usuario == null)
            {
                ViewData["MENSAJE"] = "Credenciales incorrectas";
                return View();
            }
            else
            {
                return View(usuario);
            }
        }

    }
}
