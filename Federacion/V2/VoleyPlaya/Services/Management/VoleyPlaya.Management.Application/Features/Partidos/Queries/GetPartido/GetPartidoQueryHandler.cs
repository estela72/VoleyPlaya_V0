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

namespace VoleyPlaya.Management.Application.Features.Partidos.Queries.GetPartido
{
    public class GetPartidoQueryHandler : IRequestHandler<GetPartidoQuery, PartidoDto?>
    {
        private readonly IPartidoRepository _partidoRepository;
        private readonly IMapper _mapper;

        public GetPartidoQueryHandler(IPartidoRepository partidoRepository, IMapper mapper)
        {
            _partidoRepository = partidoRepository;
            _mapper = mapper;
        }

        public async Task<PartidoDto?> Handle(GetPartidoQuery request, CancellationToken cancellationToken)
        {
            Partido? partido = await _partidoRepository.GetByIdAsync(request.PartidoId);
            if (partido == null) return null;
            return _mapper.Map<PartidoDto>(partido);
        }
    }
}
