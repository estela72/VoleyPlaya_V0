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

namespace VoleyPlaya.Management.Application.Features.EdicionGrupos.Commands.AddEdicionGrupo
{
    public class AddEdicionGrupoCommandHandler : IRequestHandler<AddEdicionGrupoCommand, EdicionGrupoDto>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public AddEdicionGrupoCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EdicionGrupoDto> Handle(AddEdicionGrupoCommand request, CancellationToken cancellationToken)
        {
            EdicionGrupo edicionGrupo = new EdicionGrupo() { Nombre = request.Nombre };
            if (await _unitOfWork.EdicionGrupoRepository.ExistsAsync(c => c.Nombre.Equals(request.Nombre)))
                throw new GenericDomainException("Ya existe una edición con el nombre " + request.Nombre);

            edicionGrupo = await _unitOfWork.EdicionGrupoRepository.AddAsync(edicionGrupo);
            return _mapper.Map<EdicionGrupoDto>(edicionGrupo);
        }
    }
}
