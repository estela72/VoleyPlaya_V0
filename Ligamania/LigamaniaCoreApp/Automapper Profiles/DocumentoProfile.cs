using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class DocumentoProfile:Profile
    {
        public DocumentoProfile()
        {
            CreateMap<DocumentsDTO, ReglamentoViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nombre));
        }
    }
}
