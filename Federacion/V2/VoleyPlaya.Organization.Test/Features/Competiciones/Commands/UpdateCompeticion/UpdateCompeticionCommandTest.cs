using AutoMapper;

using GenericLib;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.UpdateCategoria;
using VoleyPlaya.Organization.Application.Features.Competiciones.Commands.UpdateCompeticion;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Competiciones.Commands.UpdateCompeticion
{
    public class UpdateCompeticionCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public UpdateCompeticionCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task UpdateExistentCompeticion()
        {
            var existente = (await _unitOfWork.Object.CompeticionRepository.GetAllAsync()).FirstOrDefault();

            var handler = new UpdateCompeticionCommandHandler(_unitOfWork.Object, _mapper);
            var request = new UpdateCompeticionCommand();
            request.Id = existente.Id;
            request.Nombre = existente.Nombre + "_modificado";
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.Equal(existente.Nombre, result.Nombre);
        }
        [Fact]
        public async Task UpdateNonExistentCompeticion()
        {
            var existente = (await _unitOfWork.Object.CompeticionRepository.GetAllAsync()).FirstOrDefault();

            var handler = new UpdateCompeticionCommandHandler(_unitOfWork.Object, _mapper);
            var request = new UpdateCompeticionCommand();
            request.Nombre = existente.Nombre + "_modificado";
            request.Id = 444;
            await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
