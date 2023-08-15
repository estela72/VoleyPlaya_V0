using AutoMapper;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Models.EntrenadorViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Services
{
    public class EntrenadorService : IEntrenadorService
    {
        private readonly ITemporadaRepository _temporadaRepository;
        private readonly ITemporadaEquipoRepository _temporadaEquipoRepository;
        private readonly ITemporadaCompeticionJornadaRepository _temporadaCompeticionJornadaRepository;
        private readonly IAlineacionCambiosRepository _alineacionCambiosRepository;
        private readonly IAlineacionPreviaRepository _alineacionPreviaRepository;
        private readonly IAlineacionRepository _alineacionRepository;
        private readonly ITemporadaCompeticionRepository _temporadaCompeticionRepository;
        private readonly ITemporadaJugadorRepository _temporadaJugadorRepository;
        private readonly ITemporadaPartidoRepository _temporadaPartidoRepository;
        private readonly ITemporadaJornadaJugadorRepository _temporadaJornadaJugadorRepository;
        private readonly ITemporadaRondaRepository _temporadaRondaRepository;
        private readonly ILigamaniaService _ligamaniaService;

        private readonly ILogger<EntrenadorService> _logger;
        private readonly IMapper _mapper;

        public EntrenadorService(
            ILogger<EntrenadorService> logger
            , IMapper mapper
            , ITemporadaRepository temporadaRepository
            , ITemporadaEquipoRepository temporadaEquipoRepository
            , ITemporadaCompeticionJornadaRepository temporadaCompeticionJornadaRepository
            , IAlineacionCambiosRepository aliCambiosRepository
            , IAlineacionPreviaRepository alineacionPreviaRepository
            , IAlineacionRepository alineacionRepository
            , ITemporadaCompeticionRepository temporadaCompeticionRepository
            , ITemporadaJugadorRepository temporadaJugadorRepository
            , ITemporadaPartidoRepository temporadaPartidoRepository
            , ITemporadaJornadaJugadorRepository temporadaJornadaJugadorRepository
            , ITemporadaRondaRepository temporadaRondaRepository
            , ILigamaniaService ligamaniaService
            )
        {
            _mapper = mapper;
            _logger = logger;
            _temporadaRepository = temporadaRepository;
            _temporadaEquipoRepository = temporadaEquipoRepository;
            _temporadaCompeticionJornadaRepository = temporadaCompeticionJornadaRepository;
            _alineacionCambiosRepository = aliCambiosRepository;
            _alineacionPreviaRepository = alineacionPreviaRepository;
            _alineacionRepository = alineacionRepository;
            _temporadaCompeticionRepository = temporadaCompeticionRepository;
            _temporadaJugadorRepository = temporadaJugadorRepository;
            _temporadaPartidoRepository = temporadaPartidoRepository;
            _temporadaJornadaJugadorRepository = temporadaJornadaJugadorRepository;
            _temporadaRondaRepository = temporadaRondaRepository;
            _ligamaniaService = ligamaniaService;
        }
        public async Task<AlineacionesCambiosViewModel> GetAlineaciones(string user)
        {
            AlineacionesCambiosViewModel aliCambios = new AlineacionesCambiosViewModel
            {
                Entrenador = user
            };

            // los equipos que tiene activos el entrenador
            ICollection<TemporadaEquipoViewModel> equiposActivos = await GetEquiposActivos(user).ConfigureAwait(false);
            aliCambios.Equipos = new List<TemporadaEquipoViewModel>();
            if (equiposActivos!=null && equiposActivos.Any())
            {
                // las alineaciones de cada equipo (previa, cambios, actuales)
                foreach (var equipo in equiposActivos)
                {
                    AlineacionesJornadaEquipo alineacionesEquipo = await GetInfoEquipo(equipo).ConfigureAwait(false);
                    //equipo.NumCambiosRealizados = GetNumCambiosRealizados(alineacionesEquipo);
                    equipo.Alineaciones = alineacionesEquipo;
                    aliCambios.Equipos.Add(equipo);
                }
            }
            return aliCambios;
        }

        private async Task<AlineacionesJornadaEquipo> GetInfoEquipo(TemporadaEquipoViewModel equipo)
        {
            AlineacionesJornadaEquipo alineaciones = new AlineacionesJornadaEquipo();
            TemporadaCompeticionJornadaDTO jornada = await GetJornadaEntrenador(equipo.CompeticionId).ConfigureAwait(false);
            if (jornada != null)
            {
                 alineaciones = await GetAlineacionesJornadaEquipo(jornada, equipo).ConfigureAwait(false);
            }
            return alineaciones;
        }

        private async Task<TemporadaCompeticionJornadaDTO> GetJornadaEntrenador(int competicionId)
        {
            var jornada = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(competicionId).ConfigureAwait(false);
            if (jornada == null)
                jornada = await _temporadaCompeticionJornadaRepository.GetJornadaActual(competicionId).ConfigureAwait(false);
            return jornada;
        }

        private async Task<AlineacionesJornadaEquipo> GetAlineacionesJornadaEquipo(TemporadaCompeticionJornadaDTO jornada, TemporadaEquipoViewModel equipo)
        {
            var aliprevia = await _alineacionPreviaRepository.FindAllIncludingAsync(ap =>
                ap.Competicion_ID.Equals(jornada.CompeticionId) && ap.Equipo_ID.Equals(equipo.Id),
                ap => ap.Jugador, ap => ap.Club, ap => ap.Puesto).ConfigureAwait(false);

            var alicambios = await _alineacionCambiosRepository.FindAllIncludingAsync(ap =>
                ap.Competicion_ID.Equals(jornada.CompeticionId) && ap.Equipo_ID.Equals(equipo.Id),
                ap => ap.Jugador, ap => ap.Club, ap => ap.Puesto, ap=>ap.JugadorCambio, ap=>ap.ClubCambio).ConfigureAwait(false);

            var aliactual = await _alineacionRepository.FindAllIncludingAsync(ap =>
                ap.Competicion_ID.Equals(jornada.CompeticionId) && ap.Equipo_ID.Equals(equipo.Id) && ap.Jornada_ID.Equals(jornada.Id),
                ap => ap.Jugador, ap => ap.Club, ap => ap.Puesto).ConfigureAwait(false);

            AlineacionesJornadaEquipo alineacionesJornadaEquipo = new AlineacionesJornadaEquipo
            {
                Previa = _mapper.Map<List<AlineacionPreviaDTO>, List<AlineacionViewModel>>(aliprevia.ToList()),
                Cambios = _mapper.Map<List<AlineacionCambioDTO>, List<AlineacionViewModel>>(alicambios.ToList()),
                Actual = _mapper.Map<List<AlineacionDTO>, List<AlineacionViewModel>>(aliactual.ToList())
            };

            await OrdenaAlineacionesPorPuesto(alineacionesJornadaEquipo).ConfigureAwait(false);

            var competicion = await _temporadaCompeticionRepository.GetCompeticion(jornada.TemporadaId, jornada.CompeticionId).ConfigureAwait(false);

            await EstableceEstadoAlineaciones(competicion, equipo, alineacionesJornadaEquipo, jornada).ConfigureAwait(false);

            await EstableceNumeroCambiosRealizados(alineacionesJornadaEquipo, jornada).ConfigureAwait(false);

            return alineacionesJornadaEquipo;
        }
        private async Task EstableceNumeroCambiosRealizados(AlineacionesJornadaEquipo alineaciones, TemporadaCompeticionJornadaDTO jornada)
        {
            //var jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(jornada.CompeticionId).ConfigureAwait(false);

            //var competicionLiga = await _temporadaCompeticionRepository.GetCompeticion(jornada.TemporadaId, jornada.CompeticionId).ConfigureAwait(false);
            var competicionLiga = await _ligamaniaService.GetCompeticionLigaActual();

            var jornadaActualLiga = await _temporadaCompeticionJornadaRepository.GetJornadaActual(competicionLiga.Competicion.Id).ConfigureAwait(false);
            ICollection<TemporadaJugadorDTO> jugadoresEliminados = await _temporadaJugadorRepository.GetJugadoresEliminados().ConfigureAwait(false);
            List<TemporadaJugadorDTO> jugadoresEliminadosJornada = jugadoresEliminados.Where(j => j.LastJornadaEliminacion.Equals(jornadaActualLiga)).ToList();

            List<string> listJugadoresEliJornada = jugadoresEliminadosJornada.Select(j => j.Jugador.Nombre).ToList();
            var jugadoresPrevia = alineaciones.Previa.Select(a => a.Jugador).ToList();
            var jugadoresCambio = alineaciones.Cambios.Select(a => a.Jugador).ToList();

            // cambios posibles
            //int numCambiosFijosPosibles = 2;
            int numCambiosExtrasPosibles = jugadoresPrevia.Count(j => listJugadoresEliJornada.Contains(j));

            // contar todos los jugadores de la previa eliminados
            var jugadoresPreviaEliminados = jugadoresPrevia.Where(j => listJugadoresEliJornada.Contains(j)).ToList();
            var jugadoresPreviaNormales = jugadoresPrevia.Where(j => !listJugadoresEliJornada.Contains(j)).ToList();

            var jugadoresCambioEliminadosNoCambiados = jugadoresCambio.Where(j => jugadoresPreviaEliminados.Contains(j)).ToList();

            alineaciones.NumCambiosExtrasRealizados = numCambiosExtrasPosibles - jugadoresCambioEliminadosNoCambiados.Count;

            var cambiosTotalesRealizados = jugadoresCambio.Except(jugadoresPrevia).Count();

            alineaciones.NumCambiosFijosRealizados = cambiosTotalesRealizados - alineaciones.NumCambiosExtrasRealizados;

            ////// de los cambiados, los jugadores eliminados que estén en la previa
            ////var jugadoresCambioEliminados = jugadoresCambio.Where(j => listJugadoresEliJornada.Contains(j) && jugadoresPreviaEliminados.Contains(j)).ToList();
            ////var jugadoresCambioNormales = jugadoresCambio.Where(j => !listJugadoresEliJornada.Contains(j) && jugadoresPreviaNormales.Contains(j)).ToList();

            ////alineaciones.NumCambiosFijosRealizados = jugadoresCambioNormales.Except(jugadoresPreviaNormales).Count();
            ////alineaciones.NumCambiosExtrasRealizados = jugadoresCambioEliminados.Except(jugadoresPreviaEliminados).Count();
        }
        // ORIGINAL
        //private async Task OrdenaAlineacionesPorPuesto(AlineacionesJornadaEquipo alineacionesJornadaEquipo)
        //{
        //    alineacionesJornadaEquipo.Portero = GetInfoAlineacion(LigamaniaConst.Puesto_Portero, alineacionesJornadaEquipo, 0);

        //    alineacionesJornadaEquipo.Defensa1 = GetInfoAlineacion(LigamaniaConst.Puesto_Defensa, alineacionesJornadaEquipo, 0);
        //    alineacionesJornadaEquipo.Defensa2 = GetInfoAlineacion(LigamaniaConst.Puesto_Defensa, alineacionesJornadaEquipo, 1);
        //    alineacionesJornadaEquipo.Defensa3 = GetInfoAlineacion(LigamaniaConst.Puesto_Defensa, alineacionesJornadaEquipo, 2);

        //    alineacionesJornadaEquipo.Medio1 = GetInfoAlineacion(LigamaniaConst.Puesto_Medio, alineacionesJornadaEquipo, 0);
        //    alineacionesJornadaEquipo.Medio2 = GetInfoAlineacion(LigamaniaConst.Puesto_Medio, alineacionesJornadaEquipo, 1);
        //    alineacionesJornadaEquipo.Medio3 = GetInfoAlineacion(LigamaniaConst.Puesto_Medio, alineacionesJornadaEquipo, 2);
        //    alineacionesJornadaEquipo.Medio4 = GetInfoAlineacion(LigamaniaConst.Puesto_Medio, alineacionesJornadaEquipo, 3);

        //    alineacionesJornadaEquipo.Delantero1 = GetInfoAlineacion(LigamaniaConst.Puesto_Delantero, alineacionesJornadaEquipo, 0);
        //    alineacionesJornadaEquipo.Delantero2 = GetInfoAlineacion(LigamaniaConst.Puesto_Delantero, alineacionesJornadaEquipo, 1);
        //    alineacionesJornadaEquipo.Delantero3 = GetInfoAlineacion(LigamaniaConst.Puesto_Delantero, alineacionesJornadaEquipo, 2);
        //}
        //private InfoAlineacion GetInfoAlineacion(string puesto, AlineacionesJornadaEquipo alineacionesJornadaEquipo, int orden)
        //{
        //    InfoAlineacion info = new InfoAlineacion();
        //    var puestoPrevia = alineacionesJornadaEquipo.Previa.Where(ap => ap.Puesto.Equals(puesto)).ToList();
        //    var puestoCambio = alineacionesJornadaEquipo.Cambios.Where(ap => ap.Puesto.Equals(puesto)).ToList();
        //    string jPrevia = LigamaniaConst.CadenaInicial; string pPrevia = LigamaniaConst.CadenaInicial; string cPrevia = LigamaniaConst.CadenaInicial; string aPrevia = LigamaniaConst.CadenaInicial; int idPrevia = -1;
        //    string jCambio = LigamaniaConst.CadenaInicial; string pCambio = LigamaniaConst.CadenaInicial; string cCambio = LigamaniaConst.CadenaInicial; string aCambio = LigamaniaConst.CadenaInicial; int idCambio = -1;
        //    if (orden < puestoPrevia.Count) { jPrevia = puestoPrevia[orden].Jugador; pPrevia = puestoPrevia[orden].Puesto; cPrevia = puestoPrevia[orden].Club; aPrevia = puestoPrevia[orden].Alias; idPrevia = puestoPrevia[orden].Id; }
        //    if (orden < puestoCambio.Count) { jCambio = puestoCambio[orden].Jugador; pCambio = puestoCambio[orden].Puesto; cCambio = puestoCambio[orden].Club; aCambio = puestoCambio[orden].Alias; idCambio = puestoCambio[orden].Id; }
        //    info.JugadorPrevia = new AlineacionViewModel { Jugador = jPrevia, Puesto = pPrevia, Club = cPrevia, Alias = aPrevia, Id = idPrevia };
        //    info.JugadorCambio = new AlineacionViewModel { Jugador = jCambio, Puesto = pCambio, Club = cCambio, Alias = aCambio, Id = idCambio };
        //    return info;
        //}

        private async Task OrdenaAlineacionesPorPuesto(AlineacionesJornadaEquipo alineacionesJornadaEquipo)
        {
            var porteros = GetInfoAlineaciones(LigamaniaConst.Puesto_Portero, alineacionesJornadaEquipo);
            var defensas = GetInfoAlineaciones(LigamaniaConst.Puesto_Defensa, alineacionesJornadaEquipo);
            var medios = GetInfoAlineaciones(LigamaniaConst.Puesto_Medio, alineacionesJornadaEquipo);
            var delanteros = GetInfoAlineaciones(LigamaniaConst.Puesto_Delantero, alineacionesJornadaEquipo);

            alineacionesJornadaEquipo.Portero = porteros[0];
            alineacionesJornadaEquipo.Defensa1 = defensas[0];
            alineacionesJornadaEquipo.Defensa2 = defensas[1];
            alineacionesJornadaEquipo.Defensa3 = defensas[2];
            alineacionesJornadaEquipo.Medio1 = medios[0];
            alineacionesJornadaEquipo.Medio2 = medios[1];
            alineacionesJornadaEquipo.Medio3 = medios[2];
            alineacionesJornadaEquipo.Medio4 = medios[3];
            alineacionesJornadaEquipo.Delantero1 = delanteros[0];
            alineacionesJornadaEquipo.Delantero2 = delanteros[1];
            alineacionesJornadaEquipo.Delantero3 = delanteros[2];
        }
        private List<InfoAlineacion> GetInfoAlineaciones(string puesto, AlineacionesJornadaEquipo alineacionesJornadaEquipo)
        {
            List<InfoAlineacion> lista = new List<InfoAlineacion>();
            int contador = 0;
            switch (puesto)
            {
                case LigamaniaConst.Puesto_Portero:
                    contador = 1;
                    break;
                case LigamaniaConst.Puesto_Defensa:
                    contador = 3;
                    break;
                case LigamaniaConst.Puesto_Medio:
                    contador = 4;
                    break;
                case LigamaniaConst.Puesto_Delantero:
                    contador = 3;
                    break;
            }
            var previas = alineacionesJornadaEquipo.Previa.Where(ap => ap.Puesto.Equals(puesto)).ToList();
            var cambios = alineacionesJornadaEquipo.Cambios.Where(ap => ap.Puesto.Equals(puesto)).ToList();
            foreach (var previa in previas)
            {
                string jPrevia = LigamaniaConst.CadenaInicial; string pPrevia = LigamaniaConst.CadenaInicial; string cPrevia = LigamaniaConst.CadenaInicial; string aPrevia = LigamaniaConst.CadenaInicial; int idPrevia = -1;
                string jCambio = LigamaniaConst.CadenaInicial; string pCambio = LigamaniaConst.CadenaInicial; string cCambio = LigamaniaConst.CadenaInicial; string aCambio = LigamaniaConst.CadenaInicial; int idCambio = -1;
                jPrevia = previa.Jugador; pPrevia = previa.Puesto; cPrevia = previa.Club; aPrevia = previa.Alias; idPrevia = previa.Id;
                var cambio = cambios.SingleOrDefault(c => c.JugadorCambio!=null && c.JugadorCambio.Equals(previa.Jugador));
                bool pendBaja = false;
                if (cambio==null)
                {
                    jCambio = jPrevia; pCambio = pPrevia; cCambio = cPrevia; aCambio = aPrevia; idCambio = -1; pendBaja = previa.PendienteBaja;
                }
                else
                {
                    jCambio = cambio.Jugador;pCambio = cambio.Puesto;cCambio = cambio.Club;aCambio = cambio.Alias;idCambio = cambio.Id; pendBaja = cambio.PendienteBaja;
                }
                InfoAlineacion info = new InfoAlineacion();
                info.JugadorPrevia = new AlineacionViewModel { Jugador = jPrevia, Puesto = pPrevia, Club = cPrevia, Alias = aPrevia, Id = idPrevia, PendienteBaja = pendBaja };
                info.JugadorCambio = new AlineacionViewModel { Jugador = jCambio, Puesto = pCambio, Club = cCambio, Alias = aCambio, Id = idCambio, PendienteBaja = pendBaja };
                lista.Add(info);
            }
            if (previas.Count < cambios.Count)
            {
                var jugadores = lista.Select(l => l.JugadorPrevia.Jugador).ToList();
                foreach(var cambio in cambios)
                {
                    if (!jugadores.Contains(cambio.Jugador))
                    {
                        string jPrevia = LigamaniaConst.CadenaInicial; string pPrevia = LigamaniaConst.CadenaInicial; string cPrevia = LigamaniaConst.CadenaInicial; string aPrevia = LigamaniaConst.CadenaInicial; int idPrevia = -1;
                        string jCambio = LigamaniaConst.CadenaInicial; string pCambio = LigamaniaConst.CadenaInicial; string cCambio = LigamaniaConst.CadenaInicial; string aCambio = LigamaniaConst.CadenaInicial; int idCambio = -1;
                        jCambio = cambio.Jugador; pCambio = cambio.Puesto; cCambio = cambio.Club; aCambio = cambio.Alias; idCambio = cambio.Id;
                        InfoAlineacion info = new InfoAlineacion();
                        info.JugadorPrevia = new AlineacionViewModel { Jugador = jPrevia, Puesto = pPrevia, Club = cPrevia, Alias = aPrevia, Id = idPrevia };
                        info.JugadorCambio = new AlineacionViewModel { Jugador = jCambio, Puesto = pCambio, Club = cCambio, Alias = aCambio, Id = idCambio };
                        lista.Add(info);
                    }
                }
            }     
            for (int i=lista.Count; i < contador; i++)
            {
                string jPrevia = LigamaniaConst.CadenaInicial; string pPrevia = LigamaniaConst.CadenaInicial; string cPrevia = LigamaniaConst.CadenaInicial; string aPrevia = LigamaniaConst.CadenaInicial; int idPrevia = -1;
                var aliIni = new AlineacionViewModel { Jugador = jPrevia, Puesto = pPrevia, Club = cPrevia, Alias = aPrevia, Id = idPrevia };
                lista.Add(new InfoAlineacion { JugadorCambio = aliIni, JugadorPrevia = aliIni });
            }
            return lista;
        }

        private async Task EstableceEstadoAlineaciones(TemporadaCompeticionDTO tempComp, TemporadaEquipoViewModel equipo, AlineacionesJornadaEquipo alineaciones, TemporadaCompeticionJornadaDTO jornada)
        {
            bool aliIni = alineaciones == null || alineaciones.Actual.Count <= 0;
            bool camb = (alineaciones != null && alineaciones.Actual.Count > 0);

            aliIni = aliIni && ( tempComp.GetEstadoOperacion().Equals(LigamaniaConst.JI_AbrirAli) || tempComp.GetEstadoOperacion().Equals(LigamaniaConst.AJ_AbrirCam));
            camb = camb && tempComp.GetEstadoOperacion().Equals(LigamaniaConst.AJ_AbrirCam);
            if (camb && aliIni) aliIni = false;
            
            if (tempComp.Competicion.EsCopa)
            {
                if (tempComp.GetEstadoOperacion().Equals(LigamaniaConst.JI_AbrirAli)) aliIni = true;

                if (tempComp.OperacionActual == null || tempComp.OperacionActual.Operacion.Equals(LigamaniaConst.Operacion_Inicial))
                {
                    aliIni = false;
                    camb = false;
                }
                else
                {
                    if (jornada != null)
                    {
                        TemporadaCompeticionJornadaDTO jornadaActualCopa = await _temporadaCompeticionJornadaRepository.GetJornadaActual(tempComp.CompeticionId).ConfigureAwait(false);
                        ICollection<TemporadaPartidoDTO> partidos = await _temporadaPartidoRepository
                            .FindAllAsync(tp => tp.CompeticionId.Equals(tempComp.CompeticionId) && tp.JornadaId.Equals(jornadaActualCopa.Id) 
                                && (tp.EquipoAId.Equals(equipo.EquipoId)|| tp.EquipoBId.Equals(equipo.EquipoId))).ConfigureAwait(false);

                        if (partidos == null || !partidos.Any())
                        {
                            aliIni = false;
                            camb = false;
                        }
                        bool isLastJornada = false; // TODO: _temporadaCompeticionRepository.IsLastJornada(jorActual);
                        if (isLastJornada)
                        {
                            aliIni = true;
                            camb = false;
                        }
                    }
                    else
                    {
                        aliIni = false;
                        camb = false;
                    }
                }
            }
            if (equipo.AlineacionLibre) aliIni = true;
            equipo.RepetirClub = tempComp.Competicion.RepetirClubAliIni;

            alineaciones.AlineacionInicalActivo = aliIni;
            alineaciones.CambiosActivo = camb;
        }

        private async Task<ICollection<TemporadaEquipoViewModel>> GetEquiposActivos(string user)
        {
            TemporadaDTO temporadaActual = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            if (temporadaActual==null)
            {
                _logger.LogError("No exite temporada actual");
                return null;
            }
            ICollection<TemporadaEquipoDTO> equiposUsuario = await _temporadaEquipoRepository.GetEquiposActivosUser(temporadaActual.Id, user).ConfigureAwait(false);
            if (equiposUsuario == null)
            {
                _logger.LogError("El usuario " + user + " no tiene equipos activos");
                return null;
            }

            ICollection<TemporadaEquipoViewModel> equipos = new List<TemporadaEquipoViewModel>();
            // solo agregamos aquellos equipos cuya competición esté activa en la temporada
            var competicionesActivas = await _temporadaCompeticionRepository.GetCompeticionesActivas(temporadaActual).ConfigureAwait(false);
            foreach (var equipo in equiposUsuario)
            {
                var competicionActiva = competicionesActivas.SingleOrDefault(c => c.CompeticionId.Equals(equipo.CompeticionId));
                if (competicionActiva != null)
                {
                    TemporadaEquipoViewModel equipoVm = _mapper.Map<TemporadaEquipoViewModel>(equipo);
                    equipoVm.MaxCambiosFijosPosibles = competicionActiva.CambiosFijos;
                    equipos.Add(equipoVm);
                }
            }
            return equipos;
        }

        #region Acciones sobre la pantalla de cambios y alineaciones
        public async Task<Response> CambioJugador(InfoCambioJugador infoCambioJugador)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                TemporadaEquipoDTO temporadaEquipo = await _temporadaEquipoRepository
                    .FindIncludingAsync(te => te.TemporadaId.Equals(temporada.Id) 
                    && te.Competicion.Nombre.Equals(infoCambioJugador.Competicion) 
                    && te.Equipo.Nombre.Equals(infoCambioJugador.Equipo) && !te.Baja,
                    te=>te.Categoria, te=>te.Competicion).ConfigureAwait(false);

                string[] clubJugPrevio = infoCambioJugador.Jugador.Split(" - ");
                string clubPrevio = clubJugPrevio[0];
                string jugadorPrevio = clubJugPrevio[1];

                string[] clubJug = infoCambioJugador.JugadorCambio.Split(" - ");
                string club = clubJug[0];
                string jugador = clubJug[1];

                TemporadaJugadorDTO temporadaJugadorNuevo = null;
                if (infoCambioJugador.JugadorCambio != LigamaniaConst.JugadorAlineacion)
                {
                    temporadaJugadorNuevo = await _temporadaJugadorRepository
                            .FindIncludingAsync(tj => tj.Temporada_ID.Equals(temporada.Id) && tj.Jugador.Nombre.Equals(jugador) && tj.Activo,
                            tj => tj.Club, tj => tj.Puesto, tj => tj.Jugador).ConfigureAwait(false);
                }
                if (temporadaJugadorNuevo==null)
                    return new Response { Message = "No se encuentra el jugador por el que realizar el cambio", Result = false, Status = EResponseStatus.Warning };


                Response cambioOk = await CheckCambioJugador(temporadaEquipo, temporadaJugadorNuevo).ConfigureAwait(false);
                if (!cambioOk.Result)
                    return cambioOk;

                // es una alineación nueva, bien sea porque es una alineación inicial, bien porque es una alineación sobre una anterior que no estaba correcta
                if (infoCambioJugador.Jugador == LigamaniaConst.JugadorAlineacion && temporadaJugadorNuevo!=null) 
                {
                    AlineacionCambioDTO nuevaAlineacion = new AlineacionCambioDTO
                    {
                        Categoria = temporadaEquipo.Categoria,
                        Club = temporadaJugadorNuevo.Club,
                        Competicion = temporadaEquipo.Competicion,
                        Equipo = temporadaEquipo,
                        Jugador = temporadaJugadorNuevo.Jugador,
                        Puesto = temporadaJugadorNuevo.Puesto,
                        Temporada = temporada,
                        ClubCambio_ID = temporadaJugadorNuevo.Club.Id,
                        JugadorCambio_ID = temporadaJugadorNuevo.Jugador_ID
                    };
                    await _alineacionCambiosRepository.AddAsyn(nuevaAlineacion).ConfigureAwait(false);
                    await _alineacionCambiosRepository.SaveAsync().ConfigureAwait(false);
                    return new Response { Message = "Alineación de jugador realizado correctamente", Result = true, Status = EResponseStatus.Success };
                }

                AlineacionCambioDTO jugadorActual = await _alineacionCambiosRepository
                    .GetByJugador(temporadaEquipo.CompeticionId, temporadaEquipo.CategoriaId, temporadaEquipo.Id, jugadorPrevio).ConfigureAwait(false);

                if (jugadorActual !=null)
                {
                    jugadorActual.Jugador = temporadaJugadorNuevo.Jugador;
                    jugadorActual.Club = temporadaJugadorNuevo.Club;

                    // en clubcambio y jugadorcambio dejamos el jugador de la previa. por eso solo actualizo estos campos si son nulos
                    if (jugadorActual.ClubCambio_ID == null && jugadorActual.JugadorCambio_ID == null)
                    {
                        jugadorActual.ClubCambio_ID = jugadorActual.Club_ID;
                        jugadorActual.JugadorCambio_ID = jugadorActual.Jugador_ID;
                    }
                    if (jugadorActual.Jugador.Id == jugadorActual.JugadorCambio_ID && jugadorActual.Club.Id == jugadorActual.ClubCambio_ID)
                    {
                        jugadorActual.JugadorCambio_ID = null;
                        jugadorActual.ClubCambio_ID = null;
                    }
                    await _alineacionCambiosRepository.UpdateAsyn(jugadorActual, jugadorActual.Id).ConfigureAwait(false);
                    await _alineacionCambiosRepository.SaveAsync().ConfigureAwait(false);
                    return new Response { Message = "Cambio de jugador realizado correctamente", Result = true, Status = EResponseStatus.Success };
                }
                else
                {
                    return new Response { Message = "No se encuentra la alineación para realizar el cambio", Result = false, Status = EResponseStatus.Warning};
                }
            }
            catch (Exception x)
            {
                _logger.LogError("Error al realizar un cambio de jugador: " + x);
                return new Response { Message = "Error al realizar el cambio", Result = false, Status = EResponseStatus.Error };
            }
        }

        private async Task<Response> CheckCambioJugador(TemporadaEquipoDTO temporadaEquipo, TemporadaJugadorDTO temporadaJugadorNuevo)
        {
            var competicion = await _temporadaCompeticionRepository.GetCompeticion(temporadaEquipo.TemporadaId, temporadaEquipo.Competicion.Nombre).ConfigureAwait(false);
            if (!competicion.Competicion.RepetirClubAliIni)
            {
                // si es Supercopa no se permite repetir club
                var alineacionEquipo = await _alineacionCambiosRepository.FindAllIncludingAsync(
                    ac => ac.Temporada_ID.Equals(temporadaEquipo.TemporadaId) 
                    && ac.Competicion_ID.Equals(temporadaEquipo.CompeticionId) && ac.Equipo_ID.Equals(temporadaEquipo.Id),
                    ac => ac.Club).ConfigureAwait(false);
                var clubs = alineacionEquipo.Select(ac => ac.Club.Nombre).ToList();
                if (clubs.Contains(temporadaJugadorNuevo.Club.Nombre))
                    return new Response
                    {
                        Message = "No se puede repetir club en la alineación de " + competicion.Competicion.Nombre,
                        Result = false,
                        Status = EResponseStatus.Warning
                    };
            }
            return new Response { Result = true };
        }

        public async Task<Response> EliminaAlineacion(InfoCambioJugador infoCambioJugador)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                TemporadaEquipoDTO temporadaEquipo = await _temporadaEquipoRepository
                    .FindIncludingAsync(te => te.TemporadaId.Equals(temporada.Id) && te.Competicion.Nombre.Equals(infoCambioJugador.Competicion) && te.Equipo.Nombre.Equals(infoCambioJugador.Equipo),
                    te => te.Categoria, te => te.Competicion).ConfigureAwait(false);

                string[] clubJugPrevio = infoCambioJugador.Jugador.Split(" - ");
                string clubPrevio = clubJugPrevio[0];
                string jugadorPrevio = clubJugPrevio[1];

                AlineacionCambioDTO jugadorActual = await _alineacionCambiosRepository
                    .GetByJugador(temporadaEquipo.CompeticionId, temporadaEquipo.CategoriaId, temporadaEquipo.Id, jugadorPrevio).ConfigureAwait(false);

                if (jugadorActual != null)
                {
                    await _alineacionCambiosRepository.DeleteAsyn(jugadorActual).ConfigureAwait(false);
                    await _alineacionCambiosRepository.SaveAsync().ConfigureAwait(false);
                    return new Response { Message = "Eliminada alineación correctamente", Result = true, Status = EResponseStatus.Success };
                }
                else
                {
                    return new Response { Message = "No se encuentra la alineación a eliminar", Result = false, Status = EResponseStatus.Warning };
                }
            }
            catch (Exception x)
            {
                _logger.LogError("Error al realizar una eliminación de jugador: " + x);
                return new Response { Message = "Error al realizar la eliminación de jugador", Result = false, Status = EResponseStatus.Error };
            }
        }
        #endregion

        #region Carrusel
        public async Task<CarruselViewModel> GetCarrusel(string competicion, string categoria, int jornada)
        {
            CarruselViewModel carrusel = new CarruselViewModel
            {
                Competicion = competicion,
                Categoria = categoria,
                Jornada = jornada,
                Partidos = new List<TemporadaPartidoViewModel>()
            };

            if (!string.IsNullOrEmpty(competicion) && !string.IsNullOrEmpty(categoria) && jornada > 0)
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                TemporadaCompeticionDTO tempcomp = await _temporadaCompeticionRepository.GetCompeticion(temporada.Id, competicion).ConfigureAwait(false);
                TemporadaCompeticionJornadaDTO jornadaComp = await _temporadaCompeticionJornadaRepository.GetJornada(temporada.Id, tempcomp.CompeticionId, jornada).ConfigureAwait(false);
                ICollection<TemporadaJornadaJugadorDTO> goleadores = await _temporadaJornadaJugadorRepository.GetGoleadores(jornadaComp).ConfigureAwait(false);
                ICollection<TemporadaJornadaJugadorDTO> preeliminados = await _temporadaJornadaJugadorRepository.GetJugadoresPreEliminados(jornadaComp).ConfigureAwait(false);
                ICollection<TemporadaJornadaJugadorDTO> eliminados = await _temporadaJornadaJugadorRepository.GetJugadoresEliminadosJornada(jornadaComp).ConfigureAwait(false);
                ICollection<TemporadaJugadorDTO> eliminadosPreviosDto = await _temporadaJugadorRepository.GetJugadoresEliminados().ConfigureAwait(false);
                ICollection<string> eliminadosPrevios = new List<string>();
                if (eliminadosPreviosDto != null) eliminadosPrevios = eliminadosPreviosDto.Select(e => e.Jugador.Nombre).ToList();

                ICollection<TemporadaPartidoDTO> partidos = await _temporadaPartidoRepository
                    .FindAllIncludingAsync(
                    tp => tp.Temporada.Actual && tp.Competicion.Nombre.Equals(competicion) && tp.Categoria.Nombre.Equals(categoria) && tp.Jornada.NumeroJornada.Equals(jornada),
                    tp => tp.EquipoA, tp => tp.EquipoB).ConfigureAwait(false);
                carrusel.Partidos = _mapper.Map<List<TemporadaPartidoDTO>, List<TemporadaPartidoViewModel>>(partidos.ToList());
                foreach (var partido in carrusel.Partidos)
                {
                    ICollection<AlineacionDTO> aliactualA = await _alineacionRepository
                        .FindAllIncludingAsync(
                        ap => ap.Competicion.Nombre.Equals(partido.Competicion) && ap.Equipo.Equipo.Nombre.Equals(partido.EquipoA) && ap.Jornada.Id.Equals(partido.JornadaId), //&& ap.Jornada.NumeroJornada.Equals(partido.Jornada),
                        ap => ap.Jugador, ap => ap.Club, ap => ap.Puesto).ConfigureAwait(false);
                    ICollection<AlineacionDTO> aliactualB = await _alineacionRepository
                        .FindAllIncludingAsync(
                        ap => ap.Competicion.Nombre.Equals(partido.Competicion) && ap.Equipo.Equipo.Nombre.Equals(partido.EquipoB) && ap.Jornada.Id.Equals(partido.JornadaId), //&& ap.Jornada.NumeroJornada.Equals(partido.Jornada),
                        ap => ap.Jugador, ap => ap.Club, ap => ap.Puesto).ConfigureAwait(false);

                    // alineacion de la jornada anterior
                    ICollection<AlineacionDTO> alipreviaA = null;
                    ICollection<AlineacionDTO> alipreviaB = null;
                    if (partido.Jornada>1)
                    {
                        alipreviaA = await _alineacionRepository
                            .FindAllIncludingAsync(
                            ap => ap.Competicion.Nombre.Equals(partido.Competicion) && ap.Equipo.Equipo.Nombre.Equals(partido.EquipoA) && ap.Jornada.NumeroJornada.Equals(partido.Jornada-1) && ap.Temporada_ID.Equals(temporada.Id),
                            ap => ap.Jugador, ap => ap.Club, ap => ap.Puesto).ConfigureAwait(false);
                        alipreviaB = await _alineacionRepository
                            .FindAllIncludingAsync(
                            ap => ap.Competicion.Nombre.Equals(partido.Competicion) && ap.Equipo.Equipo.Nombre.Equals(partido.EquipoB) && ap.Jornada.NumeroJornada.Equals(partido.Jornada-1) && ap.Temporada_ID.Equals(temporada.Id),
                            ap => ap.Jugador, ap => ap.Club, ap => ap.Puesto).ConfigureAwait(false);
                    }

                    TemporadaClasificacionDTO clasificacionEquipoA = new TemporadaClasificacionDTO();
                    TemporadaClasificacionDTO clasificacionEquipoB = new TemporadaClasificacionDTO();
                    var resultado = LigamaniaUtils.ResultadoPartido(clasificacionEquipoA, clasificacionEquipoB, aliactualA, aliactualB, goleadores);

                    partido.ResultadoA = resultado.Item1.p1;
                    partido.ResultadoB = resultado.Item1.p2;
                    partido.AlineacionEquipoA = _mapper.Map<List<AlineacionDTO>, List<AlineacionViewModel>>(aliactualA.ToList());
                    partido.AlineacionEquipoB = _mapper.Map<List<AlineacionDTO>, List<AlineacionViewModel>>(aliactualB.ToList());

                    var lAliPreviaA = alipreviaA?.Select(a => a.Jugador.Nombre).ToList();
                    var lAliPreviaB = alipreviaB?.Select(a => a.Jugador.Nombre).ToList();

                    var lPreeliminados = preeliminados?.Select(pe => pe.Jugador.Nombre).ToList();
                    var lEliminados = eliminados?.Select(e => e.Jugador.Nombre).ToList();

                    LigamaniaUtils.CheckJugadoresAlineacion(partido.AlineacionEquipoA, lAliPreviaA, goleadores, lPreeliminados, lEliminados, eliminadosPrevios,null);
                    LigamaniaUtils.CheckJugadoresAlineacion(partido.AlineacionEquipoB, lAliPreviaB, goleadores, lPreeliminados, lEliminados, eliminadosPrevios, null);

                    // Añadido para Copa
                    TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(tempcomp.CompeticionId).ConfigureAwait(false);
                    TemporadaRondaDTO infoRonda = await _temporadaRondaRepository.FindIncludingAsync(tr => tr.Temporada.Actual
                        && tr.CompeticionID.Equals(tempcomp.CompeticionId) && tr.Activa, tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);
                    carrusel.JornadaActual = jornadaActual!=null ? jornadaActual.NumeroJornada: 0;
                    carrusel.RondaActual = infoRonda != null ? infoRonda.NumRonda : 0;

                }
            }
            return carrusel;
        }

        //private void CheckJugadoresAlineacion(List<AlineacionViewModel> alineacionActual, ICollection<string> aliprevia, 
        //    ICollection<TemporadaJornadaJugadorDTO> goleadores, ICollection<string> preeliminados, ICollection<string> eliminados, ICollection<string> eliminadosPrevios)
        //{
        //    foreach(var ali in alineacionActual)
        //    {
        //        if (aliprevia == null)
        //            ali.Cambiado = true;
        //        else if (!aliprevia.Contains(ali.Jugador))
        //            ali.Cambiado = true;
        //        else
        //            ali.Cambiado = false;

        //        ali.Preeliminado = preeliminados!=null ? preeliminados.Contains(ali.Jugador) : false;
        //        ali.Eliminado = eliminados != null ? eliminados.Contains(ali.Jugador) || eliminadosPrevios.Contains(ali.Jugador) : false;

        //        var goleador = goleadores.FirstOrDefault(g => g.Jugador.Nombre.Equals(ali.Jugador));
        //        if ( goleador != null) { ali.GF = goleador.GolesFavor; ali.GC = goleador.GolesContra; }
        //    }
        //}

        #endregion
    }
}
