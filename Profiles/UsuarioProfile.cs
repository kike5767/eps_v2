using AutoMapper;
using EPS.DTOs;
using lib_dominio.Entidades;

namespace EPS.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<UpdateUsuarioDto, Usuario>();
        }
    }
}


