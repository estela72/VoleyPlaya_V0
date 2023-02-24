﻿using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LigamaniaCoreApp.Data.Repository.Base.Model
{
    public abstract class GenericAuditableRepository<T> : GenericIdRepository<T>, IGenericAuditableIdRepository<T> where T : AuditableEntity
    {
        protected GenericAuditableRepository(DbContext context) : base(context)
        {
        }
    }
}
