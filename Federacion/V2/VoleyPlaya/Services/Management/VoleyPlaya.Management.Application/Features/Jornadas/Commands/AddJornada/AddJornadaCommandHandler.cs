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
using VoleyPlaya.Management.Application.Features.Jornadas.Commands.AddJornada;
using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Application.Features.Jornadas.Commands.AddJornada
{
    public class AddJornadaCommandHandler : IRequestHandler<AddJornadaCommand, JornadaDto>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public AddJornadaCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<JornadaDto> Handle(AddJornadaCommand request, CancellationToken cancellationToken)
        {
            Jornada edicion = new Jornada() { Nombre = request.Nombre, Numero = request.Numero, Fecha=request.Fecha, EdicionId=request.EdicionId };
            if (await _unitOfWork.JornadaRepository.ExistsAsync(c => c.EdicionId.Equals(request.EdicionId) && c.Numero.Equals(request.Numero)))
                throw new GenericDomainException("Ya existe la jornada " + request.Numero + " para la edición "+request.EdicionId);

            edicion = await _unitOfWork.JornadaRepository.AddAsync(edicion);
            return _mapper.Map<JornadaDto>(edicion);
        }
    }
}
