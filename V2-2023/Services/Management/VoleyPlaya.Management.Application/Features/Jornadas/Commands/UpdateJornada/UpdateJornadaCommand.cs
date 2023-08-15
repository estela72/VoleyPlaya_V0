using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Jornadas.Commands.UpdateJornada
{
    public class UpdateJornadaCommand : IRequest<JornadaDto>
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
