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

namespace VoleyPlaya.Organization.Application.Features.Categorias.Commands.DeleteCategoria
{
    public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteCategoriaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            Categoria categoria = await _unitOfWork.CategoriaRepository.GetByIdAsync(request.Id);
            if (categoria == null)
                throw new VoleyPlayaDomainException("La categoria no existe");

            return await _unitOfWork.CategoriaRepository.DeleteAsync(categoria);
        }
    }
}
