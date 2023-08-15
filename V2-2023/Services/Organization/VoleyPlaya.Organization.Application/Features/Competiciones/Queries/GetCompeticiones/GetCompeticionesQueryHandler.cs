using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategorias;

namespace VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticiones
{
    public class GetCompeticionesQueryHandler : IRequestHandler<GetCompeticionesQuery, IList<CompeticionDto>>
    {
        private readonly ICompeticionRepository _competicionRepository;
        private readonly IMapper _mapper;

        public GetCompeticionesQueryHandler(ICompeticionRepository competicionRepository, IMapper mapper)
        {
            _competicionRepository = competicionRepository;
            _mapper = mapper;
        }

        public async Task<IList<CompeticionDto>> Handle(GetCompeticionesQuery request, CancellationToken cancellationToken)
        {
            var competiciones = await _competicionRepository.GetAllAsync();
            return _mapper.Map<IList<CompeticionDto>>(competiciones);
        }
    }
}
