using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Organization.Application.Features.Tablas.Commands.DeleteTabla
{
    public class DeleteTablaCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}