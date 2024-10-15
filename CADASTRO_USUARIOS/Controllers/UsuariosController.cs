using CADASTRO_USUARIOS.DTOs;
using CADASTRO_USUARIOS.Models;
using CADASTRO_USUARIOS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CADASTRO_USUARIOS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IServiceUsuario _serviceUsuario;

    public UsuariosController(IServiceUsuario serviceUsuario)
    {
        _serviceUsuario = serviceUsuario;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
    {
        var usuarios = await _serviceUsuario.GetAll();
        
        if (usuarios is null)
            return NotFound();

        return Ok(usuarios);
    }

    [HttpGet("{USUARIO}")]
    public async Task<ActionResult<UsuarioDTO>> Get(string USUARIO)
    {
        var usuario = await _serviceUsuario.Get(USUARIO);
        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> Create(Usuario USUARIO)
    {
        var usuario = await _serviceUsuario.Create(USUARIO);

        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<ActionResult<Usuario>> Update(Usuario USUARIO)
    {
        var usuario = await _serviceUsuario.Update(USUARIO);

        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPut]
    [Route("UpdateSenha")]
    public async Task<ActionResult<Usuario>> UpdateSenha(Usuario USUARIO)
    {
        var usuario = await _serviceUsuario.UpdateSenha(USUARIO);

        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpDelete]
    public async Task<ActionResult<string>> Delete(string USUARIO)
    {
        return await _serviceUsuario.Delete(USUARIO);
    }
}
