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

namespace VoleyPlaya.Management.Application.Features.EdicionGrupos.Queries.GetEdicionGrupo
{
    public class GetEdicionGrupoQueryHandler : IRequestHandler<GetEdicionGrupoQuery, EdicionGrupoDto?>
    {
        private readonly IEdicionGrupoRepository _edicionGrupoRepository;
        private readonly IMapper _mapper;

        public GetEdicionGrupoQueryHandler(IEdicionGrupoRepository edicionGrupoRepository, IMapper mapper)
        {
            _edicionGrupoRepository = edicionGrupoRepository;
            _mapper = mapper;
        }

        public async Task<EdicionGrupoDto?> Handle(GetEdicionGrupoQuery request, CancellationToken cancellationToken)
        {
            EdicionGrupo? edicionGrupo = await _edicionGrupoRepository.GetByIdAsync(request.EdicionGrupoId);
            if (edicionGrupo == null) return null;
            return _mapper.Map<EdicionGrupoDto>(edicionGrupo);
        }
    }
}
