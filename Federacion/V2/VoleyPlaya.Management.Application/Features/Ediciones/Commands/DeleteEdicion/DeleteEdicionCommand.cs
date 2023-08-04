using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VoleyPlaya.Management.Application.Features.Ediciones.Commands.DeleteEdicion
{
    public class DeleteEdicionCommand : IRequest<bool>
    {
        public DeleteEdicionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
