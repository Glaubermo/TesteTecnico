using AutoMapper;
using TesteTecnico.NetCore.API.ServiceApp.DTO;
using TesteTecnico.NetCore.Domain.Entities;

namespace TesteTecnico.NetCore.API.ServiceApp.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            CreateMap<Escolaridade, EscolaridadeDTO>().ReverseMap();
            CreateMap<HistoricoEscolar, HistoricoEscolarDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioEscolaridadeDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioEscolaridadeHistoricoEscolarDTO>().ReverseMap();
        }
    }
}
