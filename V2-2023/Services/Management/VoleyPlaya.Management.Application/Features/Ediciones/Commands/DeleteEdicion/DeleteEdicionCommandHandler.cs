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

namespace VoleyPlaya.Management.Application.Features.Ediciones.Commands.DeleteEdicion
{
    public class DeleteEdicionCommandHandler : IRequestHandler<DeleteEdicionCommand, bool>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteEdicionCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteEdicionCommand request, CancellationToken cancellationToken)
        {
            Edicion edicion = await _unitOfWork.EdicionRepository.GetByIdAsync(request.Id);
            if (edicion == null)
                throw new GenericDomainException("La edición no existe");

            return await _unitOfWork.EdicionRepository.DeleteAsync(edicion);
        }
    }
}
