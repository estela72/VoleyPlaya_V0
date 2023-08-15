using AutoMapper;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticion;
using VoleyPlaya.Organization.Application.Features.Equipos.Queries.GetEquipo;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Equipos.Queries.GetEquipo
{
    public class GetEquipoQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public GetEquipoQueryTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetEquipoExistent()
        {
            var handler = new GetEquipoQueryHandler(_unitOfWork.Object.EquipoRepository, _mapper);
            var idExistent = (await _unitOfWork.Object.EquipoRepository.GetAllAsync()).FirstOrDefault().Id;

            var request = new GetEquipoQuery(idExistent);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal(result.Id, idExistent);
        }
        [Fact]
        public async Task GetEquipoNotExistent()
        {
            var handler = new GetEquipoQueryHandler(_unitOfWork.Object.EquipoRepository, _mapper);
            var request = new GetEquipoQuery(999);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.Null(result);
        }
    }
}
