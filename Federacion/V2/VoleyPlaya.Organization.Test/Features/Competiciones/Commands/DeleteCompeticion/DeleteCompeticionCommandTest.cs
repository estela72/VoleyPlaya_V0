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
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.DeleteCategoria;
using VoleyPlaya.Organization.Application.Features.Competiciones.Commands.DeleteCompeticion;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Competiciones.Commands.DeleteCompeticion
{
    public class DeleteCompeticionCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public DeleteCompeticionCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeleteExistentCompeticion()
        {
            var existente = (await _unitOfWork.Object.CompeticionRepository.GetAllAsync()).FirstOrDefault();

            var handler = new DeleteCompeticionCommandHandler(_unitOfWork.Object, _mapper);
            var request = new DeleteCompeticionCommand(existente.Id);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }
        [Fact]
        public async Task DeleteNonExistentCategoria()
        {
            var handler = new DeleteCompeticionCommandHandler(_unitOfWork.Object, _mapper);
            var request = new DeleteCompeticionCommand(555);
            request.Id = 444;
            await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
