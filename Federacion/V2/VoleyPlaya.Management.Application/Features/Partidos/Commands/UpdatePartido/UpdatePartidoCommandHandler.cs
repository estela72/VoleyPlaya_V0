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

namespace VoleyPlaya.Management.Application.Features.Partidos.Commands.UpdatePartido
{
    public class UpdatePartidoCommandHandler : IRequestHandler<UpdatePartidoCommand, PartidoDto>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public UpdatePartidoCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PartidoDto> Handle(UpdatePartidoCommand request, CancellationToken cancellationToken)
        {
            Partido partido = await _unitOfWork.PartidoRepository.GetByIdAsync(request.Id);
            if (partido == null)
                throw new GenericDomainException("El partido no existe");

            partido = await _unitOfWork.PartidoRepository.UpdateAsync(partido);
            return _mapper.Map<PartidoDto>(partido);
        }
    }
}