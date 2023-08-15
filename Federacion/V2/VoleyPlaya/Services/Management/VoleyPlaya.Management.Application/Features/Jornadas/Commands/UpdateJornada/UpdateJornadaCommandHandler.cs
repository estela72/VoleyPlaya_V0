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

namespace VoleyPlaya.Management.Application.Features.Jornadas.Commands.UpdateJornada
{
    public class UpdateJornadaCommandHandler : IRequestHandler<UpdateJornadaCommand, JornadaDto>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateJornadaCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<JornadaDto> Handle(UpdateJornadaCommand request, CancellationToken cancellationToken)
        {
            Jornada edicion = await _unitOfWork.JornadaRepository.GetByIdAsync(request.Id);
            if (edicion == null)
                throw new GenericDomainException("La edición no existe");

            edicion.Nombre = request.Nombre;
            edicion = await _unitOfWork.JornadaRepository.UpdateAsync(edicion);
            return _mapper.Map<JornadaDto>(edicion);
        }
    }
}