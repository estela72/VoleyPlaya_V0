using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Equipos.Queries.GetEquipos;

namespace VoleyPlaya.Organization.Application.Features.Tablas.Queries.GetTablas
{
    public class GetTablasQueryHandler : IRequestHandler<GetTablasQuery, IList<TablaDto>>
    {
        private readonly ITablaRepository _tablaRepository;
        private readonly IMapper _mapper;

        public GetTablasQueryHandler(ITablaRepository tablaRepository, IMapper mapper)
        {
            _tablaRepository = tablaRepository;
            _mapper = mapper;
        }

        public async Task<IList<TablaDto>> Handle(GetTablasQuery request, CancellationToken cancellationToken)
        {
            var tablas = await _tablaRepository.GetAllAsync();
            return _mapper.Map<IList<TablaDto>>(tablas);
        }
    }
}
