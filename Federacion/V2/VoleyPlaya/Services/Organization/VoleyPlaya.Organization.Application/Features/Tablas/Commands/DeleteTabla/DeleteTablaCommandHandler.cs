using AutoMapper;

using Common.Application.Exceptions;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.Features.Equipos.Commands.DeleteEquipo;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Tablas.Commands.DeleteTabla
{
    public class DeleteTablaCommandHandler : IRequestHandler<DeleteTablaCommand, bool>
    {
        private readonly IUnitOfWorkOrganization _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteTablaCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteTablaCommand request, CancellationToken cancellationToken)
        {
            Tabla tabla = await _unitOfWork.TablaRepository.GetByIdAsync(request.Id);
            if (tabla == null)
                throw new GenericDomainException("La tabla no existe");

            return await _unitOfWork.TablaRepository.DeleteAsync(tabla);
        }
    }
}
