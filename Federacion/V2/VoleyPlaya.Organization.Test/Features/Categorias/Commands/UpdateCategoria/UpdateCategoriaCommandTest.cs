using AutoMapper;

using Common.Application.Exceptions;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.DeleteCategoria;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.UpdateCategoria;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Categorias.Commands.UpdateCategoria
{
    public class UpdateCategoriaCommandTest 
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public UpdateCategoriaCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task UpdateExistentCategoria()
        {
            var categoriaExistente = (await _unitOfWork.Object.CategoriaRepository.GetAllAsync()).FirstOrDefault();

            var handler = new UpdateCategoriaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new UpdateCategoriaCommand();
            request.Id = categoriaExistente.Id;
            request.Nombre = categoriaExistente.Nombre+"_modificado";
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.Equal(categoriaExistente.Nombre, result.Nombre);
        }
        [Fact]
        public async Task UpdateNonExistentCategoria()
        {
            var categoriaExistente = (await _unitOfWork.Object.CategoriaRepository.GetAllAsync()).FirstOrDefault();

            var handler = new UpdateCategoriaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new UpdateCategoriaCommand();
            request.Nombre = categoriaExistente.Nombre + "_modificado";
            request.Id = 444;
            await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
