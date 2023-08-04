using AutoMapper;

using GenericLib;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.Features.Competiciones.Commands.DeleteCompeticion;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Equipos.Commands.DeleteEquipo
{
    public class DeleteEquipoCommandHandler : IRequestHandler<DeleteEquipoCommand, bool>
    {
        private readonly IUnitOfWorkOrganization _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteEquipoCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteEquipoCommand request, CancellationToken cancellationToken)
        {
            Equipo equipo = await _unitOfWork.EquipoRepository.GetByIdAsync(request.Id);
            if (equipo == null)
                throw new GenericDomainException("El equipo no existe");

            return await _unitOfWork.EquipoRepository.DeleteAsync(equipo);
        }
    }
}
