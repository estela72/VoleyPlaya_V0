using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Tablas.Commands.UpdateTabla
{
    public class UpdateTablaCommand : IRequest<TablaDto>
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
