using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VoleyPlaya.Management.Application.Features.EdicionGrupos.Commands.DeleteEdicionGrupo
{
    public class DeleteEdicionGrupoCommand : IRequest<bool>
    {
        public DeleteEdicionGrupoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
