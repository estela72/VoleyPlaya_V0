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

namespace VoleyPlaya.Management.Application.Features.Ediciones.Queries.GetEdicion
{
    public class GetEdicionQueryHandler : IRequestHandler<GetEdicionQuery, EdicionDto?>
    {
        private readonly IEdicionRepository _edicionRepository;
        private readonly IMapper _mapper;

        public GetEdicionQueryHandler(IEdicionRepository edicionRepository, IMapper mapper)
        {
            _edicionRepository = edicionRepository;
            _mapper = mapper;
        }

        public async Task<EdicionDto?> Handle(GetEdicionQuery request, CancellationToken cancellationToken)
        {
            Edicion? edicion = await _edicionRepository.GetByIdAsync(request.EdicionId);
            if (edicion == null) return null;
            return _mapper.Map<EdicionDto>(edicion);
        }
    }
}
