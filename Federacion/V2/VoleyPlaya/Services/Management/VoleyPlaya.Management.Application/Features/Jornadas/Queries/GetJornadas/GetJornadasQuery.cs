using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Jornadas.Queries.GetJornadaes
{
    public class GetJornadasQuery : IRequest<IList<JornadaDto>>
    {
    }
}
