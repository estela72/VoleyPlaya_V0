using AutoMapper;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategoria;
using VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticion;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Competiciones.Queries.GetCompeticion
{
    public class GetCompeticionQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public GetCompeticionQueryTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetCompeticionExistent()
        {
            var handler = new GetCompeticionQueryHandler(_unitOfWork.Object.CompeticionRepository, _mapper);
            var idExistent = (await _unitOfWork.Object.CompeticionRepository.GetAllAsync()).FirstOrDefault().Id;

            var request = new GetCompeticionQuery(idExistent);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal(result.Id, idExistent);
        }
        [Fact]
        public async Task GetCompeticionNotExistent()
        {
            var handler = new GetCompeticionQueryHandler(_unitOfWork.Object.CompeticionRepository, _mapper);
            var request = new GetCompeticionQuery(999);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.Null(result);
        }
    }
}
