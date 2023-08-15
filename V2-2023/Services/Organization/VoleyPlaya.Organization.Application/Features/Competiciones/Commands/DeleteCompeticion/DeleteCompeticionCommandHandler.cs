using AutoMapper;

using Common.Application.Exceptions;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.DeleteCategoria;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Competiciones.Commands.DeleteCompeticion
{
    public class DeleteCompeticionCommandHandler : IRequestHandler<DeleteCompeticionCommand, bool>
    {
        private readonly IUnitOfWorkOrganization _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteCompeticionCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteCompeticionCommand request, CancellationToken cancellationToken)
        {
            Competicion competicion = await _unitOfWork.CompeticionRepository.GetByIdAsync(request.Id);
            if (competicion == null)
                throw new GenericDomainException("La competición no existe");

            return await _unitOfWork.CompeticionRepository.DeleteAsync(competicion);
        }
    }
}
