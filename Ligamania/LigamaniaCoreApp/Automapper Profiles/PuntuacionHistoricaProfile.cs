using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class PuntuacionHistoricaProfile : Profile
    {
            public PuntuacionHistoricaProfile()
            {
                //Complex to Flattened
                CreateMap<PuntuacionHistoricaDTO, PuntuacionHistoricaViewModel>()
                    .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Nombre))
                    .ForMember(dest => dest.Competicion, opt => opt.MapFrom(src => src.Competicion.Nombre));
        }
    }
}
