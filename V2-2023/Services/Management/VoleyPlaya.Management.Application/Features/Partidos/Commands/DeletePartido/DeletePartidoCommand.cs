using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VoleyPlaya.Management.Application.Features.Partidos.Commands.DeletePartido
{
    public class DeletePartidoCommand : IRequest<bool>
    {
        public DeletePartidoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
