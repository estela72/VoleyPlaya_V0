using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.EdicionGrupos.Queries.GetEdicionesGrupo
{
    public class GetEdicionesGrupoQueryHandler : IRequestHandler<GetEdicionesGrupoQuery, IList<EdicionGrupoDto>>
    {
        private readonly IEdicionGrupoRepository _edicionGrupoRepository;
        private readonly IMapper _mapper;

        public GetEdicionesGrupoQueryHandler(IEdicionGrupoRepository edicionGrupoRepository, IMapper mapper)
        {
            _edicionGrupoRepository = edicionGrupoRepository;
            _mapper = mapper;
        }

        public async Task<IList<EdicionGrupoDto>> Handle(GetEdicionesGrupoQuery request, CancellationToken cancellationToken)
        {
            var edicionGrupoes = await _edicionGrupoRepository.GetAllAsync();
            return _mapper.Map<IList<EdicionGrupoDto>>(edicionGrupoes);
        }
    }
}
