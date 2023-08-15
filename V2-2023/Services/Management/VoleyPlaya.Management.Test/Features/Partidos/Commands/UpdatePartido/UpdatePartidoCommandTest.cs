using AutoMapper;

using Common.Application.Exceptions;

using Moq;

using VoleyPlaya.Management.Application.Features.Partidos.Commands.UpdatePartido;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Partidos.Commands.UpdatePartido;

public class UpdatePartidoCommandTest 
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public UpdatePartidoCommandTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task UpdateExistentPartido()
    {
        var existente = (await _unitOfWork.Object.PartidoRepository.GetAllAsync()).FirstOrDefault();

        var handler = new UpdatePartidoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new UpdatePartidoCommand();
        request.Id = existente.Id;
        request.Label = existente.Label+"_modificado";
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.Equal(existente.Label, result.Label);
    }
    [Fact]
    public async Task UpdateNonExistentPartido()
    {
        var edicionExistente = (await _unitOfWork.Object.PartidoRepository.GetAllAsync()).LastOrDefault();

        var handler = new UpdatePartidoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new UpdatePartidoCommand();
        request.Label = edicionExistente.Label + "_modificado";
        request.Id = 444;
        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
