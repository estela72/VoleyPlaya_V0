using AutoMapper;

using GenericLib;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Application.Features.EdicionGrupos.Commands.DeleteEdicionGrupo
{
    public class DeleteEdicionGrupoCommandHandler : IRequestHandler<DeleteEdicionGrupoCommand, bool>
    {
        private readonly IUnitOfWorkManagement _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteEdicionGrupoCommandHandler(IUnitOfWorkManagement unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteEdicionGrupoCommand request, CancellationToken cancellationToken)
        {
            EdicionGrupo edicionGrupo = await _unitOfWork.EdicionGrupoRepository.GetByIdAsync(request.Id);
            if (edicionGrupo == null)
                throw new GenericDomainException("La edición no existe");

            return await _unitOfWork.EdicionGrupoRepository.DeleteAsync(edicionGrupo);
        }
    }
}
