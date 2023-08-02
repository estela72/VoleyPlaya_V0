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
using VoleyPlaya.Organization.Application.Features.Equipos.Commands.DeleteEquipo;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Repositories;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Equipos.Commands.DeleteEquipo
{
    public class DeleteEquipoCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        public DeleteEquipoCommandTest()
        {
            _unitOfWork = new MockUnitOfWork().GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeleteExistentEquipo()
        {
            var existente = (await _unitOfWork.Object.EquipoRepository.GetAllAsync()).FirstOrDefault();

            var handler = new DeleteEquipoCommandHandler(_unitOfWork.Object, _mapper);
            var request = new DeleteEquipoCommand();
            request.Id = existente.Id;
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }
        [Fact]
        public async Task DeleteNonExistentEquipo()
        {
            var handler = new DeleteEquipoCommandHandler(_unitOfWork.Object, _mapper);
            var request = new DeleteEquipoCommand();
            request.Id = 444;
            await Assert.ThrowsAsync<VoleyPlayaDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
