using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Tablas.Commands.AddTabla
{
    public class AddTablaCommand : IRequest<TablaDto>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Equipo1 { get; set; } = string.Empty;
        public string Equipo2 { get; set; } = string.Empty;
        public string Ronda { get; set; } = string.Empty;
    }
}
