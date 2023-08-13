using AutoMapper;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticiones;
using VoleyPlaya.Organization.Application.Features.Temporadas.Queries.GetTemporadas;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Temporadas.Queries.GetTemporadas
{
    public class GetTemporadasQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public GetTemporadasQueryTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetTemporadas()
        {
            var handler = new GetTemporadasQueryHandler(_unitOfWork.Object.TemporadaRepository, _mapper);
            var request = new GetTemporadasQuery();
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.IsAssignableFrom<IList<TemporadaDto>>(result);
            Assert.Equal(result.Count, 5);
        }
    }
}