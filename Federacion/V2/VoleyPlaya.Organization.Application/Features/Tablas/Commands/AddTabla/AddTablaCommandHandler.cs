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
using VoleyPlaya.Organization.Application.Features.Equipos.Commands.AddEquipo;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Tablas.Commands.AddTabla
{
    public class AddTablaCommandHandler : IRequestHandler<AddTablaCommand, TablaDto>
    {
        private readonly IUnitOfWorkOrganization _unitOfWork;
        private readonly IMapper _mapper;
        public AddTablaCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TablaDto> Handle(AddTablaCommand request, CancellationToken cancellationToken)
        {
            Tabla tabla = new Tabla() { Nombre = request.Nombre, Equipo1=request.Equipo1, Equipo2=request.Equipo2, Ronda=request.Ronda };
            if (await _unitOfWork.TablaRepository.ExistsAsync(c => c.Nombre.Equals(request.Nombre)))
                throw new GenericDomainException("Ya existe una tabla con el nombre " + request.Nombre);

            tabla = await _unitOfWork.TablaRepository.AddAsync(tabla);
            return _mapper.Map<TablaDto>(tabla);
        }
    }
}