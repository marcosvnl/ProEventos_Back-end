using AutoMapper;
using ProEventos.Aplication.Dtos;
using ProEventos.Domain;

namespace ProEventos.Aplication.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
            CreateMap<RedesSociais, RedeSocialDto>().ReverseMap();
        }
    }
}
