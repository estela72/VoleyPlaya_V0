using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Partidos.Queries.GetPartidoes
{
    public class GetPartidosQuery : IRequest<IList<PartidoDto>>
    {
    }
}
