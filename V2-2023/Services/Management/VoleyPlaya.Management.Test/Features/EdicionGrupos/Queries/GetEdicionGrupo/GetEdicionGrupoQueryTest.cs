using AutoMapper;

using Moq;

using VoleyPlaya.Management.Application.Features.EdicionGrupos.Queries.GetEdicionGrupo;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.EdicionGrupos.Queries.GetEdicionGrupo;

public class GetEdicionGrupoQueryTest 
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public GetEdicionGrupoQueryTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }
    [Fact]
    public async Task GetEdicionGrupoExistent()
    {
        var handler = new GetEdicionGrupoQueryHandler(_unitOfWork.Object.EdicionGrupoRepository, _mapper);
        var idExistent = (await _unitOfWork.Object.EdicionGrupoRepository.GetAllAsync()).FirstOrDefault().Id;

        var request = new GetEdicionGrupoQuery(idExistent);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal(result.Id, idExistent);
        //Assert.Equal(result.Nombre, "EdicionGrupo-"+ idExistent);
    }
    [Fact]
    public async Task GetEdicionGrupoNotExistent()
    {
        var handler = new GetEdicionGrupoQueryHandler(_unitOfWork.Object.EdicionGrupoRepository, _mapper);
        var request = new GetEdicionGrupoQuery(999);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.Null(result);
    }
}
