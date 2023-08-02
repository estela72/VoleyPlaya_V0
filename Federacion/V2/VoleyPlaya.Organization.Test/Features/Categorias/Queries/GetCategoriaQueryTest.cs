using AutoMapper;
using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategoria;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategorias;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Repositories;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Categorias.Queries
{
    public class GetCategoriaQueryTest 
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        public GetCategoriaQueryTest()
        {
            _unitOfWork = new MockUnitOfWork().GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetCategoriaExistent()
        {
            var handler = new GetCategoriaQueryHandler(_unitOfWork.Object.CategoriaRepository, _mapper);
            var idExistent = (await _unitOfWork.Object.CategoriaRepository.GetAllAsync()).FirstOrDefault().Id;

            var request = new GetCategoriaQuery(idExistent);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal(result.Id, idExistent);
            //Assert.Equal(result.Nombre, "Categoria-"+ idExistent);
        }
        [Fact]
        public async Task GetCategoriaNotExistent()
        {
            var handler = new GetCategoriaQueryHandler(_unitOfWork.Object.CategoriaRepository, _mapper);
            var request = new GetCategoriaQuery(33);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.Null(result);
        }
    }
}
