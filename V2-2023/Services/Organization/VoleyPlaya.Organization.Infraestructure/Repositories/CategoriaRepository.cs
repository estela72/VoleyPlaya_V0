﻿using Common.Infraestructure.Persistence;
using Common.Infraestructure.Repositories;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Domain;
using VoleyPlaya.Organization.Infraestructure.Persistence;

namespace VoleyPlaya.Organization.Infraestructure.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(GenericDbContext context) : base(context)
        {
        }
    }
}
