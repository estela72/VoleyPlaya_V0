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

namespace VoleyPlaya.Organization.Application.Features.Competiciones.Commands.UpdateCompeticion
{
    public class UpdateCompeticionCommandHandler : IRequestHandler<UpdateCompeticionCommand, CompeticionDto>
    {
        private readonly IUnitOfWorkOrganization _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCompeticionCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CompeticionDto> Handle(UpdateCompeticionCommand request, CancellationToken cancellationToken)
        {
            Competicion competicion = await _unitOfWork.CompeticionRepository.GetByIdAsync(request.Id);
            if (competicion == null)
                throw new GenericDomainException("La competición no existe");

            competicion.Nombre = request.Nombre;
            competicion = await _unitOfWork.CompeticionRepository.UpdateAsync(competicion);
            return _mapper.Map<CompeticionDto>(competicion);
        }
    }
}
