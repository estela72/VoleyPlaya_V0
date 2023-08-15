using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;

using VoleyPlaya.Organization.Application.Features.Tablas.Queries.GetTabla;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Temporadas.Queries.GetTemporada
{
    public class GetTemporadaQueryHandler : IRequestHandler<GetTemporadaQuery, TemporadaDto?>
    {
        private readonly ITemporadaRepository _tempoaradaRepository;
        private readonly IMapper _mapper;

        public GetTemporadaQueryHandler(ITemporadaRepository temporadaRepository, IMapper mapper)
        {
            _tempoaradaRepository = temporadaRepository;
            _mapper = mapper;
        }

        public async Task<TemporadaDto?> Handle(GetTemporadaQuery request, CancellationToken cancellationToken)
        {
            Temporada? temporada = await _tempoaradaRepository.GetByIdAsync(request.Id);
            if (temporada == null) return null;
            return _mapper.Map<TemporadaDto>(temporada);
        }
    }
}
