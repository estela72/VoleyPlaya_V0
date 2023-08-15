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
using VoleyPlaya.Management.Application.Features.Jornadas.Commands.AddJornada;
using VoleyPlaya.Management.Application.Mappings;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Test.Mocks;

namespace VoleyPlaya.Management.Test.Controllers;

public class JornadasControllerTest
{
    private readonly JornadasController _controller;

    public JornadasControllerTest()
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
        _services.AddScoped(x => unitOfWork.Object.JornadaRepository);
        _services.AddScoped(x => mapper);
        _services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("VoleyPlaya.Management.Application")));
        IMediator? mediator = _services.BuildServiceProvider().GetService<IMediator>();
        _controller = new JornadasController(mediator ?? throw new ArgumentNullException("Mandatory parameter", nameof(mediator)));
    }
    [Fact]
    public async void GetJornadas_ResultOkObject()
    {
        var actionResult = await _controller.GetAsync();

        var okObjectResult = actionResult.Result as OkObjectResult;
        Assert.NotNull(okObjectResult);

        var model = okObjectResult.Value as IEnumerable<JornadaDto>;
        Assert.NotNull(model);
        Assert.NotEqual(0d, model.Count(), 0);
    }
    [Fact]
    public async void GetJornada_ResultNotFound()
    {
        var actionResult = await _controller.Get(-1);
        var notFoundResult = actionResult.Result as NotFoundResult;
        Assert.NotNull(notFoundResult);
    }
    [Fact]
    public async void AddJornada_ResultOkObject()
    {
        var name = "New categoria";
        var actionResult = await _controller.Post(new AddJornadaCommand() { Nombre = name });
        var createdAtActionResult = actionResult.Result as CreatedAtActionResult;
        Assert.NotNull(createdAtActionResult);

        var model = createdAtActionResult.Value as JornadaDto;
        Assert.NotNull(model);

        Assert.Equal(name, model.Nombre);
    }
}
