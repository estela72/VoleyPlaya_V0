using AutoMapper;

using GenericLib;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Categorias.Commands.AddCategoria
{
    public class AddCategoriaCommandHandler : IRequestHandler<AddCategoriaCommand, CategoriaDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddCategoriaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CategoriaDto> Handle(AddCategoriaCommand request, CancellationToken cancellationToken)
        {
            Categoria categoria = new Categoria() { Nombre = request.Nombre };
            if (await _unitOfWork.CategoriaRepository.ExistsAsync(c => c.Nombre.Equals(request.Nombre)))
                throw new VoleyPlayaDomainException("Ya existe una categoría con el nombre " + request.Nombre);

            categoria = await _unitOfWork.CategoriaRepository.AddAsync(categoria);
            return _mapper.Map<CategoriaDto>(categoria);
        }
    }
}
