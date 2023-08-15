using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Competiciones.Commands.AddCompeticion
{
    public class AddCompeticionCommand : IRequest<CompeticionDto>
    {
        public string Nombre { get; set; } = string.Empty;
    }
}
