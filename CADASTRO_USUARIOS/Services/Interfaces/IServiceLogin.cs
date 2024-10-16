using CADASTRO_USUARIOS.DTOs;
using CADASTRO_USUARIOS.Models;

namespace CADASTRO_USUARIOS.Services.Interfaces;

public interface IServiceLogin
{
    Task<UsuarioDTO> Post(RequestLogin login);
}
