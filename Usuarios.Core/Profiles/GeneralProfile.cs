using AutoMapper;
using Usuarios.Core.Dtos;
using Usuarios.Core.Entidades;

namespace Usuarios.Core.Profiles
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<TarjetaCliente, TarjetaClienteDto>().ReverseMap();
        }
    }
}