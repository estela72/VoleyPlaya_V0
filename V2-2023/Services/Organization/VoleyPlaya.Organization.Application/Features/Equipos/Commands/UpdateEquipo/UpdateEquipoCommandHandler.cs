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
using VoleyPlaya.Organization.Application.Features.Competiciones.Commands.UpdateCompeticion;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Equipos.Commands.UpdateEquipo
{
    public class UpdateEquipoCommandHandler : IRequestHandler<UpdateEquipoCommand, EquipoDto>
    {
        private readonly IUnitOfWorkOrganization _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateEquipoCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EquipoDto> Handle(UpdateEquipoCommand request, CancellationToken cancellationToken)
        {
            Equipo equipo = await _unitOfWork.EquipoRepository.GetByIdAsync(request.Id);
            if (equipo == null)
                throw new GenericDomainException("La competición no existe");

            equipo.Nombre = request.Nombre;
            equipo = await _unitOfWork.EquipoRepository.UpdateAsync(equipo);
            return _mapper.Map<EquipoDto>(equipo);
        }
    }
}
