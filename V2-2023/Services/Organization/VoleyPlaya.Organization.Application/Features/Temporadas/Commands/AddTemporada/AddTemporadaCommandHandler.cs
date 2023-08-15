using AutoMapper;

using   Common.Application.Exceptions;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;

using VoleyPlaya.Organization.Application.Features.Tablas.Commands.AddTabla;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Temporadas.Commands.AddTemporada
{
    public class AddTemporadaCommandHandler : IRequestHandler<AddTemporadaCommand, TemporadaDto>
    {
        private readonly IUnitOfWorkOrganization _unitOfWork;
        private readonly IMapper _mapper;
        public AddTemporadaCommandHandler(IUnitOfWorkOrganization unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TemporadaDto> Handle(AddTemporadaCommand request, CancellationToken cancellationToken)
        {
            Temporada temporada = new Temporada() { Nombre = request.Nombre };
            if (await _unitOfWork.TemporadaRepository.ExistsAsync(c => c.Nombre.Equals(request.Nombre)))
                throw new GenericDomainException("Ya existe una temporada con el nombre " + request.Nombre);

            temporada = await _unitOfWork.TemporadaRepository.AddAsync(temporada);
            return _mapper.Map<TemporadaDto>(temporada);
        }
    }
}