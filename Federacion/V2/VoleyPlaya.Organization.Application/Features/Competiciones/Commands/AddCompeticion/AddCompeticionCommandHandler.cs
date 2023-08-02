using AutoMapper;
using GenericLib;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.AddCategoria;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Application.Features.Competiciones.Commands.AddCompeticion
{
    public class AddCompeticionCommandHandler : IRequestHandler<AddCompeticionCommand, CompeticionDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddCompeticionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CompeticionDto> Handle(AddCompeticionCommand request, CancellationToken cancellationToken)
        {
            Competicion competicion = new Competicion() { Nombre = request.Nombre };
            if (await _unitOfWork.CompeticionRepository.ExistsAsync(c => c.Nombre.Equals(request.Nombre)))
                throw new VoleyPlayaDomainException("Ya existe una competición con el nombre " + request.Nombre);

            competicion = await _unitOfWork.CompeticionRepository.AddAsync(competicion);
            return _mapper.Map<CompeticionDto>(competicion);
        }
    }
}
