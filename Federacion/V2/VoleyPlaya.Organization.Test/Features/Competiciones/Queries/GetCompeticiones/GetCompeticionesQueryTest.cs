using AutoMapper;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategorias;
using VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticiones;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Competiciones.Queries.GetCompeticiones
{
    public class GetCompeticionesQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public GetCompeticionesQueryTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCompeticiones()
        {
            var handler = new GetCompeticionesQueryHandler(_unitOfWork.Object.CompeticionRepository, _mapper);
            var request = new GetCompeticionesQuery();
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.IsAssignableFrom<IList<CompeticionDto>>(result);
            Assert.Equal(result.Count, 5);
        }
    }
}
