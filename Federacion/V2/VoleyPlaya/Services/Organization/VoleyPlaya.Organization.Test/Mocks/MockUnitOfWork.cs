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

namespace VoleyPlaya.Organization.Test.Mocks
{
    public  static class MockUnitOfWork
    {
        public static Mock<UnitOfWorkOrganization> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<VoleyPlayaOrganizationContext>()
                .UseInMemoryDatabase(databaseName: $"VoleyPlaya-{Guid.NewGuid()}")
                //.UseSqlServer("Data Source =DESKTOP-D09LJDB\\MSSQLSERVER01; Initial Catalog = VoleyPlaya.Organization; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False")
            .Options;
            var _dataContextFake = new VoleyPlayaOrganizationContext(options/*,null*/);
            _dataContextFake.Database.EnsureDeleted();
            AddDataCategoriaRepository(_dataContextFake);
            AddDataCompeticionRepository(_dataContextFake);
            AddDataEquipoRepository(_dataContextFake);
            AddDataTablaRepository(_dataContextFake);
            AddDataTemporadaRepository(_dataContextFake);
            return new Mock<UnitOfWorkOrganization>(_dataContextFake);
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
        private static void AddDataEquipoRepository(VoleyPlayaOrganizationContext dataContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Equipo>(5).ToList();
            dataContextFake.Equipos.AddRange(list);
            dataContextFake.SaveChanges();
        }
        private static void AddDataTablaRepository(VoleyPlayaOrganizationContext dataContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Tabla>(5).ToList();
            dataContextFake.Tablas.AddRange(list);
            dataContextFake.SaveChanges();
        }
        private static void AddDataTemporadaRepository(VoleyPlayaOrganizationContext dataContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Temporada>(5).ToList();
            dataContextFake.Temporadas.AddRange(list);
            dataContextFake.SaveChanges();
        }
    }
}
