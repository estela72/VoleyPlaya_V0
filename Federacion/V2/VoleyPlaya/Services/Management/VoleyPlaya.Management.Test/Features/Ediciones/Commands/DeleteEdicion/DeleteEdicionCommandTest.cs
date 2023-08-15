using AutoMapper;

using Common.Application.Exceptions;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.Ediciones.Commands.AddEdicion;
using VoleyPlaya.Management.Application.Features.Ediciones.Commands.DeleteEdicion;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Features.Ediciones.Commands.DeleteEdicion;

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
    public async Task DeleteExistentEdicion()
    {
        var existente = (await _unitOfWork.Object.EdicionRepository.GetAllAsync()).FirstOrDefault();

        var handler = new DeleteEdicionCommandHandler(_unitOfWork.Object, _mapper);
        var request = new DeleteEdicionCommand(existente.Id);
        var result = await handler.Handle(request, CancellationToken.None);
        Assert.True(result);
    }
    [Fact]
    public async Task DeleteNonExistentEdicion()
    {
        var handler = new DeleteEdicionCommandHandler(_unitOfWork.Object, _mapper);
        var request = new DeleteEdicionCommand(444);
        await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
    }
}
