using AutoFixture;

using Microsoft.EntityFrameworkCore;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Domain;
using VoleyPlaya.Management.Infraestructure.Persistence;

namespace VoleyPlaya.Management.Test.Mocks
{
    public  static class MockUnitOfWork
    {
        public static Mock<UnitOfWorkManagement> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<VoleyPlayaManagementContext>()
                .UseInMemoryDatabase(databaseName: $"VoleyPlaya-{Guid.NewGuid()}")
                .EnableSensitiveDataLogging(true)
                //.UseSqlServer("Data Source =DESKTOP-D09LJDB\\MSSQLSERVER01; Initial Catalog = VoleyPlaya.Management; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False")
                .Options;
            var _dataContextFake = new VoleyPlayaManagementContext(options/*,null*/);
            _dataContextFake.Database.EnsureDeleted();
            AddDataEdicionRepository(_dataContextFake);
            //AddDataEdicionGrupoRepository(_dataContextFake);
            //AddDataJornadaRepository(_dataContextFake);
            //AddDataPartidoRepository(_dataContextFake);
            return new Mock<UnitOfWorkManagement>(_dataContextFake);
        }
        private static void AddDataEdicionRepository(VoleyPlayaManagementContext dataContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Edicion>(5).ToList();
            dataContextFake.Ediciones.AddRange(list);
            dataContextFake.SaveChanges();
        }
        private static void AddDataEdicionGrupoRepository(VoleyPlayaManagementContext dataContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<EdicionGrupo>(5).ToList();
            dataContextFake.EdicionGrupos.AddRange(list);
            dataContextFake.SaveChanges();
        }
        private static void AddDataJornadaRepository(VoleyPlayaManagementContext dataContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Jornada>(5).ToList();
            dataContextFake.Jornada.AddRange(list);
            dataContextFake.SaveChanges();
        }
        private static void AddDataPartidoRepository(VoleyPlayaManagementContext dataContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var list = fixture.CreateMany<Partido>(5).ToList();
            dataContextFake.Partidos.AddRange(list);
            dataContextFake.SaveChanges();
        }
    }
}
