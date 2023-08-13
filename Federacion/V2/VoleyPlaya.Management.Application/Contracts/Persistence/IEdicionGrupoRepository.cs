using Common.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Application.Contracts.Persistence
{
    public interface IEdicionGrupoRepository : IAsyncRepository<EdicionGrupo>
    {
    }
}
