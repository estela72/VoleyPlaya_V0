using AutoFixture;

using Microsoft.EntityFrameworkCore;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Domain;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Infraestructure.Repositories;

namespace VoleyPlaya.Organization.Test.Mocks
{
    public  class MockUnitOfWork : IDisposable
    {
        VoleyPlayaOrganizationContext _dataContextFake;
        public  Mock<UnitOfWork> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<VoleyPlayaOrganizationContext>()
                .UseInMemoryDatabase(databaseName: $"VoleyPlaya-{Guid.NewGuid()}")
                //.UseSqlServer("Data Source =DESKTOP-D09LJDB\\MSSQLSERVER01; Initial Catalog = VoleyPlaya.Organization; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False")
            .Options;
            _dataContextFake = new VoleyPlayaOrganizationContext(options);
            _dataContextFake.Database.EnsureDeleted();
            AddDataCategoriaRepository(_dataContextFake);
            AddDataCompeticionRepository(_dataContextFake);
            return new Mock<UnitOfWork>(_dataContextFake);
        }
        private static void AddDataCategoriaRepository(VoleyPlayaOrganizationContext dataContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Categoria>(5).ToList();
            dataContextFake.Categorias.AddRange(list);
            dataContextFake.SaveChanges();
        }
        private static void AddDataCompeticionRepository(VoleyPlayaOrganizationContext dataContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Competicion>(5).ToList();
            dataContextFake.Competiciones.AddRange(list);
            dataContextFake.SaveChanges();
        }
        public void Dispose()
        {
            _dataContextFake.Dispose();
        }
    }
}
