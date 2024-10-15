using CADASTRO_USUARIOS.Models;

namespace CADASTRO_USUARIOS.Services.Interfaces;

public interface IServiceUsuario
{
    Task<IEnumerable<Usuario>> GetAll();
    Task<Usuario> Get(string USUARIO);
    Task<Usuario> Create(Usuario USUARIO);
    Task<Usuario> Update(Usuario USUARIO);
    Task<Usuario> UpdateSenha(Usuario USUARIO);
    Task<string> Delete(string USUARIO);
}
