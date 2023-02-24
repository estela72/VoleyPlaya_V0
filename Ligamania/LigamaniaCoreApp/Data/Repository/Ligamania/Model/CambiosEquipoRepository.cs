﻿using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class CambiosEquipoRepository : GenericAuditableRepository<CambiosEquipoDTO>, ICambiosEquipoRepository
    {
        public CambiosEquipoRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
