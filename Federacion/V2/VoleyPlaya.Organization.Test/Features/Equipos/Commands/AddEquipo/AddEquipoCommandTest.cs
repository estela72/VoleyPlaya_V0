using AutoMapper;

using Common.Application.Exceptions;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Equipos.Commands.AddEquipo;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Equipos.Commands.AddEquipo
{
    public class AddEquipoCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public AddEquipoCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddEquipoNew()
        {
            var handler = new AddEquipoCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AddEquipoCommand();
            request.Nombre = "Equipo-New";
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal("Equipo-New", result.Nombre);
        }
        [Fact]
        public async Task AddEquipoExistent()
        {
            var existente = (await _unitOfWork.Object.EquipoRepository.GetAllAsync()).FirstOrDefault();

            var handler = new AddEquipoCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AddEquipoCommand();
            request.Nombre = existente.Nombre;
            await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
