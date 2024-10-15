using AutoMapper;
using CADASTRO_USUARIOS.Models;

namespace CADASTRO_USUARIOS.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Usuario, UsuarioDTO>().ReverseMap();
    }
}
