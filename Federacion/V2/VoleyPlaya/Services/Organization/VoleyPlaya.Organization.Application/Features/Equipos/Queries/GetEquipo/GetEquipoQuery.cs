using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Equipos.Queries.GetEquipo
{
    public class GetEquipoQuery : IRequest<EquipoDto?>
    {
        public int Id { get; set; }

        public GetEquipoQuery(int id)
        {
            Id = id;
        }
    }
}
