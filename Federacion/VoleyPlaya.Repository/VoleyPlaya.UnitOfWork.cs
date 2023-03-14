﻿using General.CrossCutting.Lib;

using VoleyPlaya.Repository.Interfaces;
using VoleyPlaya.Repository.Services;

//using VoleyPlaya.Repository.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace VoleyPlaya.Repository
{
    public interface IVoleyPlayaUnitOfWork : IUnitOfWork
    {
        //IEquipoRepository EquipoRepository { get; }
        //ApplicationUserManager<LigamaniaApplicationUser> UserManager { get; }
        //SignInManager<LigamaniaApplicationUser> SignInManager { get; }
        RoleManager<IdentityRole> RolManager { get; }
        //ICompeticionRepository CompeticionRepository { get; }
        //ICompeticionCategoriaRepository CompeticionCategoriaRepository { get; }
        //ICategoriaRepository CategoriaRepository { get; }
        //IClubRepository ClubRepository { get; }
        //IJugadorRepository JugadorRepository { get; }
        //ICalendarioRepository CalendarioRepository { get; }
        //ICalendarioDetalleRepository CalendarioDetalleRepository { get; }
        //IDocumentsRepository DocumentsRepository { get; }
        //ISettingsRepository ParametroRepository { get; }
        //ITemporadaRepository TemporadaRepository { get; }
        //ITemporadaJugadorRepository TemporadaJugadorRepository { get; }
        //IPuestoRepository PuestoRepository { get; }
    }

    public class VoleyPlayaUnitOfWork : UnitOfWork, IVoleyPlayaUnitOfWork
    {
        //public IEquipoRepository EquipoRepository { get; private set; }
        //public ApplicationUserManager<LigamaniaApplicationUser> UserManager { get; private set; }
        //public SignInManager<LigamaniaApplicationUser> SignInManager { get; private set; }
        public RoleManager<IdentityRole> RolManager { get; private set; }
        //public ICompeticionRepository CompeticionRepository { get; private set; }
        //public ICompeticionCategoriaRepository CompeticionCategoriaRepository { get; private set; }
        //public ICategoriaRepository CategoriaRepository { get; private set; }
        //public IClubRepository ClubRepository { get; private set; }
        //public IJugadorRepository JugadorRepository { get; private set; }
        //public ICalendarioRepository CalendarioRepository { get; private set; }
        //public ICalendarioDetalleRepository CalendarioDetalleRepository { get; private set; }
        //public IDocumentsRepository DocumentsRepository { get; private set; }
        //public ISettingsRepository ParametroRepository { get; private set; }
        //public ITemporadaRepository TemporadaRepository { get; private set; }
        //public ITemporadaJugadorRepository TemporadaJugadorRepository { get; private set; }
        //public IPuestoRepository PuestoRepository { get; private set; }

        public VoleyPlayaUnitOfWork(IConfiguration configuration
            , VoleyPlayaDbContext context
            , ILoggerFactory loggerFactory
            //, IEquipoRepository equipoRepository
            //, ApplicationUserManager<LigamaniaApplicationUser> userManager
            //, SignInManager<LigamaniaApplicationUser> signInManager
            , RoleManager<IdentityRole> roleManager
            //, ICompeticionRepository competicionRepository
            //, ICompeticionCategoriaRepository competicionCategoriaRepository
            //, ICategoriaRepository categoriaRepository
            //, IClubRepository clubRepository
            //, IJugadorRepository jugadorRepository
            //, ICalendarioRepository calendarioRepository
            //, ICalendarioDetalleRepository calendarioDetalleRepository
            //, IDocumentsRepository documentsRepository
            //, ISettingsRepository settingsRepository
            //, ITemporadaRepository temporadaRepository
            //, ITemporadaJugadorRepository temporadaJugadorRepository
            //, IPuestoRepository puestoRepository

            )
            : base(configuration, context, loggerFactory)
        {
            //EquipoRepository = equipoRepository;
            //UserManager = userManager;
            //SignInManager = signInManager;
            RolManager = roleManager;
            //CompeticionRepository = competicionRepository;
            //CompeticionCategoriaRepository = competicionCategoriaRepository;
            //CategoriaRepository = categoriaRepository;
            //ClubRepository = clubRepository;
            //JugadorRepository = jugadorRepository;
            //CalendarioRepository = calendarioRepository;
            //CalendarioDetalleRepository = calendarioDetalleRepository;
            //DocumentsRepository = documentsRepository;
            //ParametroRepository = settingsRepository;
            //TemporadaRepository = temporadaRepository;
            //TemporadaJugadorRepository = temporadaJugadorRepository;
            //PuestoRepository = puestoRepository;
        }
    }
}