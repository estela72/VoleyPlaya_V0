﻿using AutoMapper;

using Common.Application.Exceptions;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.AddCategoria;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.DeleteCategoria;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Categorias.Commands.DeleteCategoria
{
    public class DeleteCategoriaCommandTest 
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public DeleteCategoriaCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeleteExistentCategoria()
        {
            var categoriaExistente = (await _unitOfWork.Object.CategoriaRepository.GetAllAsync()).FirstOrDefault();

            var handler = new DeleteCategoriaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new DeleteCategoriaCommand(categoriaExistente.Id);
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }
        [Fact]
        public async Task DeleteNonExistentCategoria()
        {
            var handler = new DeleteCategoriaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new DeleteCategoriaCommand(444);
            await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
