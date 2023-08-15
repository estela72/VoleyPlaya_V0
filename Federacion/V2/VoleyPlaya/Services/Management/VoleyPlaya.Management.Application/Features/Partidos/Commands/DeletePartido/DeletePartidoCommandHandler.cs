using AutoMapper;


using Common.Application.Exceptions;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Application.Features.Partidos.Commands.DeletePartido
{
    public class DeletePartidoCommandHandler : IRequestHandler<DeletePartidoCommand, bool>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public DeletePartidoCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeletePartidoCommand request, CancellationToken cancellationToken)
        {
            Partido partido = await _unitOfWork.PartidoRepository.GetByIdAsync(request.Id);
            if (partido == null)
                throw new GenericDomainException("El partido no existe");

            return await _unitOfWork.PartidoRepository.DeleteAsync(partido);
        }
    }
}
