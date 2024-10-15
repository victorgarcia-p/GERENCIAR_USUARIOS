using CADASTRO_USUARIOS.Models;
using CADASTRO_USUARIOS.Repositories;
using CADASTRO_USUARIOS.Repositories.Interfaces;
using CADASTRO_USUARIOS.Services.Interfaces;

namespace CADASTRO_USUARIOS.Services;

public class ServiceLogin : IServiceLogin
{
    private readonly IServiceUtil _serviceUtil;

    private readonly IUsuarioRepository _usuarioRepository;

    public ServiceLogin(IServiceUtil serviceUtil, IUsuarioRepository usuarioRepository)
    {
        _serviceUtil = serviceUtil;

        _usuarioRepository = usuarioRepository;
    }

    public async Task<bool> Get(RequestLogin login)
    {
        var usuario = await _usuarioRepository.Get(login.usuario);

        return _serviceUtil.VerificarSenha(login.senha, usuario.SENHA);
    }
}
