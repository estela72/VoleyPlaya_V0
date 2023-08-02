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
using VoleyPlaya.Organization.Application.Features.Tablas.Queries.GetTabla;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Repositories;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Tablas.Queries.GetTabla
{
    public class GetTablaQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        public GetTablaQueryTest()
        {
            _unitOfWork = new MockUnitOfWork().GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetTablaExistent()
        {
            var handler = new GetTablaQueryHandler(_unitOfWork.Object.TablaRepository, _mapper);
            var idExistent = (await _unitOfWork.Object.TablaRepository.GetAllAsync()).FirstOrDefault().Id;

            var request = new GetTablaQuery(idExistent);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal(result.Id, idExistent);
        }
        [Fact]
        public async Task GetTablaNotExistent()
        {
            var handler = new GetTablaQueryHandler(_unitOfWork.Object.TablaRepository, _mapper);
            var request = new GetTablaQuery(33);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.Null(result);
        }
    }
}
