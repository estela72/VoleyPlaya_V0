using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VoleyPlaya.Management.Application.Features.Jornadas.Commands.DeleteJornada
{
    public class DeleteJornadaCommand : IRequest<bool>
    {
        public DeleteJornadaCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
