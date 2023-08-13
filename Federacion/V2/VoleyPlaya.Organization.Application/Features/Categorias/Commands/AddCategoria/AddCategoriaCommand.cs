using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Categorias.Commands.AddCategoria;

public class AddCategoriaCommand : IRequest<CategoriaDto>
{
    public string Nombre { get; set; } = string.Empty;
}
