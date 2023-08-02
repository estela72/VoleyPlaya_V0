using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticion;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Equipos.Queries.GetEquipo
{
    public class GetEquipoQueryHandler : IRequestHandler<GetEquipoQuery, EquipoDto?>
    {
        private readonly IEquipoRepository _equipoRepository;
        private readonly IMapper _mapper;

        public GetEquipoQueryHandler(IEquipoRepository equipoRepository, IMapper mapper)
        {
            _equipoRepository = equipoRepository;
            _mapper = mapper;
        }

        public async Task<EquipoDto?> Handle(GetEquipoQuery request, CancellationToken cancellationToken)
        {
            Equipo? equipo = await _equipoRepository.GetByIdAsync(request.Id);
            if (equipo == null) return null;
            return _mapper.Map<EquipoDto>(equipo);
        }
    }
}
