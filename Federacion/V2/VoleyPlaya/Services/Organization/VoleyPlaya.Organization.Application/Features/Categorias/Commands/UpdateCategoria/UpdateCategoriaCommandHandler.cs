using AutoMapper;

using Common.Application.Exceptions;

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

namespace VoleyPlaya.Organization.Application.Features.Categorias.Commands.UpdateCategoria;

public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, CategoriaDto>
{
    private readonly IUnitOfWorkOrganization _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateCategoriaCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CategoriaDto> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
    {
        Categoria categoria = await _unitOfWork.CategoriaRepository.GetByIdAsync(request.Id);
        if (categoria == null)
            throw new GenericDomainException("La categoría no existe");

        categoria.Nombre = request.Nombre;
        categoria = await _unitOfWork.CategoriaRepository.UpdateAsync(categoria);
        return _mapper.Map<CategoriaDto>(categoria);
    }
}