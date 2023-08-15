using AutoMapper;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.Ediciones.Queries.GetEdicion;
using VoleyPlaya.Management.Application.Features.Ediciones.Queries.GetEdiciones;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Ediciones.Queries.GetEdicion;

public class GetJornadaQueryTest 
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public GetJornadaQueryTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }
    [Fact]
    public async Task GetEdicionExistent()
    {
        var handler = new GetEdicionQueryHandler(_unitOfWork.Object.EdicionRepository, _mapper);
        var idExistent = (await _unitOfWork.Object.EdicionRepository.GetAllAsync()).FirstOrDefault().Id;

        var request = new GetEdicionQuery(idExistent);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal(result.Id, idExistent);
        //Assert.Equal(result.Nombre, "Edicion-"+ idExistent);
    }
    [Fact]
    public async Task GetEdicionNotExistent()
    {
        var handler = new GetEdicionQueryHandler(_unitOfWork.Object.EdicionRepository, _mapper);
        var request = new GetEdicionQuery(999);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.Null(result);
    }
}
