using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.HerramientasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class CambioEquipoProfile : Profile
    {
        public CambioEquipoProfile()
        {
            //Complex to Flattened
            CreateMap<CambiosEquipoDTO, CambioEquipoViewModel>()
                .ForMember(dest => dest.Temporada, opt => opt.MapFrom(src => src.Temporada.Nombre))
                .ForMember(dest => dest.CambioPor, opt => opt.MapFrom(src => src.EquipoDestino.Nombre))
                .ForMember(dest => dest.EquipoOriginal, opt => opt.MapFrom(src => src.EquipoOrigen.Nombre));
        }
    }
}
