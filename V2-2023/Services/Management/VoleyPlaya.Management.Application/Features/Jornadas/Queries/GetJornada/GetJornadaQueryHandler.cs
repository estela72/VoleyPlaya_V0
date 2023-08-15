using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Application.Features.Jornadas.Queries.GetJornada
{
    public class GetJornadaQueryHandler : IRequestHandler<GetJornadaQuery, JornadaDto?>
    {
        private readonly IJornadaRepository _jornadaRepository;
        private readonly IMapper _mapper;

        public GetJornadaQueryHandler(IJornadaRepository jornadaRepository, IMapper mapper)
        {
            _jornadaRepository = jornadaRepository;
            _mapper = mapper;
        }

        public async Task<JornadaDto?> Handle(GetJornadaQuery request, CancellationToken cancellationToken)
        {
            Jornada? jornada = await _jornadaRepository.GetByIdAsync(request.JornadaId);
            if (jornada == null) return null;
            return _mapper.Map<JornadaDto>(jornada);
        }
    }
}
