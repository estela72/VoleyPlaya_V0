using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Tablas.Queries.GetTabla
{
    public class GetTablaQuery : IRequest<TablaDto?>
    {
        public int Id { get; set; }

        public GetTablaQuery(int id)
        {
            Id = id;
        }
    }
}
