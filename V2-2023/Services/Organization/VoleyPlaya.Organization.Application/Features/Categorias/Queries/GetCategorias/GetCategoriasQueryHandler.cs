using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;

namespace VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategorias
{
    public class GetCategoriasQueryHandler : IRequestHandler<GetCategoriasQuery, IList<CategoriaDto>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public GetCategoriasQueryHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IList<CategoriaDto>> Handle(GetCategoriasQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            return _mapper.Map<IList<CategoriaDto>>(categorias);
        }
    }
}
