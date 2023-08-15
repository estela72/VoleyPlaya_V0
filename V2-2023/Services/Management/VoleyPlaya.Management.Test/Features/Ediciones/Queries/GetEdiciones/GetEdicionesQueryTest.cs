using AutoMapper;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.Ediciones.Queries.GetEdiciones;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Ediciones.Queries
{
    public class GetEdicionGruposQueryTest 
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkManagement> _unitOfWork;
        public GetEdicionGruposQueryTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }     

        [Fact]
        public async Task GetEdiciones()
        {
            var handler = new GetEdicionesQueryHandler(_unitOfWork.Object.EdicionRepository, _mapper);
            var request = new GetEdicionesQuery();
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.IsAssignableFrom<IList<EdicionDto>>(result);
            Assert.Equal(result.Count, 5);
        }
    }
}
