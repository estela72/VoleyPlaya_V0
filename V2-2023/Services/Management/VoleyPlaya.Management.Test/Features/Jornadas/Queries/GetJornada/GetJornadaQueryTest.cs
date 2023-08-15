using AutoMapper;

using Moq;

using VoleyPlaya.Management.Application.Features.Jornadas.Queries.GetJornada;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Jornadas.Queries.GetJornada;

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
    public async Task GetJornadaExistent()
    {
        var handler = new GetJornadaQueryHandler(_unitOfWork.Object.JornadaRepository, _mapper);
        var idExistent = (await _unitOfWork.Object.JornadaRepository.GetAllAsync()).FirstOrDefault().Id;

        var request = new GetJornadaQuery(idExistent);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal(result.Id, idExistent);
        //Assert.Equal(result.Nombre, "Jornada-"+ idExistent);
    }
    [Fact]
    public async Task GetJornadaNotExistent()
    {
        var handler = new GetJornadaQueryHandler(_unitOfWork.Object.JornadaRepository, _mapper);
        var request = new GetJornadaQuery(999);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.Null(result);
    }
}
