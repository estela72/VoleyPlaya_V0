using AutoMapper;


using Common.Application.Exceptions;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Application.Features.Partidos.Commands.AddPartido
{
    public class AddPartidoCommandHandler : IRequestHandler<AddPartidoCommand, PartidoDto>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public AddPartidoCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PartidoDto> Handle(AddPartidoCommand request, CancellationToken cancellationToken)
        {
            Partido partido = new Partido() { Label = request.Nombre };
            if (await _unitOfWork.PartidoRepository.ExistsAsync(c => c.Label.Equals(request.Nombre)))
                throw new GenericDomainException("Ya existe un partido con el nombre " + request.Nombre);

            partido = await _unitOfWork.PartidoRepository.AddAsync(partido);
            return _mapper.Map<PartidoDto>(partido);
        }
    }
}
