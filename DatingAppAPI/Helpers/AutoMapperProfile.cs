using System.Linq;
using AutoMapper;
using DatingAppAPI.Dtos;
using DatingAppAPI.Models;

namespace DatingAppAPI.Helpers
{
    public class AutoMapperProfile: Profile
    { // en este archivo declaramos los mapeos 
        public AutoMapperProfile()
        {
            CreateMap<Usuario,UsuarioDetalleDto>().ForMember(dest => dest.URLFotoPrincipal,opt => {
                opt.MapFrom(src => src.Fotos.FirstOrDefault(e=> e.EsPrincipal).Url);
                })
                .ForMember(dest => dest.Edad, opt => { 
                    opt.ResolveUsing(e => e.FechaNacimiento.CalcularEdad());
                    });

            CreateMap<Usuario,UsuarioParaListaDto>().
            ForMember(dest => dest.UrlFotoPrincipal,opt => {
                opt.MapFrom(src => src.Fotos.FirstOrDefault(e=> e.EsPrincipal==true).Url);
                })  .ForMember(dest => dest.Edad, opt => { 
                    opt.ResolveUsing(e => e.FechaNacimiento.CalcularEdad());
                    });


            CreateMap<Foto,FotoDetalleUsuarioDto>();
        }
    }
}