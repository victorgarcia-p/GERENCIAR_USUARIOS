using CADASTRO_USUARIOS.DTOs;
using CADASTRO_USUARIOS.Models;

namespace CADASTRO_USUARIOS.Services.Interfaces;

public interface IServiceUsuario
{
    Task<IEnumerable<UsuarioDTO>> GetAll();
    Task<UsuarioDTO> Get(string USUARIO);
    Task<UsuarioDTO> Create(UsuarioDTO USUARIO);
    Task<UsuarioDTO> Update(UsuarioDTO USUARIO);
    Task<UsuarioDTO> UpdateSenha(UsuarioDTO USUARIO);
    Task<string> Delete(string USUARIO);
}
