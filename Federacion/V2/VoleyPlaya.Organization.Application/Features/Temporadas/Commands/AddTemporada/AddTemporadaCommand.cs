using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Temporadas.Commands.AddTemporada
{
    public class AddTemporadaCommand : IRequest<TemporadaDto>
    {
        public string Nombre { get; set; } = string.Empty;
    }
}
