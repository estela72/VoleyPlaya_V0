using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Jornadas.Queries.GetJornada
{
    public class GetJornadaQuery : IRequest<JornadaDto?>
    {
        public int JornadaId { get; set; }

        public GetJornadaQuery(int jornadaId)
        {
            JornadaId = jornadaId;
        }
    }
}
