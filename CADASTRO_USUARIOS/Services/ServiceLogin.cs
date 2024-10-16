using AutoMapper;
using CADASTRO_USUARIOS.DTOs;
using CADASTRO_USUARIOS.Models;
using CADASTRO_USUARIOS.Repositories;
using CADASTRO_USUARIOS.Repositories.Interfaces;
using CADASTRO_USUARIOS.Services.Interfaces;

namespace CADASTRO_USUARIOS.Services;

public class ServiceLogin : IServiceLogin
{
    private readonly IServiceUtil _serviceUtil;

    private readonly IUsuarioRepository _usuarioRepository;

    private readonly IMapper _mapper;

    public ServiceLogin(IServiceUtil serviceUtil, IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _serviceUtil = serviceUtil;

        _usuarioRepository = usuarioRepository;

        _mapper = mapper;
    }

    public async Task<UsuarioDTO> Post(RequestLogin login)
    {
        var usuario = await _usuarioRepository.Get(login.Usuario);

        if (_serviceUtil.VerificarSenha(login.Senha, usuario.SENHA))
        {
            return _mapper.Map<UsuarioDTO>(usuario);
        }
        return null;
    }
}
