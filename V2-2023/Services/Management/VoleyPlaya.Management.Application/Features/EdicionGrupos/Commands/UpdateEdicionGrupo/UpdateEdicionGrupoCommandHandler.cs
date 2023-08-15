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

namespace VoleyPlaya.Management.Application.Features.EdicionGrupos.Commands.UpdateEdicionGrupo
{
    public class UpdateEdicionGrupoCommandHandler : IRequestHandler<UpdateEdicionGrupoCommand, EdicionGrupoDto>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateEdicionGrupoCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EdicionGrupoDto> Handle(UpdateEdicionGrupoCommand request, CancellationToken cancellationToken)
        {
            EdicionGrupo edicionGrupo = await _unitOfWork.EdicionGrupoRepository.GetByIdAsync(request.Id);
            if (edicionGrupo == null)
                throw new GenericDomainException("La edición no existe");

            edicionGrupo.Nombre = request.Nombre;
            edicionGrupo = await _unitOfWork.EdicionGrupoRepository.UpdateAsync(edicionGrupo);
            return _mapper.Map<EdicionGrupoDto>(edicionGrupo);
        }
    }
}