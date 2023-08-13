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

using VoleyPlaya.Organization.Application.Features.Tablas.Commands.UpdateTabla;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Temporadas.Commands.UpdateTemporada
{
    public class UpdateTemporadaCommandHandler : IRequestHandler<UpdateTemporadaCommand, TemporadaDto>
    {
        private readonly IUnitOfWorkOrganization _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateTemporadaCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TemporadaDto> Handle(UpdateTemporadaCommand request, CancellationToken cancellationToken)
        {
            Temporada temporada = await _unitOfWork.TemporadaRepository.GetByIdAsync(request.Id);
            if (temporada == null)
                throw new GenericDomainException("La temporada no existe");

            temporada.Nombre = request.Nombre;
            temporada = await _unitOfWork.TemporadaRepository.UpdateAsync(temporada);
            return _mapper.Map<TemporadaDto>(temporada);
        }
    }
}