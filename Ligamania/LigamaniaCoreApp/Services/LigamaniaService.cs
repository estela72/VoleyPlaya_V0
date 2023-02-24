using AutoMapper;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Helpers;
using LigamaniaCoreApp.Models.AdminViewModels;
using LigamaniaCoreApp.Models.GlobalViewModels;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using LigamaniaCoreApp.Services;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Services
{
    // TODO: agregar _logger y añadir try catch en todas las operaciones devolviendo Response (success o error)

    // Me tiene que dar información del estado actual de Ligamanía
    public class LigamaniaService : ILigamaniaService
    {
        private readonly IOptions<AppSettings> _appSettings;

        private readonly ITemporadaCompeticionRepository _temporadaCompeticionRepository;
        private readonly INoticiaRepository _noticiaRepository;
        private readonly ITemporadaJugadorRepository _temporadaJugadorRepository;
        private readonly ITemporadaClasificacionRepository _temporadaClasificacionRepository;
        private readonly ICompeticionCategoriaRepository _competicionCategoriaRepository;
        private readonly ITemporadaCompeticionJornadaRepository _temporadaCompeticionJornadaRepository;
        private readonly ITemporadaCompeticionCategoriaReferenciaRepository _temporadaCategoriaReferenciaRepository;
        private readonly ITemporadaRepository _temporadaRepository;
        private readonly ISettingsRepository _settingsRepository;
        private readonly IClubRepository _clubRepository;
        private readonly IPuestoRepository _puestoRepository;
        private readonly IEquipoRepository _equipoRepository;
        private readonly ITemporadaEquipoRepository _temporadaEquipoRepository;
        private readonly ICalendarioRepository _calendarioRepository;
        private readonly ICalendarioDetalleRepository _calendarioDetalleRepository;
        private readonly ITemporadaJornadaJugadorRepository _temporadaJornadaJugadorRepository;
        private readonly ITemporadaCompeticionCategoriaRepository _temporadaCompeticionCategoriaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LigamaniaService> _logger;
        private readonly IAlineacionRepository _alineacionRepository;
        private readonly IInvitadoService _invitadoService;

        public readonly int MaxJornada = 34;
        public readonly int JornadasEliminado = 5;
        public readonly int MaxVecesEliminado = 3;

        public LigamaniaService(
              IOptions<AppSettings> appSettings
            , ITemporadaCompeticionRepository temporadaCompeticionRepository
            , INoticiaRepository noticiaRepository
            , ITemporadaJugadorRepository temporadaJugadorRepository
            , ITemporadaClasificacionRepository temporadaClasificacionRepository
            , ICompeticionCategoriaRepository competicionCategoriaRepository
            , ITemporadaCompeticionJornadaRepository temporadaCompeticionJornadaRepository
            , ITemporadaCompeticionCategoriaReferenciaRepository temporadaCategoriaReferenciaRepository
            , ITemporadaRepository temporadaRepository
            , ISettingsRepository settingsRepository
            , IClubRepository clubRepository
            , IPuestoRepository puestoRepository
            , IEquipoRepository equipoRepository
            , ITemporadaEquipoRepository temporadaEquipoRepository
            , ICalendarioRepository calendarioRepository
            , ICalendarioDetalleRepository calendarioDetalleRepository
            , ITemporadaJornadaJugadorRepository temporadaJornadaJugadorRepository
            , IAlineacionRepository alineacionRepository
            , ITemporadaCompeticionCategoriaRepository temporadaCompeticionCategoriaRepository
            , IInvitadoService invitadoService
            ,IMapper mapper
            ,ILogger<LigamaniaService> logger
            )
        {
            _appSettings = appSettings;
            MaxJornada = _appSettings.Value.JornadaMaximaLiga;
            JornadasEliminado = _appSettings.Value.JornadasEliminado;
            MaxVecesEliminado = _appSettings.Value.MaxVecesEliminado;

            _temporadaCompeticionRepository = temporadaCompeticionRepository;
            _noticiaRepository = noticiaRepository;
            _temporadaJugadorRepository = temporadaJugadorRepository;
            _temporadaClasificacionRepository = temporadaClasificacionRepository;
            _competicionCategoriaRepository = competicionCategoriaRepository;
            _temporadaCompeticionJornadaRepository = temporadaCompeticionJornadaRepository;
            _temporadaCategoriaReferenciaRepository = temporadaCategoriaReferenciaRepository;
            _temporadaRepository = temporadaRepository;
            _settingsRepository = settingsRepository;
            _clubRepository = clubRepository;
            _puestoRepository = puestoRepository;
            _equipoRepository = equipoRepository;
            _temporadaEquipoRepository = temporadaEquipoRepository;
            _calendarioDetalleRepository = calendarioDetalleRepository;
            _calendarioRepository = calendarioRepository;
            _temporadaJornadaJugadorRepository = temporadaJornadaJugadorRepository;
            _alineacionRepository = alineacionRepository;
            _temporadaCompeticionCategoriaRepository = temporadaCompeticionCategoriaRepository;
            _invitadoService = invitadoService;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<SelectList> GetAllCategorias(string competicion)
        {
            ICollection<CompeticionCategoriaDTO> lista = await _competicionCategoriaRepository.GetByCompeticion(competicion)
                                                                                               .ConfigureAwait(true);
            return new SelectList(lista.Select(cc => cc.Categoria.Nombre).ToList());
        }

        public async Task<SelectList> GetAllTemporadas()
        {
            ICollection<TemporadaDTO> lista = await _temporadaRepository.GetAllAsyn().ConfigureAwait(false);
            return new SelectList(lista.OrderByDescending(t=>t.Nombre).Select(t=>t.Nombre).ToList());
        }
        public async Task<SelectList> GetAllClubs(bool activo)
        {
            ICollection<ClubDTO> clubs = await _clubRepository.FindAllAsync(c => c.Baja == !activo).ConfigureAwait(false);
            return new SelectList(clubs.OrderBy(t => t.Nombre).Select(t => t.Nombre).ToList());
        }
        public async Task<SelectList> GetAllClubs(bool activo,string selectedClub)
        {
            ICollection<ClubDTO> clubs = await _clubRepository.FindAllAsync(c => c.Baja == !activo).ConfigureAwait(false);
            return new SelectList(clubs.OrderBy(t => t.Nombre).Select(t => t.Nombre).ToList(),selectedClub);
        }

        public async Task<SelectList> GetAllPuestos()
        {
            ICollection<PuestoDTO> puestos = await _puestoRepository.GetAllAsyn().ConfigureAwait(false);
            return new SelectList(puestos.OrderBy(t => t.Orden).Select(t => t.Nombre).ToList());
        }
        public async Task<SelectList> GetAllCompeticiones()
        {
            ICollection<CompeticionDTO> lista = await _competicionCategoriaRepository.GetAllCompeticiones().ConfigureAwait(false);
            return new SelectList(lista.Select(cc => cc.Nombre).ToList());
        }
        public async Task<SelectList> GetCompeticionesActivas()
        {
            var temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            ICollection<TemporadaCompeticionDTO> lista = await _temporadaCompeticionRepository.GetCompeticionesActivas(temporada).ConfigureAwait(false);
            return new SelectList(lista.Select(cc => cc.Competicion.Nombre).ToList());
        }

        public async Task<List<string>> GetCompeticionesActivasStr()
        {
            var temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            ICollection<TemporadaCompeticionDTO> lista = await _temporadaCompeticionRepository.GetCompeticionesActivas(temporada).ConfigureAwait(false);
            return lista.Select(cc => cc.Competicion.Nombre).ToList();
        }

        public async Task<SelectList> GetEquiposTemporadaActual(string competicion)
        {
            var temporadaEquipos = await _temporadaEquipoRepository.FindAllIncludingAsync(te => te.Temporada.Actual && te.Competicion.Nombre.Equals(competicion) && !te.Baja,
                te => te.Equipo).ConfigureAwait(false);
            return new SelectList(temporadaEquipos.Select(e => e.Equipo.Nombre).OrderBy(n=>n).ToList());
        }
        public async Task<SelectList> GetEquiposTemporadaActual(string competicion, string categoria)
        {
            var temporadaEquipos = await _temporadaEquipoRepository.FindAllIncludingAsync(te => te.Temporada.Actual 
            && te.Competicion.Nombre.Equals(competicion)
            && te.Categoria.Nombre.Equals(categoria) && !te.Baja,
                te => te.Equipo).ConfigureAwait(false);
            return new SelectList(temporadaEquipos.Select(e => e.Equipo.Nombre).OrderBy(n => n).ToList());
        }
        public async Task<SelectList> GetEquiposSinCategoria(string competicion)
        {
            //ICollection<Equipo_DTO> equipos = await _equipoRepository.GetAllAsyn();
            //Temporada_DTO preTemporada = await _temporadaRepository.GetPreTemporada();
            //ICollection<TemporadaEquipo_DTO> temporadaEquipos = await _temporadaEquipoRepository.GetEquiposTemporadaNoEnCompeticion(preTemporada.Id,competicion);
            //ICollection<Equipo_DTO> equiposEnTemporada = temporadaEquipos.Select(te => te.Equipo).ToList();

            //// seleccionar todos los equipos que están en 'equipos' y no están en 'equiposEnTemporada'
            //var equiposNoTemporada = equipos.Where(e => !equiposEnTemporada.Contains(e)).OrderBy(e=>e.Nombre).ToList();

            //return new SelectList(equiposNoTemporada.Select(e => e.Nombre).ToList());

            ICollection<EquipoDTO> equipos = await _equipoRepository.FindAllAsync(e => !e.Baja).ConfigureAwait(false);
            TemporadaDTO preTemporada = await _temporadaRepository.GetPreTemporada().ConfigureAwait(false);
            TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository.GetCompeticion(preTemporada.Id, competicion).ConfigureAwait(false);
            ICollection<TemporadaEquipoDTO> temporadaEquipos = await _temporadaEquipoRepository.GetEquiposCompeticion(temporadaCompeticion).ConfigureAwait(false);
            temporadaEquipos = temporadaEquipos.Where(te => !te.Baja).ToList();

            var equiposSinCompeticion = equipos.Except(temporadaEquipos.Select(te => te.Equipo)).ToList();

            return new SelectList(equiposSinCompeticion.Select(e => e.Nombre).OrderBy(e=>e).ToList());
        }
        public async Task<SelectList> GetCalendarios()
        {
            ICollection<CalendarioDTO> calendarios = await _calendarioRepository.GetAllAsyn().ConfigureAwait(false);
            return new SelectList(calendarios.Select(c => c.Nombre).ToList());
        }
        public async Task<SelectList> GetAllJornadasLiga()
        {
            TemporadaCompeticionDTO temporadaCompeticion = await GetCompeticionLiga().ConfigureAwait(false);
            ICollection<TemporadaCompeticionJornadaDTO> jornadas = await GetJornadasCompeticion(temporadaCompeticion).ConfigureAwait(false);
            return new SelectList(jornadas, "NumeroJornada", "Fecha");
        }
        public async Task<SelectList> GetAllJornadasPasadas(string competicion)
        {
            var jornadas = await _temporadaCompeticionJornadaRepository
                .FindAllIncludingAsync(
                tcj => tcj.Temporada.Actual && tcj.Competicion.Nombre.Equals(competicion) && tcj.Fecha <= DateTime.Today,
                tcj => tcj.Competicion).ConfigureAwait(false);
            return new SelectList(jornadas, "NumeroJornada", "Fecha");
        }
        public async Task<SelectList> GetJugadoresPorPuestoTemporada(string puesto)
        {
            var jugadoresPuesto = await _temporadaJugadorRepository.FindAllIncludingAsync(tj => tj.Temporada.Actual && tj.Activo && tj.Puesto.Nombre.Equals(puesto), tj=>tj.Jugador, tj=>tj.Club).ConfigureAwait(false);
            jugadoresPuesto = jugadoresPuesto.OrderBy(j => j.Club.Alias).ThenBy(j => j.Jugador.Nombre).ToList();
            var lista = jugadoresPuesto.Select(j => new { Id = j.Jugador.Id, Texto = j.Club.Alias + " - " + j.Jugador.Nombre });
            var selectList = new SelectList(lista,"Texto","Texto");
            
            return selectList;
        }

        private async Task<ICollection<TemporadaCompeticionJornadaDTO>> GetJornadasCompeticion(TemporadaCompeticionDTO temporadaCompeticion)
        {
            var jornadas = await _temporadaCompeticionJornadaRepository
                .FindAllIncludingAsync(tcj => tcj.TemporadaId.Equals(temporadaCompeticion.TemporadaId)
                    && tcj.CompeticionId.Equals(temporadaCompeticion.CompeticionId),
                    tcj => tcj.Competicion).ConfigureAwait(false);
            return jornadas;
        }
        private async Task<TemporadaCompeticionDTO> GetCompeticionLiga(string temporada="")   // de la temporada actual
        {
            if (string.IsNullOrEmpty(temporada))
            {
                var temporadaCompeticion = await _temporadaCompeticionRepository
                    .FindIncludingAsync(tc => tc.Temporada.Actual && tc.Activa && tc.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Liga), tc=>tc.Temporada, tc => tc.Competicion).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    temporadaCompeticion = await _temporadaCompeticionRepository
                    .FindIncludingAsync(tc => tc.Temporada.Actual && tc.Activa && tc.Competicion.Nombre.Equals("Pretemporada"), tc => tc.Temporada, tc => tc.Competicion).ConfigureAwait(true);
                return temporadaCompeticion;
            }
            var temporadaCompeticion1 = await _temporadaCompeticionRepository
                .FindIncludingAsync(tc => tc.Temporada.Nombre.Equals(temporada) && tc.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Liga), tc => tc.Temporada, tc => tc.Competicion).ConfigureAwait(false);
            if (temporadaCompeticion1 == null)
                temporadaCompeticion1 = await _temporadaCompeticionRepository
                .FindIncludingAsync(tc => tc.Temporada.Nombre.Equals(temporada) && tc.Competicion.Nombre.Equals("Pretemporada"), tc => tc.Temporada, tc => tc.Competicion).ConfigureAwait(true);
            return temporadaCompeticion1;

        }
        public async Task<TemporadaCompeticionDTO> GetCompeticionLigaActual()
        {
            var temporadaCompeticion = await _temporadaCompeticionRepository
                .FindIncludingAsync(tc => tc.Temporada.Actual && tc.Activa && tc.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Liga), tc => tc.Temporada, tc => tc.Competicion).ConfigureAwait(false);
            if (temporadaCompeticion == null)
                temporadaCompeticion = await _temporadaCompeticionRepository
                .FindIncludingAsync(tc => tc.Temporada.Actual && tc.Activa && tc.Competicion.Nombre.Equals("Pretemporada"), tc => tc.Temporada, tc => tc.Competicion).ConfigureAwait(true);
            return temporadaCompeticion;
        }

        public async Task<IDictionary<string, string>> GetEstadoCompeticiones()
        {
            var temporadaCompeticions = await _temporadaCompeticionRepository.GetCompeticionesActivas().ConfigureAwait(false);
            Dictionary<string, string> dict = temporadaCompeticions.ToDictionary(tc => tc.Competicion.Nombre, tc => tc.DescripcionEstado);
            return dict;
        }
        public async Task<string> GetLastNew()
        {
            try
            {
                NoticiaDTO lastNew = await _noticiaRepository.GetLastNew().ConfigureAwait(false);
                if (lastNew != null)
                {
                    var noticia = $"[{lastNew.Fecha.ToLocalTime().ToShortDateString()}] {lastNew.Texto}";
                    return noticia;
                }
                return string.Empty;
            }
            catch
            { return string.Empty;}
        }
        public async Task<ICollection<NoticiaViewModel>> GetAllNews()
        {
            ICollection<NoticiaDTO> noticias = await _noticiaRepository.FindAllAsync(n => n.Activa).ConfigureAwait(false);

            ICollection<NoticiaViewModel> noticiasVM = new List<NoticiaViewModel>();
            foreach(var noticia in noticias)
            {
                NoticiaViewModel noticiaVM = _mapper.Map<NoticiaViewModel>(noticia);
                noticiasVM.Add(noticiaVM);
            }
            return noticiasVM.OrderByDescending(n=>n.Fecha).ToList();
        }

        public async Task<ICollection<JugadorEliminadoViewModel>> GetJugadoresEliminados()
        {
            List<JugadorEliminadoViewModel> lista = new List<JugadorEliminadoViewModel>();
            // si no hay temporada actual, no mostrar jugadores eliminados
            TemporadaDTO temporada = _temporadaRepository.GetActual();
            if (temporada == null) return lista;

            ICollection<TemporadaJugadorDTO> jugadores = await _temporadaJugadorRepository.GetJugadoresEliminados().ConfigureAwait(false);

            foreach (var jugador in jugadores)
            {
                JugadorEliminadoViewModel jugadorVM = _mapper.Map<JugadorEliminadoViewModel>(jugador);
                jugadorVM.JornadaVuelta =
                    (jugador.LastJornadaEliminacion.NumeroJornada + JornadasEliminado > MaxJornada || jugador.VecesEliminado >= MaxVecesEliminado) ? "No vuelve"
                    : (jugador.LastJornadaEliminacion.NumeroJornada + JornadasEliminado).ToString();
                lista.Add(jugadorVM);
            }
            return lista.OrderBy(j=>j.JornadaEliminado).ToList();
        }
        public async Task<ICollection<JugadorEliminadoViewModel>> GetJugadoresPreEliminados()
        {
            List<JugadorEliminadoViewModel> lista = new List<JugadorEliminadoViewModel>();
            // si no hay temporada actual, no mostrar jugadores eliminados
            TemporadaDTO temporada = _temporadaRepository.GetActual();
            if (temporada == null) return lista;

            ICollection<TemporadaJugadorDTO> jugadores = await _temporadaJugadorRepository.GetJugadoresPreEliminados().ConfigureAwait(false);

            foreach (var jugador in jugadores)
            {
                JugadorEliminadoViewModel jugadorVM = _mapper.Map<JugadorEliminadoViewModel>(jugador);
                jugadorVM.JornadaVuelta =
                      (jugador.LastJornadaEliminacion?.NumeroJornada + JornadasEliminado > MaxJornada || jugador.VecesEliminado >= 3) ? "No vuelve"
                      : (jugador.LastJornadaEliminacion?.NumeroJornada + JornadasEliminado).ToString();
                lista.Add(jugadorVM);
            }
            return lista.OrderBy(j => j.JornadaEliminado).ToList();

        }

        public async Task<int> GetJornadaCarrusel()
        {
            TemporadaDTO temporada = _temporadaRepository.GetActual();
            if (temporada == null) return 0;

            var competicionLiga = await _temporadaCompeticionRepository.GetLiga(temporada.Id).ConfigureAwait(false);
            if (competicionLiga != null)
            {
                var jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(competicionLiga.CompeticionId).ConfigureAwait(false);
                return jornadaCarrusel != null ? jornadaCarrusel.NumeroJornada : 0;
            }
            return 0;
        }
        public async Task<int> GetJornadaActual()
        {
            TemporadaDTO temporada = _temporadaRepository.GetActual();
            if (temporada == null) return 0;

            var competicionLiga = await _temporadaCompeticionRepository.GetLiga(temporada.Id).ConfigureAwait(false);
            if (competicionLiga != null)
            {
                var jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(competicionLiga.CompeticionId).ConfigureAwait(false);
                return jornadaActual != null ? jornadaActual.NumeroJornada : 0;
            }
            return 0;
        }
        public async Task<int> GetJornadaCarrusel(string competicion)
        {
            TemporadaDTO temporada = _temporadaRepository.GetActual();
            if (temporada == null) return 0;

            var competicionLiga = await _temporadaCompeticionRepository.GetCompeticion(temporada.Id, competicion).ConfigureAwait(false);
            if (competicionLiga != null)
            {
                var jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(competicionLiga.CompeticionId).ConfigureAwait(false);
                return jornadaCarrusel != null ? jornadaCarrusel.NumeroJornada : 0;
            }
            return 0;
        }
        public async Task<int> GetJornadaActual(string competicion)
        {
            TemporadaDTO temporada = _temporadaRepository.GetActual();
            if (temporada == null) return 0;

            var competicionLiga = await _temporadaCompeticionRepository.GetCompeticion(temporada.Id, competicion).ConfigureAwait(false);
            if (competicionLiga != null)
            {
                var jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(competicionLiga.CompeticionId).ConfigureAwait(false);
                return jornadaActual != null ? jornadaActual.NumeroJornada : 0;
            }
            return 0;
        }

        public async Task<IQueryable<JugadorEliminadoViewModel>> GetJugadoresEliminadosQueryable()
        {
            IQueryable<TemporadaJugadorDTO> jugadores = await _temporadaJugadorRepository.GetJugadoresEliminadosQueryable().ConfigureAwait(false);

            List<JugadorEliminadoViewModel> lista = new List<JugadorEliminadoViewModel>();
            foreach (var jugador in jugadores)
            {
                JugadorEliminadoViewModel jugadorVM = _mapper.Map<JugadorEliminadoViewModel>(jugador);
                jugadorVM.JornadaVuelta =
                    (jugador.LastJornadaEliminacion.NumeroJornada + JornadasEliminado > MaxJornada || jugador.VecesEliminado >= 3) ? "No vuelve"
                    : (jugador.LastJornadaEliminacion.NumeroJornada + JornadasEliminado).ToString();
                lista.Add(jugadorVM);
            }
            return lista.OrderBy(j => j.JornadaEliminado).AsQueryable();
        }

        public async Task<ICollection<ClasificacionViewModel>> GetClasificaciones()
        {
            List<ClasificacionViewModel> clasificaciones = new List<ClasificacionViewModel>();
            // si no hay temporada actual, no mostrar jugadores eliminados
            TemporadaDTO temporada = _temporadaRepository.GetActual();
            if (temporada == null) return clasificaciones;

            return await GetClasificacionesTemporada().ConfigureAwait(false);
        }

        public async Task<ICollection<ClasificacionViewModel>> GetClasificacionesVuelta2()
        {
            List<ClasificacionViewModel> clasificaciones = new List<ClasificacionViewModel>();
            // si no hay temporada actual, no mostrar jugadores eliminados
            TemporadaDTO temporada = _temporadaRepository.GetActual();
            if (temporada == null) return clasificaciones;

            return await GetClasificacionesTemporadaVuelta2().ConfigureAwait(false);
        }

        public async Task<ICollection<ClasificacionViewModel>> GetClasificacionesTemporadaVuelta2(string nombreTemporada = "")
        {
            try
            {
                TemporadaCompeticionDTO tempcomp = await GetCompeticionLiga(nombreTemporada).ConfigureAwait(false);
                ICollection<CompeticionCategoriaDTO> categorias = await _competicionCategoriaRepository.GetByCompeticion(tempcomp.Competicion.Nombre).ConfigureAwait(false);
                CompeticionDTO competicion = categorias.First().Competicion;
                ICollection<TemporadaClasificacionDTO> jornadasDisponibles = await _temporadaClasificacionRepository.FindAllIncludingAsync(tc => tc.Temporada.Id.Equals(tempcomp.TemporadaId) &&
                    tc.CompeticionId.Equals(tempcomp.CompeticionId), tc => tc.Jornada).ConfigureAwait(false);
                int maxJornada = jornadasDisponibles.Max(tc => tc.Jornada.NumeroJornada);

                TemporadaCompeticionJornadaDTO jornada = jornadasDisponibles.FirstOrDefault(j => j.Jornada.NumeroJornada.Equals(maxJornada)).Jornada;
                //TemporadaCompeticionJornadaDTO jornada = jornadasDisponibles.FirstOrDefault(j => j.Jornada.Actual).Jornada;
                ICollection<ClasificacionViewModel> clasiJornadaActual = 
                    await GetClasificacioneTemporadaJornada(tempcomp, categorias, competicion, jornada).ConfigureAwait(false);

                //int numEquipos = clasiJornadaActual.First().Equipos.Count;
                var totJornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(j => j.Temporada.Actual).ConfigureAwait(false);
                var mx = totJornadas.Max(j => j.NumeroJornada);
                var md = mx / 2;
                if (maxJornada < md)
                    return clasiJornadaActual;

                TemporadaCompeticionJornadaDTO jornadaIniVuelta2 = jornadasDisponibles.FirstOrDefault(j => j.Jornada.NumeroJornada.Equals(md)).Jornada;
                ICollection<ClasificacionViewModel> clasiJornadaIniVuelta2 = 
                    await GetClasificacioneTemporadaJornada(tempcomp, categorias, competicion, jornadaIniVuelta2).ConfigureAwait(false);

                ICollection<ClasificacionViewModel> clasificacion = new List<ClasificacionViewModel>();
                foreach(var clasiActual in clasiJornadaActual)
                {
                    ClasificacionViewModel nueva = new ClasificacionViewModel(clasiActual.Categoria);
                    var clasiIni = clasiJornadaIniVuelta2.FirstOrDefault(c => c.Categoria.Equals(clasiActual.Categoria));
                    foreach(var equiActual in clasiActual.Equipos)
                    {
                        var equiIni = clasiIni.Equipos.FirstOrDefault(e => e.Equipo.Equals(equiActual.Equipo));
                        // actual - inicial (inicial es totalJornadas/2)
                        var nuevoEquipo = new EquipoClasificacionViewModel
                        {
                            Equipo = equiActual.Equipo,
                            Empatados = equiActual.Empatados - equiIni.Empatados,
                            Ganados = equiActual.Ganados - equiIni.Ganados,
                            GolesContra = equiActual.GolesContra - equiIni.GolesContra,
                            GolesFavor = equiActual.GolesFavor - equiIni.GolesFavor,
                            GolesExtraContra = equiActual.GolesExtraContra - equiIni.GolesExtraContra,
                            GolesExtraFavor = equiActual.GolesExtraFavor - equiIni.GolesExtraFavor,
                            Jugados = equiActual.Jugados - equiIni.Jugados,
                            Perdidos = equiActual.Perdidos - equiIni.Perdidos,
                            Premio = null,
                            Puesto = equiActual.Puesto - equiIni.Puesto,
                            PuestoSinBot = equiActual.PuestoSinBot - equiIni.PuestoSinBot,
                            Puntos = equiActual.Puntos - equiIni.Puntos
                        };
                        nuevoEquipo.Diferencia = nuevoEquipo.GolesFavor - nuevoEquipo.GolesContra;
                        nueva.Equipos.Add(nuevoEquipo);
                    }
                    nueva.Equipos = nueva.Equipos.OrderByDescending(p => p.Puntos)
                        .ThenByDescending(p=>p.GolesFavor).ThenByDescending(p=>p.Diferencia)
                        .ToList();
                    for (int i = 0; i < nueva.Equipos.Count; i++)
                        nueva.Equipos[i].PuestoSinBot = i + 1;
                    clasificacion.Add(nueva);
                }
                return clasificacion;
            }
            catch (Exception x)
            {
                return null;
            }
        }

        public async Task<ICollection<ClasificacionViewModel>> GetClasificacionLigaParaCopa(string nombreTemporada = "")
        {
            TemporadaDTO tempActual = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            TemporadaCompeticionDTO tempCompCopa = await _temporadaCompeticionRepository.GetCompeticion(tempActual.Id, LigamaniaConst.Competicion_Copa).ConfigureAwait(false);
            TemporadaCompeticionDTO tempcomp = await GetCompeticionLiga().ConfigureAwait(false);
            ICollection<CompeticionCategoriaDTO> categorias = await _competicionCategoriaRepository.GetByCompeticion(tempcomp.Competicion.Nombre).ConfigureAwait(false);
            CompeticionDTO competicion = categorias.First().Competicion;
            TemporadaCompeticionJornadaDTO jornada = await _temporadaCompeticionJornadaRepository.GetJornada(tempActual.Id, tempcomp.Competicion.Id, tempCompCopa.Competicion.JornadaCuadro).ConfigureAwait(false);
            return await GetClasificacioneTemporadaJornada(tempcomp, categorias, competicion, jornada, usarMarca:true, descripcionContains: "copa").ConfigureAwait(false);
        }


        public async Task<ICollection<ClasificacionViewModel>> GetClasificacionesTemporada(string nombreTemporada="")
        {
            try
            {
                TemporadaCompeticionDTO tempcomp = await GetCompeticionLiga(nombreTemporada).ConfigureAwait(false);
                ICollection<CompeticionCategoriaDTO> categorias = await _competicionCategoriaRepository.GetByCompeticion(tempcomp.Competicion.Nombre).ConfigureAwait(false);
                CompeticionDTO competicion = categorias.First().Competicion;
                ICollection<TemporadaClasificacionDTO> jornadasDisponibles = await _temporadaClasificacionRepository.FindAllIncludingAsync(tc => tc.Temporada.Id.Equals(tempcomp.TemporadaId) &&
                    tc.CompeticionId.Equals(tempcomp.CompeticionId), tc => tc.Jornada).ConfigureAwait(false);
                int maxJornada = jornadasDisponibles.Max(tc => tc.Jornada.NumeroJornada);
                TemporadaCompeticionJornadaDTO jornada = jornadasDisponibles.FirstOrDefault(j => j.Jornada.NumeroJornada.Equals(maxJornada)).Jornada;
                return await GetClasificacioneTemporadaJornada(tempcomp, categorias, competicion, jornada).ConfigureAwait(false);
            }
            catch(Exception x)
            {
                return null;
            }
        }

        private async Task<ICollection<ClasificacionViewModel>> GetClasificacioneTemporadaJornada
            (TemporadaCompeticionDTO tempcomp, ICollection<CompeticionCategoriaDTO> categorias, CompeticionDTO competicion, TemporadaCompeticionJornadaDTO jornada, bool usarMarca=true,
            string descripcionContains="")
        {
            List<ClasificacionViewModel> lista = new List<ClasificacionViewModel>();
            foreach (var categoria in categorias)
            {
                var temporadaCompCat = await _temporadaCompeticionCategoriaRepository.GetCategoria(tempcomp.Temporada.Id, tempcomp.Competicion.Id, categoria.Categoria_Id).ConfigureAwait(false);
                ICollection<TemporadaCompeticionCategoriaReferenciaDTO> referencias = await _temporadaCategoriaReferenciaRepository.GetReferencias(competicion.Id, categoria.Categoria_Id, usarMarca, descripcionContains).ConfigureAwait(false);
                ICollection<TemporadaClasificacionDTO> clasificaciones = await _temporadaClasificacionRepository.GetClasificaciones(competicion.Id, categoria.Categoria.Id, jornada.Id).ConfigureAwait(false);
                if (jornada == null || !clasificaciones.Any())
                {
                    ICollection<TemporadaEquipoDTO> equipos = await _temporadaEquipoRepository.FindAllIncludingAsync(
                        te => te.Temporada.Actual && te.CompeticionId.Equals(tempcomp.CompeticionId) && te.CategoriaId.Equals(categoria.Categoria_Id), te => te.Equipo).ConfigureAwait(false);
                    ClasificacionViewModel clasiInicial = new ClasificacionViewModel(categoria.Categoria.Nombre);

                    foreach (var equipo in equipos)
                    {
                        clasiInicial.Equipos.Add(new EquipoClasificacionViewModel(equipo.Equipo.Nombre));
                    }
                    lista.Add(clasiInicial);
                }
                else
                {
                    ICollection<TemporadaClasificacionDTO> clasificacionesSinBot = await _temporadaClasificacionRepository.GetClasificacionesSinBot(competicion.Id, categoria.Categoria.Id, jornada.Id).ConfigureAwait(false);
                    ClasificacionViewModel clasificacionVM = LigamaniaUtils.SetClasificacionViewModel(_mapper,
                                                                                                      competicion,
                                                                                                      categoria,
                                                                                                      referencias,
                                                                                                      clasificaciones,
                                                                                                      clasificacionesSinBot,
                                                                                                      temporadaCompCat);
                    lista.Add(clasificacionVM);
                }
            }
            return lista;
        }

        public IQueryable<byte[]> GetImgClasificacionTemporada(string temporada)
        {
            return _temporadaRepository.GetImg_Clasificacion(temporada);
        }

        public async Task<SettingsViewModel> GetSettings()
        {
            SettingsDTO settings = _settingsRepository.GetSettings();
            SettingsViewModel settingsViewModel = _mapper.Map<SettingsViewModel>(settings);
            return await Task.FromResult(settingsViewModel).ConfigureAwait(false);
        }

        public async Task<Response> EstablecerConfiguracion(SettingsViewModel settings)
        {
            try
            {
                SettingsDTO settingsDto = _settingsRepository.GetSettings();
                settingsDto.ClasificacionRotuloCopa = settings.VerRotuloCopa;
                settingsDto.TemporadaPremios = settings.TemporadaPremios;
                settingsDto.VerCuadroCopa = settings.VerCuadroCopa;
                settingsDto.VerEquiposPretemporada = settings.VerEquiposPretemporada;
                settingsDto.VerNoticias = settings.VerNoticias;
                settingsDto.NumeroJornadasVolverEliminados = settings.NumeroJornadasVolverEliminados;
                settingsDto.NotificacionClasificaciones = settings.NotificacionClasificaciones;
                await _settingsRepository.UpdateAsyn(settingsDto, settingsDto.Id).ConfigureAwait(false);
                await _settingsRepository.SaveAsync().ConfigureAwait(false);

                return new Response() { Message = "Configuración modificada", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error guardando la configuración: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Tuple<string,string>> GetCompeticionLigaUsuario(string user)
        {
            string competicion = string.Empty;
            string categoria = string.Empty;

            var temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            var temporadaEquipo = await _temporadaEquipoRepository.GetEquiposActivosUser(temporada.Id, user).ConfigureAwait(false);
            var compLiga = await GetCompeticionLiga().ConfigureAwait(false);

            var comp = temporadaEquipo.OrderBy(te=>te.Competicion.Orden).ThenBy(te=>te.Categoria.Orden)
                .FirstOrDefault(te => te.Competicion.Tipo!=null && te.Competicion.Tipo.Value.Equals((int)eTipoCompeticion.Liga)
                && compLiga.CompeticionId.Equals(te.CompeticionId));
            if (comp != null) return new Tuple<string,string>(comp.Competicion.Nombre,comp.Categoria.Nombre);

            return new Tuple<string, string>(competicion,categoria);
        }
        private async Task<Dictionary<string,Dictionary<string, int>>> GetJugadoresNumVecesAlineadoPorCategoria()
        {
            //var temporadaCompeticion = await GetCompeticionLiga().ConfigureAwait(false);
            //TemporadaCompeticionJornadaDTO jornada = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.CompeticionId).ConfigureAwait(false);

            // lista de jornadas actuales (de todas las competiciones activas)
            var temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            if (temporada == null) return null;
            ICollection<TemporadaCompeticionDTO> competiciones = await _temporadaCompeticionRepository.GetCompeticionesActivas(temporada).ConfigureAwait(false);
            List<int> competicionesActivas = competiciones.Select(tc => tc.CompeticionId).ToList();

            ICollection<TemporadaCompeticionJornadaDTO> jornadas = await _temporadaCompeticionJornadaRepository
                .FindAllAsync(tcj => competicionesActivas.Contains(tcj.CompeticionId) && tcj.Carrusel).ConfigureAwait(false);
            List<int> jornadasActivas = jornadas.Select(tcj => tcj.Id).ToList();

            ICollection<AlineacionDTO> jugadoresAlineadosJornada = await _alineacionRepository
                .FindAllIncludingAsync(a => a.Temporada.Actual && jornadasActivas.Contains(a.Jornada_ID),
                a => a.Competicion, a => a.Categoria, a => a.Jugador, a => a.Club, a => a.Puesto).ConfigureAwait(false);

            var jugadoresGroupByCompeticionCategoria = jugadoresAlineadosJornada
                .GroupBy(j => new { Jugador = j.Jugador.Nombre })
                .ToDictionary(grp => grp.Key.Jugador,
                              grp => grp.GroupBy(jj => new { Competicion = jj.Competicion.Nombre, Categoria = jj.Categoria.Nombre })
                                        .ToDictionary(grp2 => grp2.Key.Competicion + "." + grp2.Key.Categoria, grp2 => grp2.Count()));

            return jugadoresGroupByCompeticionCategoria;
        }
        public async Task<List<TemporadaJornadaJugadorViewModel>> GetJugadoresPorCategoria()
        {
            var jugadoresEliminados = await GetJugadoresEliminados().ConfigureAwait(false);
            var listJugadoresEliminados = jugadoresEliminados.Select(j => j.Jugador).ToList();
            var jugadoresPreeliminados = await GetJugadoresPreEliminados().ConfigureAwait(false);
            var listJugadoresPreeliminados = jugadoresPreeliminados.Select(j => j.Jugador).ToList();
            List<TemporadaJornadaJugadorViewModel> jugadores = new List<TemporadaJornadaJugadorViewModel>();

            var dictJugadores = await GetJugadoresNumVecesAlineadoPorCategoria().ConfigureAwait(false);
            if (dictJugadores == null) return null;
            foreach(var jug in dictJugadores)
            {
                TemporadaJornadaJugadorViewModel jugador = new TemporadaJornadaJugadorViewModel
                {
                    Jugador = jug.Key,
                    Eliminado = listJugadoresEliminados.Contains(jug.Key),
                    Preeliminado = listJugadoresPreeliminados.Contains(jug.Key),
                    VecesPorCompeticionCategoria = jug.Value
                };
                jugadores.Add(jugador);
            }
            return jugadores.OrderBy(j=>j.Jugador).ToList();
        }

        public async Task<List<ReglamentoViewModel>> GetAllDocumentos()
        {
            ICollection<ReglamentoViewModel> reglamentos = await _invitadoService.GetAllReglamentos().ConfigureAwait(false);
            return reglamentos.ToList();
        }

        //public Task<SelectList> GetAllPuestosPremios()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

