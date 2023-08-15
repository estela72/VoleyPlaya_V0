using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Organization.Application.Features.Competiciones.Commands.DeleteCompeticion
{
    public class DeleteCompeticionCommand : IRequest<bool>
    {
        public DeleteCompeticionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
