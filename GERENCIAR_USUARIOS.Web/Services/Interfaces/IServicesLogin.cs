using GERENCIAR_USUARIOS.Web.Models;

namespace GERENCIAR_USUARIOS.Web.Services.Interfaces;

public interface IServicesLogin
{
    Task<ViewModelUsuario> Post(ViewModelRequestLogin login);
}
