﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Domain;
using Common.Application.Contracts.Persistence;

namespace VoleyPlaya.Management.Application.Contracts.Persistence
{
    public interface IPartidoRepository : IAsyncRepository<Partido>
    {
    }
}
