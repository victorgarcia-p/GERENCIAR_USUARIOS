using CADASTRO_USUARIOS.Models;

namespace CADASTRO_USUARIOS.Services.Interfaces;

public interface IServiceLogin
{
    Task<bool> Get(RequestLogin login);
}
