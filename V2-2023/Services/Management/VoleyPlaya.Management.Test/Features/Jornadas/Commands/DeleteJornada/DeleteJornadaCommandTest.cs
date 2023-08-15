using AutoMapper;

using Common.Application.Exceptions;

using Moq;

using VoleyPlaya.Management.Application.Features.Jornadas.Commands.DeleteJornada;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Jornadas.Commands.DeleteJornada;

public class DeleteJornadaCommandTest 
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public DeleteJornadaCommandTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task DeleteExistentJornada()
    {
        var existente = (await _unitOfWork.Object.JornadaRepository.GetAllAsync()).FirstOrDefault();

        var handler = new DeleteJornadaCommandHandler(_unitOfWork.Object, _mapper);
        var request = new DeleteJornadaCommand(existente.Id);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.True(result);
    }
    [Fact]
    public async Task DeleteNonExistentJornada()
    {
        var handler = new DeleteJornadaCommandHandler(_unitOfWork.Object, _mapper);
        var request = new DeleteJornadaCommand(444);
        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
