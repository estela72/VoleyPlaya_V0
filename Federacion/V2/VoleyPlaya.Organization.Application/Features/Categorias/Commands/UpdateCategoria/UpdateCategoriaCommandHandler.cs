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
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.AddCategoria;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Categorias.Commands.UpdateCategoria
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, CategoriaDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCategoriaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CategoriaDto> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            Categoria categoria = await _unitOfWork.CategoriaRepository.GetByIdAsync(request.Id);
            if (categoria == null)
                throw new VoleyPlayaDomainException("La categoría no existe");

            categoria.Nombre = request.Nombre;
            categoria = await _unitOfWork.CategoriaRepository.UpdateAsync(categoria);
            return _mapper.Map<CategoriaDto>(categoria);
        }
    }
}