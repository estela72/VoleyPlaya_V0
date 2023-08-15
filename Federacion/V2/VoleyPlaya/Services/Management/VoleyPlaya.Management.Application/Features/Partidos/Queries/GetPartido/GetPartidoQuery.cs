using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Partidos.Queries.GetPartido
{
    public class GetPartidoQuery : IRequest<PartidoDto?>
    {
        public int PartidoId { get; set; }

        public GetPartidoQuery(int partidoId)
        {
            PartidoId = partidoId;
        }
    }
}
