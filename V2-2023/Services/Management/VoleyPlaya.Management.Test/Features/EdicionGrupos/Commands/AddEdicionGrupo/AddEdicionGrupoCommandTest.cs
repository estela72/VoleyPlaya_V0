using AutoMapper;

using Common.Application.Exceptions;

using Moq;

using VoleyPlaya.Management.Application.Features.EdicionGrupos.Commands.AddEdicionGrupo;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.EdicionGrupos.Commands.AddEdicionGrupo;

public class AddEdicionGrupoCommandTest
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public AddEdicionGrupoCommandTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task AddEdicionGrupoNew()
    {
        var handler = new AddEdicionGrupoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new AddEdicionGrupoCommand();
        request.Nombre = "EdicionGrupo-Nombre";
        request.EdicionId = 111;
        request.Fase = Domain.Enums.FaseEdicionGrupo.Liga;
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
    }
    [Fact]
    public async Task AddEdicionGrupoExistent()
    {
        var existente = (await _unitOfWork.Object.EdicionGrupoRepository.GetAllAsync()).FirstOrDefault();

        var handler = new AddEdicionGrupoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new AddEdicionGrupoCommand();
        request.Nombre = existente.Nombre;
        request.EdicionId = existente.EdicionId;

        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
