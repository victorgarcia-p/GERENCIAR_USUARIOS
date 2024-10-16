using GERENCIAR_USUARIOS.Web.Models;

namespace GERENCIAR_USUARIOS.Web.Services.Interfaces;

public interface IServicesUsuario
{
    Task<IEnumerable<ViewModelUsuario>> GetAll();
    Task<ViewModelUsuario> Get(string USUARIO);
    Task<ViewModelUsuario> Create(ViewModelUsuario USUARIO);
    Task<ViewModelUsuario> Update(ViewModelUsuario USUARIO);
    Task<ViewModelUsuario> UpdateSenha(ViewModelUsuario USUARIO);
    Task<string> Delete(string USUARIO);
}
