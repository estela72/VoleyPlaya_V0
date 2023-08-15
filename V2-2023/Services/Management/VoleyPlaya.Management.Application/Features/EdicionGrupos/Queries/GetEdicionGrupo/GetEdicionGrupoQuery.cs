using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.EdicionGrupos.Queries.GetEdicionGrupo
{
    public class GetEdicionGrupoQuery : IRequest<EdicionGrupoDto?>
    {
        public int EdicionGrupoId { get; set; }

        public GetEdicionGrupoQuery(int edicionGrupoId)
        {
            EdicionGrupoId = edicionGrupoId;
        }
    }
}
