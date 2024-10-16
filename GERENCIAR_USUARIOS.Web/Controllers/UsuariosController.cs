using GERENCIAR_USUARIOS.Web.Models;
using GERENCIAR_USUARIOS.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GERENCIAR_USUARIOS.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IServicesUsuario _servicesUsuario;
        public UsuariosController(IServicesUsuario servicesUsuario)
        {
            _servicesUsuario = servicesUsuario;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModelUsuario>>> Index()
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToAction("Index", "Login");

            var result = await _servicesUsuario.GetAll();

            if (result is null)
                return View("Error");

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario(ViewModelUsuario USUARIO)
        {
            if (ModelState.IsValid)
            {
                var result = await _servicesUsuario.Create(USUARIO);

                if (result is not null)
                    return RedirectToAction(nameof(Index));
            }
            return View(USUARIO);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUsuario(ViewModelUsuario USUARIO)
        {
            if (ModelState.IsValid)
            {
                var result = await _servicesUsuario.Update(USUARIO);

                if (result is not null)
                    return RedirectToAction(nameof(Index));
            }
            return View(USUARIO);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSenhaUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSenhaUsuario(ViewModelUsuario USUARIO)
        {
            if (ModelState.IsValid)
            {
                var result = await _servicesUsuario.UpdateSenha(USUARIO);

                if (result is not null)
                    return RedirectToAction(nameof(Index));
            }
            return View(USUARIO);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario(ViewModelUsuario USUARIO)
        {
            if (ModelState.IsValid)
            {
                var result = await _servicesUsuario.UpdateSenha(USUARIO);

                if (result is not null)
                    return RedirectToAction(nameof(Index));
            }
            return View(USUARIO);
        }
    }
}
