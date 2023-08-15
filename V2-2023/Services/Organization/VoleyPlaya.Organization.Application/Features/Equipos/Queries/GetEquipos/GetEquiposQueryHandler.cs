using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticiones;

namespace VoleyPlaya.Organization.Application.Features.Equipos.Queries.GetEquipos
{
    public class GetEquiposQueryHandler : IRequestHandler<GetEquiposQuery, IList<EquipoDto>>
    {
        private readonly IEquipoRepository _equipoRepository;
        private readonly IMapper _mapper;

        public GetEquiposQueryHandler(IEquipoRepository equipoRepository, IMapper mapper)
        {
            _equipoRepository = equipoRepository;
            _mapper = mapper;
        }

        public async Task<IList<EquipoDto>> Handle(GetEquiposQuery request, CancellationToken cancellationToken)
        {
            var equipos = await _equipoRepository.GetAllAsync();
            return _mapper.Map<IList<EquipoDto>>(equipos);
        }
    }
}
