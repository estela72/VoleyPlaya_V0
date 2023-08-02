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
using VoleyPlaya.Organization.Application.Features.Temporadas.Queries.GetTemporada;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Repositories;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Temporadas.Queries.GetTemporada
{
    public class GetTemporadaQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        public GetTemporadaQueryTest()
        {
            _unitOfWork = new MockUnitOfWork().GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetTemporadaExistent()
        {
            var handler = new GetTemporadaQueryHandler(_unitOfWork.Object.TemporadaRepository, _mapper);
            var idExistent = (await _unitOfWork.Object.TemporadaRepository.GetAllAsync()).FirstOrDefault().Id;

            var request = new GetTemporadaQuery(idExistent);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal(result.Id, idExistent);
        }
        [Fact]
        public async Task GetTemporadaNotExistent()
        {
            var handler = new GetTemporadaQueryHandler(_unitOfWork.Object.TemporadaRepository, _mapper);
            var request = new GetTemporadaQuery(33);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.Null(result);
        }
    }
}
