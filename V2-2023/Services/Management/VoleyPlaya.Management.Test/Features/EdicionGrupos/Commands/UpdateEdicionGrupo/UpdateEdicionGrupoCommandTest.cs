using AutoMapper;

using Common.Application.Exceptions;

using Moq;

using VoleyPlaya.Management.Application.Features.EdicionGrupos.Commands.UpdateEdicionGrupo;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.EdicionGrupos.Commands.UpdateEdicionGrupo;

public class UpdateEdicionGrupoCommandTest 
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public UpdateEdicionGrupoCommandTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task UpdateExistentEdicionGrupo()
    {
        var existente = (await _unitOfWork.Object.EdicionGrupoRepository.GetAllAsync()).FirstOrDefault();

        var handler = new UpdateEdicionGrupoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new UpdateEdicionGrupoCommand();
        request.Id = existente.Id;
        request.Nombre = existente.Nombre+"_modificado";
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.Equal(existente.Nombre, result.Nombre);
    }
    [Fact]
    public async Task UpdateNonExistentEdicionGrupo()
    {
        var edicionExistente = (await _unitOfWork.Object.EdicionGrupoRepository.GetAllAsync()).FirstOrDefault();

        var handler = new UpdateEdicionGrupoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new UpdateEdicionGrupoCommand();
        request.Nombre = edicionExistente.Nombre + "_modificado";
        request.Id = 444;
        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
