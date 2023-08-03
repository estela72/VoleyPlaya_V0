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
using VoleyPlaya.Organization.Application.Features.Competiciones.Commands.UpdateCompeticion;
using VoleyPlaya.Organization.Application.Features.Temporadas.Commands.UpdateTemporada;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Temporadas.Commands.UpdateTemporada
{
    public class UpdateTemporadaCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public UpdateTemporadaCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task UpdateExistentTemporada()
        {
            var existente = (await _unitOfWork.Object.TemporadaRepository.GetAllAsync()).FirstOrDefault();

            var handler = new UpdateTemporadaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new UpdateTemporadaCommand();
            request.Id = existente.Id;
            request.Nombre = existente.Nombre + "_modificado";
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.Equal(existente.Nombre, result.Nombre);
        }
        [Fact]
        public async Task UpdateNonExistentTemporada()
        {
            var existente = (await _unitOfWork.Object.TemporadaRepository.GetAllAsync()).FirstOrDefault();

            var handler = new UpdateTemporadaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new UpdateTemporadaCommand();
            request.Nombre = existente.Nombre + "_modificado";
            request.Id = 444;
            await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
