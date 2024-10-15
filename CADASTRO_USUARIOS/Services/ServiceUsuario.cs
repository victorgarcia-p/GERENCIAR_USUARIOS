using AutoMapper;
using CADASTRO_USUARIOS.DTOs;
using CADASTRO_USUARIOS.Models;
using CADASTRO_USUARIOS.Repositories.Interfaces;
using CADASTRO_USUARIOS.Services.Interfaces;

namespace CADASTRO_USUARIOS.Services;

public class ServiceUsuario : IServiceUsuario
{
    private readonly IUsuarioRepository _usuarioRepository;

    private readonly IServiceUtil _serviceUtil;

    //private readonly IMapper _mapper;

    public ServiceUsuario(IUsuarioRepository usuarioRepository, IServiceUtil serviceUtil)
    {
        _usuarioRepository = usuarioRepository;
        _serviceUtil = serviceUtil;
        //_mapper = mapper;
    }

    public async Task<IEnumerable<Usuario>> GetAll()
    {
        var usuarios = await _usuarioRepository.GetAll();
        return usuarios;
    }

    public async Task<Usuario> Get(string USUARIO)
    {
        var usuario = await _usuarioRepository.Get(USUARIO);
        return usuario;
    }

    public async Task<Usuario> Create(Usuario USUARIO)
    {
        USUARIO.SENHA = _serviceUtil.CryptSenha(USUARIO.SENHA);

        var usuario = await _usuarioRepository.Create(USUARIO);
        return usuario;
    }

    public async Task<Usuario> Update(Usuario USUARIO)
    {
        var usuario = await _usuarioRepository.Update(USUARIO);
        return usuario;
    }

    public async Task<Usuario> UpdateSenha(Usuario USUARIO)
    {
        USUARIO.SENHA = _serviceUtil.CryptSenha(USUARIO.SENHA);

        var usuario = await _usuarioRepository.Update(USUARIO);
        return usuario;
    }

    public async Task<string> Delete(string USUARIO)
    {
        return await _usuarioRepository.Delete(USUARIO);
    }
}
