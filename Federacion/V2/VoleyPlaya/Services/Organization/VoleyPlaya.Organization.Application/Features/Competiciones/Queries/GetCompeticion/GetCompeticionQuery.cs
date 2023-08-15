using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticion
{
    public class GetCompeticionQuery : IRequest<CompeticionDto?>
    {
        public int Id { get; set; }

        public GetCompeticionQuery(int id)
        {
            Id = id;
        }
    }
}
