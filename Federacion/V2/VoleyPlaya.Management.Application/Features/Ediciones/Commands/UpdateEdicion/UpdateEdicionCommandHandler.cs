using AutoMapper;

using GenericLib;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Application.Features.Ediciones.Commands.UpdateEdicion
{
    public class UpdateEdicionCommandHandler : IRequestHandler<UpdateEdicionCommand, EdicionDto>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateEdicionCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EdicionDto> Handle(UpdateEdicionCommand request, CancellationToken cancellationToken)
        {
            Edicion edicion = await _unitOfWork.EdicionRepository.GetByIdAsync(request.Id);
            if (edicion == null)
                throw new GenericDomainException("La edición no existe");

            edicion.Nombre = request.Nombre;
            edicion = await _unitOfWork.EdicionRepository.UpdateAsync(edicion);
            return _mapper.Map<EdicionDto>(edicion);
        }
    }
}