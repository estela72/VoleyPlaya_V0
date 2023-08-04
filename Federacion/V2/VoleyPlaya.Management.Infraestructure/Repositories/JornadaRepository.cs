﻿using GenericLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Domain;
using VoleyPlaya.Management.Infraestructure.Persistence;

namespace VoleyPlaya.Management.Infraestructure.Repositories
{
    public class JornadaRepository : RepositoryBase<Jornada>, IJornadaRepository
    {
        public JornadaRepository(GenericDbContext context) : base(context)
        {
        }
    }
}
