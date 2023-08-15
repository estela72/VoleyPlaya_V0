using AutoMapper;

using Common.Application.Exceptions;

using Moq;

using VoleyPlaya.Management.Application.Features.Jornadas.Commands.UpdateJornada;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Jornadas.Commands.UpdateJornada;

public class UpdateJornadaCommandTest 
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public UpdateJornadaCommandTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task UpdateExistentJornada()
    {
        var existente = (await _unitOfWork.Object.JornadaRepository.GetAllAsync()).FirstOrDefault();

        var handler = new UpdateJornadaCommandHandler(_unitOfWork.Object, _mapper);
        var request = new UpdateJornadaCommand();
        request.Id = existente.Id;
        request.Nombre = existente.Nombre+"_modificado";
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.Equal(existente.Nombre, result.Nombre);
    }
    [Fact]
    public async Task UpdateNonExistentJornada()
    {
        var edicionExistente = (await _unitOfWork.Object.JornadaRepository.GetAllAsync()).FirstOrDefault();

        var handler = new UpdateJornadaCommandHandler(_unitOfWork.Object, _mapper);
        var request = new UpdateJornadaCommand();
        request.Nombre = edicionExistente.Nombre + "_modificado";
        request.Id = 444;
        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
