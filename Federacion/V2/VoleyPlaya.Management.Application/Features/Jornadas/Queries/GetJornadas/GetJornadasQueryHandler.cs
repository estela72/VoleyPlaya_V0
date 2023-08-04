using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Jornadas.Queries.GetJornadaes
{
    public class GetJornadasQueryHandler : IRequestHandler<GetJornadasQuery, IList<JornadaDto>>
    {
        private readonly IJornadaRepository _jornadaRepository;
        private readonly IMapper _mapper;

        public GetJornadasQueryHandler(IJornadaRepository jornadaRepository, IMapper mapper)
        {
            _jornadaRepository = jornadaRepository;
            _mapper = mapper;
        }

        public async Task<IList<JornadaDto>> Handle(GetJornadasQuery request, CancellationToken cancellationToken)
        {
            var jornadaes = await _jornadaRepository.GetAllAsync();
            return _mapper.Map<IList<JornadaDto>>(jornadaes);
        }
    }
}
