using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Equipos.Queries.GetEquipo;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Tablas.Queries.GetTabla
{
    public class GetTablaQueryHandler : IRequestHandler<GetTablaQuery, TablaDto?>
    {
        private readonly ITablaRepository _tablaRepository;
        private readonly IMapper _mapper;

        public GetTablaQueryHandler(ITablaRepository tablaRepository, IMapper mapper)
        {
            _tablaRepository = tablaRepository;
            _mapper = mapper;
        }

        public async Task<TablaDto?> Handle(GetTablaQuery request, CancellationToken cancellationToken)
        {
            Tabla? equipo = await _tablaRepository.GetByIdAsync(request.Id);
            if (equipo == null) return null;
            return _mapper.Map<TablaDto>(equipo);
        }
    }
}
