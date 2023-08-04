using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Partidos.Queries.GetPartidoes
{
    public class GetPartidosQueryHandler : IRequestHandler<GetPartidosQuery, IList<PartidoDto>>
    {
        private readonly IPartidoRepository _partidoRepository;
        private readonly IMapper _mapper;

        public GetPartidosQueryHandler(IPartidoRepository partidoRepository, IMapper mapper)
        {
            _partidoRepository = partidoRepository;
            _mapper = mapper;
        }

        public async Task<IList<PartidoDto>> Handle(GetPartidosQuery request, CancellationToken cancellationToken)
        {
            var partidoes = await _partidoRepository.GetAllAsync();
            return _mapper.Map<IList<PartidoDto>>(partidoes);
        }
    }
}
