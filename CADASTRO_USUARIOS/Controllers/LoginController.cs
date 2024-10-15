using CADASTRO_USUARIOS.DTOs;
using CADASTRO_USUARIOS.Models;
using CADASTRO_USUARIOS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
    public async Task<ActionResult<UsuarioDTO>> Get(RequestLogin login)
    {
        if (await _serviceLogin.Get(login))
            return Ok();

        return BadRequest();
    }
}
