using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.API.Controllers;
using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.Partidos.Commands.AddPartido;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Controllers;

public class PartidosControllerTest
{
    private readonly PartidosController _controller;

    public PartidosControllerTest()
    {
        Mock<UnitOfWorkManagement> unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        IMapper mapper = mapperConfig.CreateMapper();

        IServiceCollection _services = new ServiceCollection();
        _services.AddSingleton(new ConfigurationBuilder().Build());
        _services.AddScoped(x => (IUnitOfWorkManagement)unitOfWork.Object);
        _services.AddScoped(x => unitOfWork.Object.PartidoRepository);
        _services.AddScoped(x => mapper);
        _services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("VoleyPlaya.Management.Application")));
        IMediator? mediator = _services.BuildServiceProvider().GetService<IMediator>();
        _controller = new PartidosController(mediator ?? throw new ArgumentNullException("Mandatory parameter", nameof(mediator)));
    }
    [Fact]
    public async void GetPartidos_ResultOkObject()
    {
        var actionResult = await _controller.GetAsync();

        var okObjectResult = actionResult.Result as OkObjectResult;
        Assert.NotNull(okObjectResult);

        var model = okObjectResult.Value as IEnumerable<PartidoDto>;
        Assert.NotNull(model);
        Assert.NotEqual(0d, model.Count(), 0);
    }
    [Fact]
    public async void GetPartido_ResultNotFound()
    {
        var actionResult = await _controller.Get(-1);
        var notFoundResult = actionResult.Result as NotFoundResult;
        Assert.NotNull(notFoundResult);
    }
    [Fact]
    public async void AddPartido_ResultOkObject()
    {
        var label = "New categoria";
        var conResultado = false;
        var userResultado = string.Empty;
        var validado = false;
        var userValidador = string.Empty;
        var actionResult = await _controller.Post(new AddPartidoCommand() { Label = label,ConResultado=conResultado, UserResultado=userResultado,
            Validado=validado, UserValidador=userValidador});
        var createdAtActionResult = actionResult.Result as CreatedAtActionResult;
        Assert.NotNull(createdAtActionResult);

        var model = createdAtActionResult.Value as PartidoDto;
        Assert.NotNull(model);

        Assert.Equal(label, model.Label);
    }
}
