using AutoMapper;

using Common.Application.Exceptions;

using Moq;

using VoleyPlaya.Management.Application.Features.Partidos.Commands.DeletePartido;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Partidos.Commands.DeletePartido;

public class DeletePartidoCommandTest 
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public DeletePartidoCommandTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task DeleteExistentPartido()
    {
        var existente = (await _unitOfWork.Object.PartidoRepository.GetAllAsync()).FirstOrDefault();

        var handler = new DeletePartidoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new DeletePartidoCommand(existente.Id);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.True(result);
    }
    [Fact]
    public async Task DeleteNonExistentPartido()
    {
        var handler = new DeletePartidoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new DeletePartidoCommand(444);
        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
