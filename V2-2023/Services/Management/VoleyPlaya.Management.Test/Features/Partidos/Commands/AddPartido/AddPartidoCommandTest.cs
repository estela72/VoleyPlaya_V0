using AutoMapper;

using Common.Application.Exceptions;

using Moq;

using VoleyPlaya.Management.Application.Features.Partidos.Commands.AddPartido;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Partidos.Commands.AddPartido;

public class AddPartidoCommandTest
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public AddPartidoCommandTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task AddPartidoNew()
    {
        var handler = new AddPartidoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new AddPartidoCommand();
        request.Label = "Partido-Nombre";
        request.NumPartido = 1;
        request.FechaHora = DateTime.Now;
        request.EdicionGrupoId = 111;
        request.ConResultado = false;
        request.UserResultado = string.Empty;
        request.Validado = false;
        request.UserValidador = string.Empty;
        
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal("Partido-Nombre", result.Label);
        Assert.Equal(1, result.NumPartido);
        //Assert.Equal(DateTime.Now, result.FechaHora);
        Assert.Equal(111, result.EdicionGrupoId);
    }
    [Fact]
    public async Task AddPartidoExistent()
    {
        var existente = (await _unitOfWork.Object.PartidoRepository.GetAllAsync()).FirstOrDefault();

        var handler = new AddPartidoCommandHandler(_unitOfWork.Object, _mapper);
        var request = new AddPartidoCommand();
        request.Label = existente.Label;
        request.NumPartido = existente.NumPartido;
        request.FechaHora = existente.FechaHora;
        request.EdicionGrupoId = existente.EdicionGrupoId;
        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
