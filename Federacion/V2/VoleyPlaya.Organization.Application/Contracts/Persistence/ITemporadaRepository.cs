using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Domain;
using GenericLib;

namespace VoleyPlaya.Organization.Application.Contracts.Persistence
{
    public interface ITemporadaRepository : IAsyncRepository<Temporada>
    {
    }
}
