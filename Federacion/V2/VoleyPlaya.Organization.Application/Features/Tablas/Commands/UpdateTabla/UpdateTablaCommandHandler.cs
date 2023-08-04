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
using VoleyPlaya.Organization.Application.Features.Equipos.Commands.UpdateEquipo;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Tablas.Commands.UpdateTabla
{
    public class UpdateTablaCommandHandler : IRequestHandler<UpdateTablaCommand, TablaDto>
    {
        private readonly IUnitOfWorkOrganization _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateTablaCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TablaDto> Handle(UpdateTablaCommand request, CancellationToken cancellationToken)
        {
            Tabla tabla = await _unitOfWork.TablaRepository.GetByIdAsync(request.Id);
            if (tabla == null)
                throw new GenericDomainException("La tabla no existe");

            tabla.Nombre = request.Nombre;
            tabla = await _unitOfWork.TablaRepository.UpdateAsync(tabla);
            return _mapper.Map<TablaDto>(tabla);
        }
    }
}
