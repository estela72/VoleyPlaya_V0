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

namespace VoleyPlaya.Management.Application.Features.Jornadas.Commands.DeleteJornada
{
    public class DeleteJornadaCommandHandler : IRequestHandler<DeleteJornadaCommand, bool>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteJornadaCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteJornadaCommand request, CancellationToken cancellationToken)
        {
            Jornada edicion = await _unitOfWork.JornadaRepository.GetByIdAsync(request.Id);
            if (edicion == null)
                throw new GenericDomainException("La edición no existe");

            return await _unitOfWork.JornadaRepository.DeleteAsync(edicion);
        }
    }
}
