using CADASTRO_USUARIOS.DTOs;
using CADASTRO_USUARIOS.Models;
using CADASTRO_USUARIOS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CADASTRO_USUARIOS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IServiceLogin _serviceLogin;

    public LoginController(IServiceLogin serviceLogin)
    {
        _serviceLogin = serviceLogin;
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioDTO>> Post([FromBody] RequestLogin login)
    {
        var usuario = await _serviceLogin.Post(login);

        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }
}
