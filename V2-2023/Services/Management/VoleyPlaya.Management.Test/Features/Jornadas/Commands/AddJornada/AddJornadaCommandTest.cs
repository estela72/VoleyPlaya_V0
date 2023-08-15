using AutoMapper;

using Common.Application.Exceptions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Features.Jornadas.Commands.AddJornada;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Jornadas.Commands.AddJornada;

public class AddJornadaCommandTest
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkManagement> _unitOfWork;
    public AddJornadaCommandTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task AddJornadaNew()
    {
        var handler = new AddJornadaCommandHandler(_unitOfWork.Object, _mapper);
        var request = new AddJornadaCommand();
        request.Nombre = "Jornada-Nombre";
        request.Numero = 1;
        request.Fecha = DateTime.Now.Date;
        request.EdicionId = 111;
        
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal("Jornada-Nombre", result.Nombre);
        Assert.Equal(1, result.Numero);
        Assert.Equal(DateTime.Now.Date, result.Fecha);
        Assert.Equal(111, result.EdicionId);
    }
    [Fact]
    public async Task AddJornadaExistent()
    {
        var existente = (await _unitOfWork.Object.JornadaRepository.GetAllAsync()).FirstOrDefault();

        var handler = new AddJornadaCommandHandler(_unitOfWork.Object, _mapper);
        var request = new AddJornadaCommand();
        request.Nombre = existente.Nombre;
        request.Numero = existente.Numero;
        request.Fecha = existente.Fecha;
        request.EdicionId = existente.EdicionId;
        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
