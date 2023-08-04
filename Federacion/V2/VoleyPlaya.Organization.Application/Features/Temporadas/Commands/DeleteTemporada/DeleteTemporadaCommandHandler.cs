using AutoMapper;

using GenericLib;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.Features.Tablas.Commands.DeleteTabla;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Temporadas.Commands.DeleteTemporada
{
    public class DeleteTemporadaCommandHandler : IRequestHandler<DeleteTemporadaCommand, bool>
    {
        private readonly IUnitOfWorkOrganization _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteTemporadaCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteTemporadaCommand request, CancellationToken cancellationToken)
        {
            Temporada temporada = await _unitOfWork.TemporadaRepository.GetByIdAsync(request.Id);
            if (temporada == null)
                throw new GenericDomainException("La temporada no existe");

            return await _unitOfWork.TemporadaRepository.DeleteAsync(temporada);
        }
    }
}
