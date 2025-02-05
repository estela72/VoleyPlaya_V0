﻿using AutoMapper;

using Common.Application.Exceptions;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Tablas.Commands.AddTabla;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Tablas.Commands.AddTabla
{
    public class AddTablaCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public AddTablaCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddTablaNew()
        {
            var handler = new AddTablaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AddTablaCommand();
            request.Nombre = "Tabla-New";
            request.Equipo1 = "Equipo1";
            request.Equipo2 = "Equipo2";
            request.Ronda = "Ronda1";
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal("Tabla-New", result.Nombre);
        }
        [Fact]
        public async Task AddTablaExistent()
        {
            var existente = (await _unitOfWork.Object.TablaRepository.GetAllAsync()).FirstOrDefault();

            var handler = new AddTablaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AddTablaCommand();
            request.Nombre = existente.Nombre;
            await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
