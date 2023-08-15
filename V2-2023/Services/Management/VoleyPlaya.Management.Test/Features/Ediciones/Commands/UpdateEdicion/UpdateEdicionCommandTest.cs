using AutoMapper;

using Common.Application.Exceptions;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.Ediciones.Commands.DeleteEdicion;
using VoleyPlaya.Management.Application.Features.Ediciones.Commands.UpdateEdicion;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Ediciones.Commands.UpdateEdicion;

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
    public async Task UpdateExistentEdicion()
    {
        var existente = (await _unitOfWork.Object.EdicionRepository.GetAllAsync()).FirstOrDefault();

        var handler = new UpdateEdicionCommandHandler(_unitOfWork.Object, _mapper);
        var request = new UpdateEdicionCommand();
        request.Id = existente.Id;
        request.Nombre = existente.Nombre+"_modificado";
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.Equal(existente.Nombre, result.Nombre);
    }
    [Fact]
    public async Task UpdateNonExistentEdicion()
    {
        var edicionExistente = (await _unitOfWork.Object.EdicionRepository.GetAllAsync()).FirstOrDefault();

        var handler = new UpdateEdicionCommandHandler(_unitOfWork.Object, _mapper);
        var request = new UpdateEdicionCommand();
        request.Nombre = edicionExistente.Nombre + "_modificado";
        request.Id = 444;
        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
