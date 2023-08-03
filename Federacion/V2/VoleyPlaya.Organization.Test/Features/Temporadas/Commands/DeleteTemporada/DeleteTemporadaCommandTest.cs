using AutoMapper;

using GenericLib;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Features.Competiciones.Commands.DeleteCompeticion;
using VoleyPlaya.Organization.Application.Features.Temporadas.Commands.DeleteTemporada;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Temporadas.Commands.DeleteTemporada
{
    public class DeleteTemporadaCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public DeleteTemporadaCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeleteExistentTemporada()
        {
            var existente = (await _unitOfWork.Object.TemporadaRepository.GetAllAsync()).FirstOrDefault();

            var handler = new DeleteTemporadaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new DeleteTemporadaCommand(existente.Id);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }
        [Fact]
        public async Task DeleteNonExistentTemporada()
        {
            var handler = new DeleteTemporadaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new DeleteTemporadaCommand(888);
            await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
