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

using VoleyPlaya.Management.Application.Features.Ediciones.Commands.AddEdicion;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Ediciones.Commands.AddEdicion;

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
    public async Task AddEdicionNew()
    {
        var handler = new AddEdicionCommandHandler(_unitOfWork.Object, _mapper);
        var request = new AddEdicionCommand();
        request.Nombre = "Edicion-Nombre";
        request.Genero = Domain.Enums.Generos.Femenino;
        request.Prueba = "Edicion-Prueba";
        request.TemporadaId = 111;
        request.CompeticionId = 444;
        request.CategoriaId = 555;
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal(Domain.Enums.Generos.Femenino, result.Genero);
        Assert.Equal("Edicion-Prueba", result.Prueba);
    }
    [Fact]
    public async Task AddEdicionExistent()
    {
        var existente = (await _unitOfWork.Object.EdicionRepository.GetAllAsync()).FirstOrDefault();

        var handler = new AddEdicionCommandHandler(_unitOfWork.Object, _mapper);
        var request = new AddEdicionCommand();
        request.Nombre = existente.Nombre;
        request.Genero = existente.Genero;
        request.Prueba = existente.Prueba;
        request.TemporadaId = existente.TemporadaId;
        request.CompeticionId = existente.CompeticionId;
        request.CategoriaId = existente.CategoriaId;
        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
