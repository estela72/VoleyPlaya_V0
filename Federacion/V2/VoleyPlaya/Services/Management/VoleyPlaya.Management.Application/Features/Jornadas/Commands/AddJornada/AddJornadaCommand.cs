using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Jornadas.Commands.AddJornada
{
    public class AddJornadaCommand : IRequest<JornadaDto>
    {
        public string Nombre { get; set; } = string.Empty;
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int EdicionId { get; set; }
    }
}
