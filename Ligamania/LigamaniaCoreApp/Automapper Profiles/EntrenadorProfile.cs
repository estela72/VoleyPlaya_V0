using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models;
using LigamaniaCoreApp.Models.AccountViewModels;
using LigamaniaCoreApp.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.AutomapperProfiles
{
    public class EntrenadorProfile : Profile
    {
        public EntrenadorProfile()
        {
            CreateMap<ApplicationUser, RegisterViewModel>();
        }
    }
}
