using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Ediciones.Commands.AddEdicion
{
    public class AddEdicionCommand : IRequest<EdicionDto>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Prueba { get; set; } = string.Empty;
    }
}
