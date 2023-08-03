using AutoMapper;

using GenericLib;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.AddCategoria;
using VoleyPlaya.Organization.Application.Features.Competiciones.Commands.AddCompeticion;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Competiciones.Commands.AddCompeticion
{
    public class AddCompeticionCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public AddCompeticionCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddCompeticionNew()
        {
            var handler = new AddCompeticionCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AddCompeticionCommand();
            request.Nombre = "Competicion-New";
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal("Competicion-New", result.Nombre);
        }
        [Fact]
        public async Task AddCompeticionExistent()
        {
            var existente = (await _unitOfWork.Object.CompeticionRepository.GetAllAsync()).FirstOrDefault();

            var handler = new AddCompeticionCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AddCompeticionCommand();
            request.Nombre = existente.Nombre;
            await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
