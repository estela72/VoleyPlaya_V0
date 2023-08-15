using AutoMapper;

using Moq;

using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.Jornadas.Queries.GetJornadaes;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Jornadas.Queries.GetJornadas;

public class GetJornadasQueryTest 
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public GetJornadasQueryTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }     

    [Fact]
    public async Task GetJornadas()
    {
        var handler = new GetJornadasQueryHandler(_unitOfWork.Object.JornadaRepository, _mapper);
        var request = new GetJornadasQuery();
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.IsAssignableFrom<IList<JornadaDto>>(result);
        Assert.Equal(60,result.Count);
    }
}
