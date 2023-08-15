
using Common.Infraestructure.Persistence;
using Common.Infraestructure.Repositories;

using Microsoft.EntityFrameworkCore;

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
    public class PartidoRepository : RepositoryBase<Partido>, IPartidoRepository
    {
        public PartidoRepository(GenericDbContext context) : base(context)
        {
        }
    }
}
