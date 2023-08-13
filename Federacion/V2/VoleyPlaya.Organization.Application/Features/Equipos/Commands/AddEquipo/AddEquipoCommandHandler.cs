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
using VoleyPlaya.Organization.Application.Features.Competiciones.Commands.AddCompeticion;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Equipos.Commands.AddEquipo
{
    public class AddEquipoCommandHandler : IRequestHandler<AddEquipoCommand, EquipoDto>
    {
        private readonly IUnitOfWorkOrganization _unitOfWork;
        private readonly IMapper _mapper;
        public AddEquipoCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EquipoDto> Handle(AddEquipoCommand request, CancellationToken cancellationToken)
        {
            Equipo equipo = new Equipo() { Nombre = request.Nombre };
            if (await _unitOfWork.EquipoRepository.ExistsAsync(c => c.Nombre.Equals(request.Nombre)))
                throw new GenericDomainException("Ya existe un equipo con el nombre " + request.Nombre);

            equipo = await _unitOfWork.EquipoRepository.AddAsync(equipo);
            return _mapper.Map<EquipoDto>(equipo);
        }
    }
}
