using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategorias
{
    public class GetCategoriasQuery : IRequest<IList<CategoriaDto>>
    {
    }
}
