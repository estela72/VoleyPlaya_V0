using AutoMapper;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.EdicionGrupos.Queries.GetEdicionesGrupo;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.EdicionGrupos.Queries.GetEdicionesGrupo;

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
    public async Task GetEdicionGrupos()
    {
        var handler = new GetEdicionesGrupoQueryHandler(_unitOfWork.Object.EdicionGrupoRepository, _mapper);
        var request = new GetEdicionesGrupoQuery();
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.IsAssignableFrom<IList<EdicionGrupoDto>>(result);
        Assert.Equal(result.Count, 15);
    }
}
