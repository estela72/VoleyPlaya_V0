using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategoria
{
    public class GetCategoriaQueryHandler : IRequestHandler<GetCategoriaQuery, CategoriaDto?>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public GetCategoriaQueryHandler(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<CategoriaDto?> Handle(GetCategoriaQuery request, CancellationToken cancellationToken)
        {
            Categoria? categoria = await _categoriaRepository.GetByIdAsync(request.CategoriaId);
            if (categoria == null) return null;
            return _mapper.Map<CategoriaDto>(categoria);
        }
    }
}
