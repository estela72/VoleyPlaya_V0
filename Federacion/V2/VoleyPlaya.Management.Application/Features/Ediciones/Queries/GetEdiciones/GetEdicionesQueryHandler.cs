using AutoMapper;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;

namespace VoleyPlaya.Management.Application.Features.Ediciones.Queries.GetEdiciones
{
    public class GetEdicionesQueryHandler : IRequestHandler<GetEdicionesQuery, IList<EdicionDto>>
    {
        private readonly IEdicionRepository _edicionRepository;
        private readonly IMapper _mapper;

        public GetEdicionesQueryHandler(IEdicionRepository edicionRepository, IMapper mapper)
        {
            _edicionRepository = edicionRepository;
            _mapper = mapper;
        }

        public async Task<IList<EdicionDto>> Handle(GetEdicionesQuery request, CancellationToken cancellationToken)
        {
            var ediciones = await _edicionRepository.GetAllAsync();
            return _mapper.Map<IList<EdicionDto>>(ediciones);
        }
    }
}
