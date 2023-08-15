using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticiones
{
    public class GetCompeticionesQuery : IRequest<IList<CompeticionDto>>
    {
    }
}
