using CADASTRO_USUARIOS.Models;

namespace CADASTRO_USUARIOS.Repositories.Interfaces;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAll();
    Task<Usuario> Get(string USUARIO);
    Task<Usuario> Create(Usuario USUARIO);
    Task<Usuario> Update(Usuario USUARIO);
    Task<string> Delete(string USUARIO);
}
