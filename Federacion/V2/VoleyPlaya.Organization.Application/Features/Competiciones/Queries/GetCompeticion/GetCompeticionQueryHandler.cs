using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategoria;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticion
{
    public class GetCompeticionQueryHandler : IRequestHandler<GetCompeticionQuery, CompeticionDto?>
    {
        private readonly ICompeticionRepository _competicionRepository;
        private readonly IMapper _mapper;

        public GetCompeticionQueryHandler(ICompeticionRepository competicionRepostitory, IMapper mapper)
        {
            _competicionRepository = competicionRepostitory;
            _mapper = mapper;
        }

        public async Task<CompeticionDto?> Handle(GetCompeticionQuery request, CancellationToken cancellationToken)
        {
            Competicion? competicion = await _competicionRepository.GetByIdAsync(request.Id);
            if (competicion == null) return null;
            return _mapper.Map<CompeticionDto>(competicion);
        }
    }
}
