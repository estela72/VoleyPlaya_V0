using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Temporadas.Queries.GetTemporada
{
    public class GetTemporadaQuery : IRequest<TemporadaDto?>
    {
        public int Id { get; set; }

        public GetTemporadaQuery(int id)
        {
            Id = id;
        }
    }
}
