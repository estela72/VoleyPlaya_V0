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

using VoleyPlaya.Organization.API.Controllers;
using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Tablas.Commands.AddTabla;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Repositories;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Controllers
{
    public class TablasControllerTest
    {
        private readonly TablasController _controller;

        public TablasControllerTest()
        {
            Mock<UnitOfWork> unitOfWork = new MockUnitOfWork().GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            IMapper mapper = mapperConfig.CreateMapper();

            IServiceCollection _services = new ServiceCollection();
            _services.AddSingleton(new ConfigurationBuilder().Build());
            _services.AddScoped(x => (IUnitOfWork)unitOfWork.Object);
            _services.AddScoped(x => unitOfWork.Object.TablaRepository);
            _services.AddScoped(x => mapper);
            _services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("VoleyPlaya.Organization.Application")));
            IMediator? mediator = _services.BuildServiceProvider().GetService<IMediator>();
            _controller = new TablasController(mediator ?? throw new ArgumentNullException("Mandatory parameter", nameof(mediator)));
        }
        [Fact]
        public async void GetTablas_ResultOkObject()
        {
            var actionResult = await _controller.GetAsync();

            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as IEnumerable<TablaDto>;
            Assert.NotNull(model);
            Assert.NotEqual(0d, model.Count(), 0);
        }
        [Fact]
        public async void GetTabla_ResultNotFound()
        {
            var actionResult = await _controller.Get(-1);
            var notFoundResult = actionResult.Result as NotFoundResult;
            Assert.NotNull(notFoundResult);
        }
        [Fact]
        public async void AddTabla_ResultOkObject()
        {
            var name = "New tabla";
            var actionResult = await _controller.Post(new AddTablaCommand() { Nombre = name });
            var createdAtActionResult = actionResult.Result as CreatedAtActionResult;
            Assert.NotNull(createdAtActionResult);

            var model = createdAtActionResult.Value as TablaDto;
            Assert.NotNull(model);

            Assert.Equal(name, model.Nombre);
        }
    }
}
