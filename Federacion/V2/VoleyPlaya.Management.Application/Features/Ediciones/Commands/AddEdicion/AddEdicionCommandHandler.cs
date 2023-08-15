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

namespace VoleyPlaya.Management.Application.Features.Ediciones.Commands.AddEdicion
{
    public class AddEdicionCommandHandler : IRequestHandler<AddEdicionCommand, EdicionDto>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public AddEdicionCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EdicionDto> Handle(AddEdicionCommand request, CancellationToken cancellationToken)
        {
            Edicion edicion = new Edicion() { Nombre = request.Nombre, Genero=request.Genero, Prueba=request.Prueba, Estado=request.Estado, ModeloCompeticion = request.Modelo,
                TemporadaId = request.TemporadaId, CompeticionId = request.CompeticionId, CategoriaId = request.CategoriaId};

            if (await _unitOfWork.EdicionRepository.ExistsAsync(c => c.Nombre.Equals(request.Nombre) && c.Genero.Equals(request.Genero) && c.Prueba.Equals(request.Prueba) &&
                c.TemporadaId.Equals(request.TemporadaId) && c.CompeticionId.Equals(request.CompeticionId) && c.CategoriaId.Equals(request.CategoriaId)))
                throw new GenericDomainException("Ya existe la edición que está intentando crear: " + request.Nombre);

            edicion = await _unitOfWork.EdicionRepository.AddAsync(edicion);
            return _mapper.Map<EdicionDto>(edicion);
        }
    }
}
