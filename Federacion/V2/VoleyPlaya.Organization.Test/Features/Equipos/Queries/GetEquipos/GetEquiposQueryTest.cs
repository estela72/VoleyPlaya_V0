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
using VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticiones;
using VoleyPlaya.Organization.Application.Features.Equipos.Queries.GetEquipos;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Equipos.Queries.GetEquipos
{
    public class GetEquiposQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public GetEquiposQueryTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetEquipos()
        {
            var handler = new GetEquiposQueryHandler(_unitOfWork.Object.EquipoRepository, _mapper);
            var request = new GetEquiposQuery();
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.IsAssignableFrom<IList<EquipoDto>>(result);
            Assert.Equal(result.Count, 5);
        }
    }
}