using AutoMapper;

using GenericLib;

using MediatR;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.AddCategoria;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategoria;
using VoleyPlaya.Organization.Application.Mappings;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Test.Mocks;

namespace VoleyPlaya.Organization.Test.Features.Categorias.Commands.AddCategoria
{
    public class AddCategoriaCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkOrganization> _unitOfWork;
        public AddCategoriaCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddCategoriaNew()
        {
            var handler = new AddCategoriaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AddCategoriaCommand();
            request.Nombre = "Categoria-New";
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal("Categoria-New", result.Nombre);
        }
        [Fact]
        public async Task AddCategoriaExistent()
        {
            var categoriaExistente = (await _unitOfWork.Object.CategoriaRepository.GetAllAsync()).FirstOrDefault();

            var handler = new AddCategoriaCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AddCategoriaCommand();
            request.Nombre = categoriaExistente.Nombre;
            await Assert.ThrowsAsync<GenericDomainException>(async () => await handler.Handle(request, CancellationToken.None));
        }
    }
}
