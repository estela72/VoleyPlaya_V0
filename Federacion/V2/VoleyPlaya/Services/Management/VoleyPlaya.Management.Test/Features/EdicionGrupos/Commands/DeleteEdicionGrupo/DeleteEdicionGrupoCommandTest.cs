using AutoMapper;

using Common.Application.Exceptions;

using Moq;

using VoleyPlaya.Management.Application.Features.EdicionGrupos.Commands.DeleteEdicionGrupo;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.EdicionGrupos.Commands.DeleteEdicionGrupo;

public class DeleteEdicionGrupoCommandTest 
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public DeleteEdicionGrupoCommandTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task DeleteExistentEdicionGrupo()
    {
        var existente = (await _unitOfWork.Object.EdicionGrupoRepository.GetAllAsync()).FirstOrDefault();

        var handler = new DeleteEdicionGrupoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new DeleteEdicionGrupoCommand(existente.Id);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.True(result);
    }
    [Fact]
    public async Task DeleteNonExistentEdicionGrupo()
    {
        var handler = new DeleteEdicionGrupoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new DeleteEdicionGrupoCommand(999);
        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
