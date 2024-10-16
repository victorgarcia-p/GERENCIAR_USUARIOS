using GERENCIAR_USUARIOS.Web.Models;
using GERENCIAR_USUARIOS.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GERENCIAR_USUARIOS.Web.Controllers;

public class LoginController : Controller
{
    private readonly IServicesLogin _servicesLogin;

    public LoginController(IServicesLogin servicesLogin)
    {
        _servicesLogin = servicesLogin;
    }

    public IActionResult Index()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return View();
        }
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> RealizarLogin(ViewModelRequestLogin login)
    {
        if (string.IsNullOrWhiteSpace(login.Usuario) || string.IsNullOrWhiteSpace(login.Senha))
        {
            return Json(new { message = "Entre com Usuário e Senha" });
        }

        var usuario = await _servicesLogin.Post(login);
        if (usuario is not null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.USUARIO),
                new Claim("Nivel", usuario.NIVEL),
                new Claim("Nome", usuario.NOME)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "login");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal);

            return Json(new { message = "Ok" });
        }
        return Json(new { message = "Usuário ou senha inválidos" });
    }

    public IActionResult Logout()
    {
        HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Login");
    }
}
