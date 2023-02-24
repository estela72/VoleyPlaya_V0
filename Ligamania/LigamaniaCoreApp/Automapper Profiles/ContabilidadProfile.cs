using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Automapper_Profiles
{
    public class ContabilidadProfile : Profile
    {
        public ContabilidadProfile()
        {
            CreateMap<TemporadaContabilidadDTO, ContabilidadViewModel>();
        }
    }
}
