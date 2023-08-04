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
            Edicion edicion = new Edicion() { Nombre = request.Nombre };
            if (await _unitOfWork.EdicionRepository.ExistsAsync(c => c.Nombre.Equals(request.Nombre)))
                throw new GenericDomainException("Ya existe una edición con el nombre " + request.Nombre);

            edicion = await _unitOfWork.EdicionRepository.AddAsync(edicion);
            return _mapper.Map<EdicionDto>(edicion);
        }
    }
}
