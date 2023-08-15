using AutoMapper;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategorias;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Categorias.Queries
{
    public class GetCategoriasQueryTest 
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public GetCategoriasQueryTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }     

        [Fact]
        public async Task GetCategorias()
        {
            var handler = new GetCategoriasQueryHandler(_unitOfWork.Object.CategoriaRepository, _mapper);
            var request = new GetCategoriasQuery();
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.IsAssignableFrom<IList<CategoriaDto>>(result);
            Assert.Equal(result.Count, 5);
        }
    }
}
