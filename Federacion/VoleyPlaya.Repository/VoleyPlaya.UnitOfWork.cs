using General.CrossCutting.Lib;

using VoleyPlaya.Repository.Interfaces;
using VoleyPlaya.Repository.Services;

//using VoleyPlaya.Repository.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VoleyPlaya.Repository.Repositories;

namespace VoleyPlaya.Repository
{
    public interface IVoleyPlayaUnitOfWork : IUnitOfWork
    {
        ICategoriaRepository CategoriaRepository { get; }
        ICompeticionRepository CompeticionRepository { get; }
        IEdicionRepository EdicionRepository { get; }
        IEquipoRepository EquipoRepository { get; }
        IParcialPartidoRepository ParcialPartidoRepository { get; }
        IPartidoRepository PartidoRepository { get; }
        ITemporadaRepository TemporadaRepository { get; }
        IJornadaRepository JornadaRepository { get; }
    }

    public class VoleyPlayaUnitOfWork : UnitOfWork, IVoleyPlayaUnitOfWork
    {

        public ICompeticionRepository CompeticionRepository { get; private set; }

        public ICategoriaRepository CategoriaRepository { get; private set; }

        public IEdicionRepository EdicionRepository { get; private set; }

        public IEquipoRepository EquipoRepository { get; private set; }

        public IParcialPartidoRepository ParcialPartidoRepository { get; private set; }

        public IPartidoRepository PartidoRepository { get; private set; }

        public ITemporadaRepository TemporadaRepository { get; private set; }

        public IJornadaRepository JornadaRepository { get; private set; }

        public VoleyPlayaUnitOfWork(IConfiguration configuration
            , VoleyPlayaDbContext context
            , ILoggerFactory loggerFactory
            , ICompeticionRepository competicionRepository
            , ICategoriaRepository categoriaRepository
            , IEdicionRepository edicionRepository
            , IEquipoRepository equipoRepository
            , IParcialPartidoRepository parcialPartidoRepository
            , IPartidoRepository partidoRepository
            , ITemporadaRepository temporadaRepository
            , IJornadaRepository jornadaRepository

            )
            : base(configuration, context, loggerFactory)
        {
            CompeticionRepository = competicionRepository;
            CategoriaRepository = categoriaRepository;
            EdicionRepository = edicionRepository;
            EquipoRepository = equipoRepository;
            ParcialPartidoRepository = parcialPartidoRepository;
            PartidoRepository = partidoRepository;
            TemporadaRepository = temporadaRepository;
            JornadaRepository = jornadaRepository;
        }

    }
}