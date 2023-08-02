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
using VoleyPlaya.Organization.Application.Features.Temporadas.Commands.AddTemporada;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Repositories;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Temporadas.Commands.AddTemporada
{
    public class AddTemporadaCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        public AddTemporadaCommandTest()
        {
            _unitOfWork = new MockUnitOfWork().GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddTemporadaNew()
        {
            var handler = new AddTemporadaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AddTemporadaCommand();
            request.Nombre = "Temporada-New";
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal("Temporada-New", result.Nombre);
        }
        [Fact]
        public async Task AddTemporadaExistent()
        {
            var existente = (await _unitOfWork.Object.TemporadaRepository.GetAllAsync()).FirstOrDefault();

            var handler = new AddTemporadaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AddTemporadaCommand();
            request.Nombre = existente.Nombre;
            await Assert.ThrowsAsync<VoleyPlayaDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
