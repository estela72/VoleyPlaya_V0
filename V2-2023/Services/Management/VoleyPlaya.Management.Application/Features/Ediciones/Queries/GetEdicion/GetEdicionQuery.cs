using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Ediciones.Queries.GetEdicion
{
    public class GetEdicionQuery : IRequest<EdicionDto?>
    {
        public int EdicionId { get; set; }

        public GetEdicionQuery(int edicionId)
        {
            EdicionId = edicionId;
        }
    }
}
