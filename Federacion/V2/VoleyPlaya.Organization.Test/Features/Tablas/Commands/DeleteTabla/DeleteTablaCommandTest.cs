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
using VoleyPlaya.Organization.Application.Features.Tablas.Commands.DeleteTabla;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Tablas.Commands.DeleteTabla
{
    public class DeleteTablaCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public DeleteTablaCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeleteExistentTabla()
        {
            var existente = (await _unitOfWork.Object.TablaRepository.GetAllAsync()).FirstOrDefault();

            var handler = new DeleteTablaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new DeleteTablaCommand(existente.Id);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }
        [Fact]
        public async Task DeleteNonExistentTabla()
        {
            var handler = new DeleteTablaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new DeleteTablaCommand(777);
            await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
