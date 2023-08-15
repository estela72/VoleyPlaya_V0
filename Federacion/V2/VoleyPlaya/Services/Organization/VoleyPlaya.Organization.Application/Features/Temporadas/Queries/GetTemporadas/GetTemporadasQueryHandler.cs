using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;

using VoleyPlaya.Organization.Application.Features.Tablas.Queries.GetTablas;

namespace VoleyPlaya.Organization.Application.Features.Temporadas.Queries.GetTemporadas
{
    public class GetTemporadasQueryHandler : IRequestHandler<GetTemporadasQuery, IList<TemporadaDto>>
    {
        private readonly ITemporadaRepository _temoradaRepository;
        private readonly IMapper _mapper;

        public GetTemporadasQueryHandler(ITemporadaRepository temporadaRepository, IMapper mapper)
        {
            _temoradaRepository = temporadaRepository;
            _mapper = mapper;
        }

        public async Task<IList<TemporadaDto>> Handle(GetTemporadasQuery request, CancellationToken cancellationToken)
        {
            var temporadas = await _temoradaRepository.GetAllAsync();
            return _mapper.Map<IList<TemporadaDto>>(temporadas);
        }
    }
}
