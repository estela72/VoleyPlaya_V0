using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Contracts.Persistence
{
    public interface IEquipoRepository:IAsyncRepository<Equipo>
    {
    }
}
