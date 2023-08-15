using AutoMapper;

using Moq;

using VoleyPlaya.Management.Application.Features.Partidos.Queries.GetPartido;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Partidos.Queries.GetPartido;

public class GetPartidoQueryTest 
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public GetPartidoQueryTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }
    [Fact]
    public async Task GetPartidoExistent()
    {
        var handler = new GetPartidoQueryHandler(_unitOfWork.Object.PartidoRepository, _mapper);
        var idExistent = (await _unitOfWork.Object.PartidoRepository.GetAllAsync()).FirstOrDefault().Id;

        var request = new GetPartidoQuery(idExistent);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal(result.Id, idExistent);
        //Assert.Equal(result.Nombre, "Partido-"+ idExistent);
    }
    [Fact]
    public async Task GetPartidoNotExistent()
    {
        var handler = new GetPartidoQueryHandler(_unitOfWork.Object.PartidoRepository, _mapper);
        var request = new GetPartidoQuery(999);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.Null(result);
    }
}
