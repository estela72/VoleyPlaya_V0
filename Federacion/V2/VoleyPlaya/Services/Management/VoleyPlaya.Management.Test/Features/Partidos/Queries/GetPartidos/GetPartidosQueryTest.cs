using AutoMapper;

using Moq;

using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.Partidos.Queries.GetPartidoes;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Partidos.Queries.GetPartidos;

public class GetPartidosQueryTest 
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public GetPartidosQueryTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }     

    [Fact]
    public async Task GetPartidos()
    {
        var handler = new GetPartidosQueryHandler(_unitOfWork.Object.PartidoRepository, _mapper);
        var request = new GetPartidosQuery();
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.IsAssignableFrom<IList<PartidoDto>>(result);
        Assert.Equal(45,result.Count);
    }
}
