using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Categorias.Commands.DeleteCategoria
{
    public class DeleteCategoriaCommand : IRequest<bool>
    {
        public DeleteCategoriaCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
