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

    private readonly IMapper _mapper;

    public ServiceUsuario(IUsuarioRepository usuarioRepository, IServiceUtil serviceUtil, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _serviceUtil = serviceUtil;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioDTO>> GetAll()
    {

        var usuarios = await _usuarioRepository.GetAll();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
    }

    public async Task<UsuarioDTO> Get(string USUARIO)
    {
        var usuario = await _usuarioRepository.Get(USUARIO);
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task<UsuarioDTO> Create(UsuarioDTO USUARIO)
    {
        USUARIO.SENHA = _serviceUtil.CryptSenha(USUARIO.SENHA);

        var usuario = await _usuarioRepository.Create(_mapper.Map<Usuario>(USUARIO));

        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task<UsuarioDTO> Update(UsuarioDTO USUARIO)
    {

        var usuario = await _usuarioRepository.Update(_mapper.Map<Usuario>(USUARIO));
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task<UsuarioDTO> UpdateSenha(UsuarioDTO USUARIO)
    {
        USUARIO.SENHA = _serviceUtil.CryptSenha(USUARIO.SENHA);

        var usuario = await _usuarioRepository.Update(_mapper.Map<Usuario>(USUARIO));
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task<string> Delete(string USUARIO)
    {
        return await _usuarioRepository.Delete(USUARIO);
    }
}
