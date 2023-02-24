using AutoMapper;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Services
{
    // TODO: agregar _logger y añadir try catch en todas las operaciones devolviendo Response (success o error)

    public class InvitadoService : IInvitadoService
    {
        private readonly IHistoricoRepository _historicoRepository;
        private readonly IPuntuacionHistoricaRepository _puntuacionHistoricaRepository;
        private readonly ICambiosEquipoRepository _cambiosEquipoRepository;
        private readonly IEquipoRepository _equipoRepository;
        private readonly ITemporadaContabilidadRepository _contabilidadRepository;
        private readonly ITemporadaPremiosRepository _temporadaPremiosRepository;
        private readonly ITemporadaPremiosPuestoRepository _temporadaPremiosPuestoRepository;
        private readonly ITemporadaCompeticionJornadaRepository _temporadaCompeticionJornadaRepository;
        private readonly ITemporadaCuadroRepository _temporadaCuadroRepository;
        private readonly ITemporadaClasificacionRepository _temporadaClasificacionRepository;
        private readonly IDocumentsRepository _documentsRepository;
        private readonly ITemporadaCompeticionRepository _temporadaCompeticionRepository;
        private readonly ITemporadaCompeticionCategoriaRepository _temporadaCompeticionCategoriaRepository;
        private readonly ITemporadaPartidoRepository _temporadaPartidoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvitadoService> _logger;
        private readonly ITemporadaRepository _temporadaRepository;
        private readonly ITemporadaEquipoRepository _temporadaEquipoRepository;

        public InvitadoService(
            IHistoricoRepository historicoRepository
            , IPuntuacionHistoricaRepository puntuacionHistoricaRepository
            , ICambiosEquipoRepository cambiosEquipoRepository
            , IEquipoRepository equipoRepository
            , ITemporadaContabilidadRepository contabilidadRepository
            , ITemporadaPremiosRepository temporadaPremiosRepository
            , ITemporadaPremiosPuestoRepository temporadaPremiosPuestoRepository
            , ITemporadaCompeticionJornadaRepository temporadaCompeticionJornadaRepository
            , ITemporadaCuadroRepository temporadaCuadroRepository
            , ITemporadaClasificacionRepository temporadaClasificacionRepository
            , IDocumentsRepository documentsRepository
            , ITemporadaCompeticionRepository temporadaCompeticionRepository
            , ITemporadaCompeticionCategoriaRepository temporadaCompeticionCategoriaRepository
            , ITemporadaPartidoRepository temporadaPartidoRepository
            , ITemporadaRepository temporadaRepository
            , ITemporadaRondaRepository temporadaRondaRepository
            , ITemporadaEquipoRepository temporadaEquipoRepository
            , IMapper mapper
            , ILogger<InvitadoService> logger
            )
        {
            _historicoRepository = historicoRepository;
            _puntuacionHistoricaRepository = puntuacionHistoricaRepository;
            _cambiosEquipoRepository = cambiosEquipoRepository;
            _equipoRepository = equipoRepository;
            _contabilidadRepository = contabilidadRepository;
            _temporadaPremiosRepository = temporadaPremiosRepository;
            _temporadaPremiosPuestoRepository = temporadaPremiosPuestoRepository;
            _temporadaCompeticionJornadaRepository = temporadaCompeticionJornadaRepository;
            _temporadaCuadroRepository = temporadaCuadroRepository;
            _temporadaClasificacionRepository = temporadaClasificacionRepository;
            _documentsRepository = documentsRepository;
            _temporadaCompeticionRepository = temporadaCompeticionRepository;
            _temporadaCompeticionCategoriaRepository = temporadaCompeticionCategoriaRepository;
            _temporadaPartidoRepository = temporadaPartidoRepository;
            _temporadaRepository = temporadaRepository;
            _temporadaEquipoRepository = temporadaEquipoRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ICollection<HistorialViewModel>> GetHistorial()
        {
            ICollection<HistoricoDTO> historicos = await _historicoRepository.GetHistorial().ConfigureAwait(false);
            List<HistorialViewModel> historialViewModels = new List<HistorialViewModel>();
            var temporadas = historicos
                .GroupBy(h => h.Temporada.Id)
                .Select(grp => grp.First().Temporada)
                .ToList();
            foreach (var temporada in temporadas)
            {
                HistorialViewModel historialVM = new HistorialViewModel()
                {
                    Temporada = temporada.Nombre,
                    //ImgClasificacion = temporada.ImgClasificacion,
                    CategoriasHistoricas = new List<CategoriaHistoricaViewModel>()
                };
                var tempCompCategorias = historicos
                    .Where(h => h.Temporada.Id.Equals(temporada.Id) && !h.TemporadaCompeticionCategoria.Competicion.Nombre.Equals("Pretemporada"))
                    .GroupBy(h => h.TemporadaCompeticionCategoria.Id)
                    .Select(grp => grp.First().TemporadaCompeticionCategoria)
                    .ToList();
                // tengo todos los cambios de nombre de equipo
                // si un equipo cambió de nombre, para la clasificación histórica se deben sumar como uno solo
                ICollection<CambiosEquipoDTO> cambiosEquipos = await _cambiosEquipoRepository.FindAllIncludingAsync(c=>!c.EquipoOrigen.EsBot, c => c.Temporada, c => c.EquipoDestino, c => c.EquipoOrigen).ConfigureAwait(false);
                List<EquipoDTO> equiposCambiados = cambiosEquipos.Select(c => c.EquipoOrigen).ToList();

                foreach (var tempCompCategoria in tempCompCategorias)
                {
                    CategoriaHistoricaViewModel categoriaVM = new CategoriaHistoricaViewModel()
                    {
                        Competicion = tempCompCategoria.Competicion.Nombre,
                        Categoria = tempCompCategoria.Categoria.Nombre,
                        Orden = tempCompCategoria.Competicion.Orden,
                        Premios = new List<PremioHistoricoViewModel>()
                    };
                    int minPremio = 1;
                    int maxPremio = 3;
                    //if (tempCompCategoria.Competicion.esCopa) maxPremio = 2;
                    if (tempCompCategoria.Competicion.EsSupercopa) maxPremio = 2;

                    // los equipos que participaron en esta competición
                    List<HistoricoDTO> equipos = historicos
                        .Where(h => h.Temporada.Nombre.Equals(temporada.Nombre) && h.Categoria_ID.Equals(tempCompCategoria.Id)
                        && ((h.Puesto >= minPremio && h.Puesto <= maxPremio) || h.Pichichi))
                        .ToList();
                    foreach (HistoricoDTO equipo in equipos)
                    {
                        // si el equipo es uno de los que cambió de nombre, no se debe tener en cuenta como equipo real
                        if (equiposCambiados.Contains(equipo.TemporadaEquipo.Equipo)) continue;

                        if (!tempCompCategoria.Competicion.EsCopa)
                        {
                            EPremio pre = (EPremio)(equipo.Puesto);
                            string premioStr = pre.ToString();
                            if (equipo.Puesto == 3)
                                premioStr = "Tercero";

                            PremioHistoricoViewModel premioVM = new PremioHistoricoViewModel()
                            {
                                Equipo = equipo.TemporadaEquipo.Equipo.Nombre,
                                Premio = pre,
                                EsPichichi = equipo.Pichichi,
                                PremioTxt = premioStr
                            };
                            categoriaVM.Premios.Add(premioVM);
                        }
                        else  // para Copa, tenemos que mirar en el cuadro para ver en qué ronda cayó cada equipo
                        {
                            int rondaEliminado = await GetRondaCuadroEliminado(temporada.Id, equipo.TemporadaEquipo.Equipo.Nombre).ConfigureAwait(false);
                            EPremio premio = GetPuestoPremio(rondaEliminado);
                            if (premio == EPremio.Desconocido)
                                premio = await GetPremioCuadro(temporada.Id, equipo.TemporadaEquipo.Equipo.Nombre, rondaEliminado).ConfigureAwait(false);
                            if (premio == EPremio.Desconocido)
                                premio = (EPremio)equipo.Puesto;

                            if (premio.Equals(EPremio.Campeon) || premio.Equals(EPremio.Subcampeon))
                            {
                                PremioHistoricoViewModel premioVM = new PremioHistoricoViewModel()
                                {
                                    Equipo = equipo.TemporadaEquipo.Equipo.Nombre,
                                    Premio = premio,
                                    PremioTxt = premio.ToString(),
                                    EsPichichi = equipo.Pichichi
                                };
                                categoriaVM.Premios.Add(premioVM);
                            }
                        }
                    }
                    // por cada equipo cambiado, añadir la info de este equipo al equipo por el que cambió
                    foreach(var equipoCambiado in cambiosEquipos)
                    {
                        HistoricoDTO historico = equipos.FirstOrDefault(e => e.TemporadaEquipo.Equipo.Nombre.Equals(equipoCambiado.EquipoOrigen.Nombre));
                        if (historico!=null)
                        {
                            if (!tempCompCategoria.Competicion.EsCopa)
                            {
                                EPremio pre = (EPremio)(historico.Puesto);
                                string premioStr = pre.ToString();
                                if (historico.Puesto == 3)
                                    premioStr = EPremio.Tercero.ToString();
                                PremioHistoricoViewModel premioVM = new PremioHistoricoViewModel()
                                {
                                    Equipo = equipoCambiado.EquipoDestino.Nombre + " ("+historico.TemporadaEquipo.Equipo.Nombre+")",
                                    Premio = pre,
                                    PremioTxt = premioStr,
                                    EsPichichi = historico.Pichichi
                                };
                                categoriaVM.Premios.Add(premioVM);
                            }
                            else  // para Copa, tenemos que mirar en el cuadro para ver en qué ronda cayó cada equipo
                            {
                                int rondaEliminado = await GetRondaCuadroEliminado(temporada.Id, historico.TemporadaEquipo.Equipo.Nombre).ConfigureAwait(false);
                                EPremio premio = GetPuestoPremio(rondaEliminado);
                                if (premio == EPremio.Desconocido)
                                    premio = await GetPremioCuadro(temporada.Id, historico.TemporadaEquipo.Equipo.Nombre, rondaEliminado).ConfigureAwait(false);
                                if (premio.Equals(EPremio.Campeon) || premio.Equals(EPremio.Subcampeon))
                                {
                                    PremioHistoricoViewModel premioVM = new PremioHistoricoViewModel()
                                    {
                                        Equipo = equipoCambiado.EquipoDestino.Nombre + " (" + historico.TemporadaEquipo.Equipo.Nombre + ")",
                                        Premio = premio,
                                        PremioTxt = premio.ToString(),
                                        EsPichichi = historico.Pichichi
                                    };
                                    categoriaVM.Premios.Add(premioVM);
                                }
                            }
                        }
                    }
                    historialVM.CategoriasHistoricas.Add(categoriaVM);
                }
                historialViewModels.Add(historialVM);
            }
            return historialViewModels;
        }

        private async Task<EPremio> GetPremioCuadro(int temporadaId, string equipo, int maxRonda)
        {
            var partido = await _temporadaCuadroRepository.FindAsync(tc => tc.TemporadaId.Equals(temporadaId) && (tc.NombreEquipoA.Equals(equipo) || tc.NombreEquipoB.Equals(equipo)) && tc.Ronda == maxRonda).ConfigureAwait(false);
            if (partido == null) return EPremio.Desconocido;
            if (string.IsNullOrEmpty(partido.NombreGanador)) return EPremio.Desconocido;
            if (partido.NombreGanador.Equals(equipo)) return EPremio.Campeon;
            return EPremio.Subcampeon;
        }

        private EPremio GetPuestoPremio(int rondaEliminado)
        {
            switch (rondaEliminado)
            {
                case 1: return EPremio.PrimeraRonda;
                case 2: return EPremio.SegundaRonda;
                case 3: return EPremio.Dieciseisavos;
                case 4: return EPremio.Octavos;
                case 5: return EPremio.Cuartos;
                case 6: return EPremio.Semifinales;
                case 7:
                case 0:
                    return EPremio.Desconocido;
                default: return EPremio.Previa;
            }
        }

        //Devuelve la ronda en la que fue eliminado. De todas las rondas en las que participó, la última
        private async Task<int> GetRondaCuadroEliminado(int temporadaId, string equipo)
        {
            var rondas = await _temporadaCuadroRepository.FindAllAsync(tc => tc.TemporadaId.Equals(temporadaId) && (tc.NombreEquipoA.Equals(equipo) || tc.NombreEquipoB.Equals(equipo))).ConfigureAwait(false);
            if (rondas.Any())
            {
                var maxRonda = rondas.Max(r => r.Ronda);
                return maxRonda;
            }
            return (int)EPremio.Desconocido;
        }

        public async Task<HistorialEquipoViewModel> GetHistorialEquipo(string equipo)
        {
            if (equipo.Contains("("))
            {
                var index = equipo.IndexOf('(');
                equipo = equipo.Substring(0, index).Trim();
            }
            HistorialEquipoViewModel historial = new HistorialEquipoViewModel(equipo);

            ICollection<HistoricoDTO> historiaEquipo = await _historicoRepository.GetHistoriaEquipo(equipo).ConfigureAwait(false);

            // obtener la lista de temporadas en las que participó
            // por cada temporada, tengo que obtener: Categoria_Liga, Puesto_Liga, FuePichichi, Puesto_Copa, Puesto_Supercopa
            // con esta info construyo HistoriaEquipoTemporadaViewModel para cada temporada
            Dictionary<string, List<HistoricoDTO>> historiaPorTemporada = historiaEquipo.GroupBy(h => h.Temporada.Nombre)
                .ToDictionary(h => h.Key, h => h.ToList());

            double coeficiente = 0;
            int puntos = 0;
            foreach (KeyValuePair<string, List<HistoricoDTO>> temporada in historiaPorTemporada)
            {
                List<HistoricoDTO> historicos = temporada.Value;
                HistoriaEquipoTemporadaViewModel historia = new HistoriaEquipoTemporadaViewModel();
                historia.Temporada = temporada.Key;
                var historialTemporada = await GetHistorialTemporada(historicos, historia).ConfigureAwait(false);
                coeficiente += historialTemporada.Item1;
                puntos += historialTemporada.Item2;
                historial.InfoTemporada.Add(temporada.Key, historia);
            }

            ICollection<CambiosEquipoDTO> cambiosEquipo = await _cambiosEquipoRepository
                .FindAllIncludingAsync(c => !c.EquipoOrigen.EsBot && c.EquipoDestino.Nombre.Equals(equipo),
                    c => c.Temporada, c => c.EquipoDestino, c => c.EquipoOrigen)
                .ConfigureAwait(false);
            if (cambiosEquipo.Any())
            {
                foreach(var cambioEquipo in cambiosEquipo)
                {
                    ICollection<HistoricoDTO> historiaEquipoCambio = await _historicoRepository.GetHistoriaEquipo(cambioEquipo.EquipoOrigen.Nombre).ConfigureAwait(false);

                    // obtener la lista de temporadas en las que participó
                    // por cada temporada, tengo que obtener: Categoria_Liga, Puesto_Liga, FuePichichi, Puesto_Copa, Puesto_Supercopa
                    // con esta info construyo HistoriaEquipoTemporadaViewModel para cada temporada
                    Dictionary<string, List<HistoricoDTO>> historiaPorTemporadaCambio = historiaEquipoCambio.GroupBy(h => h.Temporada.Nombre)
                        .ToDictionary(h => h.Key, h => h.ToList());
                    foreach (KeyValuePair<string, List<HistoricoDTO>> temporada in historiaPorTemporadaCambio)
                    {
                        List<HistoricoDTO> historicos = temporada.Value;
                        HistoriaEquipoTemporadaViewModel historia = new HistoriaEquipoTemporadaViewModel();
                        historia.Temporada = temporada.Key;
                        var historialTemporada = await GetHistorialTemporada(historicos, historia).ConfigureAwait(false);
                        coeficiente += historialTemporada.Item1;
                        puntos += historialTemporada.Item2;
                        historial.InfoTemporada.Add(temporada.Key, historia);
                    }
                    foreach (var histCambio in historiaEquipoCambio)
                        historiaEquipo.Add(histCambio);
                }
            }


            historial.Puntos = puntos;
            historial.Coeficiente = coeficiente;
            Dictionary<string, List<HistoricoDTO>> historiaPorCategoria = historiaEquipo
                .GroupBy(h => h.TemporadaCompeticionCategoria.Competicion.Nombre + "-" + h.TemporadaCompeticionCategoria.Categoria.Nombre)
                .ToDictionary(h => h.Key, h => h.ToList());

            // tenemos la información agrupada por categoría en la que participó el equipo
            // obtener las temporadas en las que fue campeón, subcambpeón, tercero y pichichi en cada categoría
            foreach (KeyValuePair<string, List<HistoricoDTO>> categoria in historiaPorCategoria)
            {
                List<HistoricoDTO> historicos = categoria.Value;
                HistoriaEquipoCategoriaViewModel historia = new HistoriaEquipoCategoriaViewModel();
                historia.Categoria = GetInfoCategoria(categoria.Key);

                historia.TempCampeon = historicos.Where(h => h.Puesto == 1).Select(h => h.Temporada.Nombre).ToList();
                historia.TempSubcampeon = historicos.Where(h => h.Puesto == 2).Select(h => h.Temporada.Nombre).ToList();
                historia.TempTercero = historicos.Where(h => h.Puesto == 3).Select(h => h.Temporada.Nombre).ToList();
                historia.TempPichichi = historicos.Where(h => h.Pichichi).Select(h => h.Temporada.Nombre).ToList();

                historial.InfoCategoria.Add(historia.Categoria, historia);
            }

            return historial;
        }
        public async Task<ClasificacionHistoricaViewModel> GetClasificacionHistorica()
        {
            ClasificacionHistoricaViewModel model = new ClasificacionHistoricaViewModel();
            ICollection<PuntuacionHistoricaDTO> puntuaciones = await _puntuacionHistoricaRepository
                .GetAllPuntuaciones().ConfigureAwait(false);
            model.LPuntuaciones = new List<PuntuacionHistoricaViewModel>();
            foreach (var punt in puntuaciones)
            {
                var puntuacionVM = _mapper.Map<PuntuacionHistoricaViewModel>(punt);
                model.LPuntuaciones.Add(puntuacionVM);
            }

            model.LClasificacion = new Dictionary<string, HistorialEquipoViewModel>();
            var equipos = _equipoRepository.GetAll();

            // tengo todos los cambios de nombre de equipo
            // si un equipo cambió de nombre, para la clasificación histórica se deben sumar como uno solo
            ICollection<CambiosEquipoDTO> cambiosEquipos = await _cambiosEquipoRepository.FindAllIncludingAsync(c => !c.EquipoOrigen.EsBot, c => c.Temporada, c => c.EquipoDestino, c => c.EquipoOrigen).ConfigureAwait(false);
            List<EquipoDTO> equiposCambiados = cambiosEquipos.Select(c => c.EquipoOrigen).ToList();

            foreach (var equipo in equipos)
            {
                if (equipo.EsBot) continue;
                // si el equipo es uno de los que cambió de nombre, no se debe tener en cuenta como equipo real
                if (equiposCambiados.Contains(equipo)) continue;
                try
                {
                    HistorialEquipoViewModel historial = new HistorialEquipoViewModel(equipo.Nombre);
                    double coeficiente = 0;
                    int puntos = 0;

                    ICollection<HistoricoDTO> historiaEquipo = await _historicoRepository.GetHistoriaEquipo(equipo.Nombre).ConfigureAwait(false);
                    HistoriaEquipoTemporadaViewModel historia = new HistoriaEquipoTemporadaViewModel();
                    var historialTemporada = await GetHistorialTemporada(historiaEquipo.ToList(), historia).ConfigureAwait(false);
                    coeficiente = historialTemporada.Item1;
                    puntos = historialTemporada.Item2;

                    ICollection<CambiosEquipoDTO> cambiosEquipo = await _cambiosEquipoRepository
                        .FindAllIncludingAsync(c => !c.EquipoOrigen.EsBot && c.EquipoDestino.Nombre.Equals(equipo.Nombre),
                            c => c.Temporada, c => c.EquipoDestino, c => c.EquipoOrigen)
                        .ConfigureAwait(false);
                    if (cambiosEquipo.Any())
                    {
                        foreach (var cambioEquipo in cambiosEquipo)
                        {
                            ICollection<HistoricoDTO> historiaEquipoCambio = await _historicoRepository.GetHistoriaEquipo(cambioEquipo.EquipoOrigen.Nombre).ConfigureAwait(false);
                            HistoriaEquipoTemporadaViewModel historiaCambio = new HistoriaEquipoTemporadaViewModel();
                            var historialTemporadaCambio = await GetHistorialTemporada(historiaEquipoCambio.ToList(), historiaCambio).ConfigureAwait(false);
                            coeficiente += historialTemporadaCambio.Item1;
                            puntos += historialTemporadaCambio.Item2;
                        }
                    }

                    historial.Puntos = puntos;
                    historial.Coeficiente = coeficiente;
                    model.LClasificacion.Add(equipo.Nombre, historial);
                }
                catch(Exception x)
                {
                    _logger.LogError("Historial: Error al cargar historial del equipo: " + equipo.Nombre);
                }
            }

            return model;
        }
        private string GetInfoCategoria(string key)
        {
            var compCat = key.Split('-');
            var comp = compCat[0];
            var cat = compCat[1];
            if (comp.Equals(LigamaniaConst.Competicion_Liga))
                return cat;
            return comp;
        }

        private async Task<Tuple<double, int>> GetHistorialTemporada(List<HistoricoDTO> historicos, HistoriaEquipoTemporadaViewModel historia)
        {
            double coeficiente = 0;
            int puntos = 0;
            var historicoLigas = historicos.Where(h => h.TemporadaCompeticionCategoria.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Liga)).ToList();
            var historicoCopas = historicos.Where(h => h.TemporadaCompeticionCategoria.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Copa)).ToList();
            var historicoSupercopas = historicos.Where(h => h.TemporadaCompeticionCategoria.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Supercopa)).ToList();

            foreach (var historicoLiga in historicoLigas)
            {
                if (historicoLiga != null)
                {
                    historia.CategoriaLiga = historicoLiga.TemporadaCompeticionCategoria.Categoria.Nombre;
                    historia.Pichichi = historicoLiga.Pichichi;
                    historia.PuestoLiga = historicoLiga.Puesto;
                    puntos += _puntuacionHistoricaRepository.GetPuntuacion(historicoLiga.TemporadaCompeticionCategoria.CompeticionId,
                        historicoLiga.TemporadaCompeticionCategoria.CategoriaId, historicoLiga.Puesto, historicoLiga.Pichichi);
                    coeficiente += GetCoeficiente(historia.CategoriaLiga, historia.PuestoLiga);
                }
            }
            foreach (var historicoCopa in historicoCopas)
            {
                if (historicoCopa != null)
                {
                    historia.PuestoCopa = historicoCopa.Puesto;
                    puntos += _puntuacionHistoricaRepository.GetPuntuacion(historicoCopa.TemporadaCompeticionCategoria.CompeticionId,
                        historicoCopa.TemporadaCompeticionCategoria.CategoriaId, historicoCopa.Puesto, historicoCopa.Pichichi);
                    coeficiente += GetCoeficiente(LigamaniaConst.Competicion_Copa, historia.PuestoCopa);
                }
            }
            foreach (var historicoSupercopa in historicoSupercopas)
            {
                if (historicoSupercopa != null)
                {
                    historia.PuestoSupercopa = historicoSupercopa.Puesto;
                    puntos += _puntuacionHistoricaRepository.GetPuntuacion(historicoSupercopa.TemporadaCompeticionCategoria.CompeticionId,
                        historicoSupercopa.TemporadaCompeticionCategoria.CategoriaId, historicoSupercopa.Puesto, historicoSupercopa.Pichichi);
                    coeficiente += GetCoeficiente(LigamaniaConst.Competicion_Supercopa, historia.PuestoSupercopa);
                }
            }
            return await Task.FromResult(new Tuple<double, int>(coeficiente, puntos)).ConfigureAwait(false);
        }

        private double GetCoeficiente(string categoria, int puesto)
        {
            switch (categoria)
            {
                case LigamaniaConst.Categoria_Golden:
                    switch (puesto)
                    {
                        case (int)EPremio.Campeon:
                            return Math.Pow(10, 14);
                        case (int)EPremio.Subcampeon:
                            return Math.Pow(10, 11);
                        case (int)EPremio.Tercero:
                            return Math.Pow(10, 9);
                        default:
                            return Math.Pow(10, 1);
                    }
                case LigamaniaConst.Categoria_SilverA:
                case LigamaniaConst.Categoria_SilverB:
                    switch (puesto)
                    {
                        case (int)EPremio.Campeon:
                            return Math.Pow(10, 13);
                        case (int)EPremio.Subcampeon:
                            return Math.Pow(10, 8);
                        case (int)EPremio.Tercero:
                            return Math.Pow(10, 5);
                        default:
                            return Math.Pow(10, 0);
                    }
                case LigamaniaConst.Categoria_Bronze:
                    switch (puesto)
                    {
                        case (int)EPremio.Campeon:
                            return Math.Pow(10, 10);
                        case (int)EPremio.Subcampeon:
                            return Math.Pow(10, 4);
                        case (int)EPremio.Tercero:
                            return Math.Pow(10, 2);
                        default:
                            return Math.Pow(10, 0);
                    }
                case LigamaniaConst.Competicion_Copa:
                    switch (puesto)
                    {
                        case (int)EPremio.Campeon:
                            return Math.Pow(10, 12);
                        case (int)EPremio.Subcampeon:
                            return Math.Pow(10, 7);
                    }
                    break;
                case LigamaniaConst.Competicion_Supercopa:
                    switch (puesto)
                    {
                        case (int)EPremio.Campeon:
                            return Math.Pow(10, 6);
                        case (int)EPremio.Subcampeon:
                            return Math.Pow(10, 3);
                    }
                    break;
            }
            return 0;
        }

        public string GetImageCategoriaHistorial(string categoria, int puesto)
        {
            string path = string.Empty;
            //var cadenas = categoria.Split('-');
            //categoria = cadenas[1];
            switch (categoria)
            {
                case LigamaniaConst.Categoria_Golden:
                    switch (puesto)
                    {
                        case 1:
                            path = "Historia/Campeón golden.jpg";
                            break;
                        case 2:
                            path = "Historia/Segundo  Golden.jpg";
                            break;
                        case 3:
                            path = "Historia/Tercero Golden.jpg";
                            break;
                        case 4:
                            path = "Historia/pichichi golden.jpg";
                            break;
                    }

                    break;
                case LigamaniaConst.Categoria_SilverA:
                case LigamaniaConst.Categoria_SilverB:
                    switch (puesto)
                    {
                        case 1:
                            path = "Historia/Campeón silver.jpg";
                            break;
                        case 2:
                            path = "Historia/Segundo Silver.jpg";
                            break;
                        case 3:
                            path = "Historia/Tercero Silver.jpg";
                            break;
                        case 4:
                            path = "Historia/pichichi silver.jpg";
                            break;
                    }
                    break;
                case LigamaniaConst.Categoria_Bronze:
                    switch (puesto)
                    {
                        case 1:
                            path = "Historia/Campeón bronze.jpg";
                            break;
                        case 2:
                            path = "Historia/Segundo Bronze.jpg";
                            break;
                        case 3:
                            path = "Historia/Tercero Bronze.jpg";
                            break;
                        case 4:
                            path = "Historia/pichichi bronze.jpg";
                            break;
                    }
                    break;
                case LigamaniaConst.Competicion_Copa:
                    switch (puesto)
                    {
                        case 1:
                            path = "Historia/Campeón copa del rey.jpg";
                            break;
                        case 2:
                            path = "Historia/Subcampeón copa del rey.jpg";
                            break;
                    }
                    break;
                case LigamaniaConst.Competicion_Supercopa:
                    switch (puesto)
                    {
                        case 1:
                            path = "Historia/Campeón Supercopa.jpg";
                            break;
                        case 2:
                            path = "Historia/Subcampeon supercopa.jpg";
                            break;
                    }
                    break;
            }

            return path;
        }
        public async Task<PremiosViewModel> GetPremiosTemporada(string temporadaName)
        {
            TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            if (!string.IsNullOrEmpty(temporadaName))
                temporada = await _temporadaRepository.GetByNameAsync(temporadaName).ConfigureAwait(false);
            if (temporada == null)
                temporada = await _temporadaRepository.GetUltimaTemporadaEnJuego().ConfigureAwait(false);
            if (temporada == null) return new PremiosViewModel();

            ICollection<TemporadaEquipoDTO> equipos = await _temporadaEquipoRepository.GetEquiposTemporada(temporada.Id).ConfigureAwait(false);
            if (equipos == null) return new PremiosViewModel();

            return await GetPremiosTemporada(temporada, equipos).ConfigureAwait(false);
        }
        public async Task<PremiosViewModel> GetPremiosTemporada(TemporadaDTO temporada, ICollection<TemporadaEquipoDTO> equipos)
        {
            PremiosViewModel premiosVM = new PremiosViewModel();
            if (temporada == null) return premiosVM;
            var Premios = new List<PremioCompeticionViewModel>();
            premiosVM.Premios = Premios;
            premiosVM.Temporada = temporada.Nombre;
            Dictionary<string, List<TemporadaCompeticionJornadaDTO>> jornadas = new Dictionary<string, List<TemporadaCompeticionJornadaDTO>>();

            var numEquipos = equipos
                .Count(e => e.Temporada.Id.Equals(temporada.Id) && e.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Liga) && !e.Equipo.EsBot && !e.Baja && !e.Equipo.Baja);

            double gasto = 0;
            double recau = 0;
            double recauEquipo = 0;
            ICollection<TemporadaContabilidadDTO> contabilidad = await _contabilidadRepository.GetContabilidadByTemporada(temporada.Id).ConfigureAwait(false);
            contabilidad = contabilidad.OrderBy(c => c.Gasto).ToList();
            premiosVM.Contabilidad = _mapper.Map<List<TemporadaContabilidadDTO>, List<ContabilidadViewModel>>(contabilidad.ToList());

            gasto = contabilidad.Where(c => c.Gasto).Sum(c => c.Valor);
            recau = contabilidad.Where(c => !c.Gasto && !c.Equipo).Sum(c => c.Valor);
            recauEquipo = contabilidad.Where(c => !c.Gasto && c.Equipo).Sum(c => c.Valor);
            recau += (numEquipos * recauEquipo);
            var totalPremios = recau - gasto;

            premiosVM.Gastos = (int)Math.Round(gasto,MidpointRounding.AwayFromZero);
            premiosVM.NumEquipos = numEquipos;
            premiosVM.Recaudacion = (int)Math.Round(recau,MidpointRounding.AwayFromZero);
            premiosVM.TotalPremios = (int)Math.Round(totalPremios,MidpointRounding.AwayFromZero);

            var premios = await _temporadaPremiosRepository.GetPremiosByTemporada(temporada.Id).ConfigureAwait(false);
            if (premios == null) return premiosVM;
            foreach (var premio in premios)
            {
                var valor = (totalPremios * premio.PorcentajeAjustado) / 100F;
                var comp = premio.Categoria.Competicion.Nombre;
                if (premio.Categoria.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Liga))
                    comp += "-" + premio.Categoria.Categoria.Nombre;
                List<TemporadaCompeticionJornadaDTO> jornadasComp = jornadas.ContainsKey(comp) ? jornadas[comp] : null;
                if (jornadasComp == null)
                {
                    jornadasComp = _temporadaCompeticionJornadaRepository
                        .FindAll(tcj => tcj.TemporadaId.Equals(temporada.Id) && tcj.CompeticionId.Equals(premio.Categoria.CompeticionId)).ToList();
                    jornadas.Add(comp, jornadasComp);
                }
                int jornada = 1;
                if (jornadasComp != null && jornadasComp.Any()) jornada = jornadasComp.Max(c => c.NumeroJornada);

                var infoPremio = new PremioCompeticionViewModel
                {
                    Competicion = comp,
                    Porcentaje = premio.PorcentajeAjustado,
                    Premios = new List<PremioPuestoViewModel>(),
                    NombreCompeticion = premio.Categoria.Competicion.Nombre,
                    NombreCategoria = premio.Categoria.Categoria.Nombre
                };
                //var listaPremios = await _temporadaPremiosPuestoRepository.FindAllAsync(tpp => tpp.PremioCategoriaId.Equals(premio.Id));
                //listaPremios = listaPremios.OrderBy(tpp => tpp.Puesto).ToList();
                var listaPremios = premio.TemporadaPremiosPuesto.OrderBy(p => p.Puesto).ToList();
                foreach (var puesto in listaPremios)
                {
                    var info = new PremioPuestoViewModel
                    {
                        Puesto = (ePuestoCompeticion)puesto.Puesto,
                        Importe = puesto.Importe <= 0 ? (valor * puesto.PorcentajeAjustado) / 100F : puesto.Importe,
                        Equipo = await GetEquipo((ePuestoCompeticion)puesto.Puesto, premio.Categoria, jornada).ConfigureAwait(false)
                    };
                    infoPremio.Premios.Add(info);
                }
                Premios.Add(infoPremio);
            }
            premiosVM.Premios = Premios;
            return premiosVM;
        }
        private async Task<string> GetEquipo(ePuestoCompeticion puesto, TemporadaCompeticionCategoriaDTO tempCompCategoria, int jornada)
        {
            string equipo = string.Empty;
            if (tempCompCategoria.Competicion.EsCopa)
            {
                TemporadaCuadroDTO cuadro = await _temporadaCuadroRepository.GetLastPartidoCuadro(tempCompCategoria.Temporada.Id, tempCompCategoria.Competicion.Id).ConfigureAwait(false);
                if (cuadro != null  && cuadro.Criterio!=null)
                    if (puesto == ePuestoCompeticion.Primero)
                        return cuadro.NombreGanador;
                    else
                    {
                        if (cuadro.NombreGanador == cuadro.NombreEquipoA)
                            return cuadro.NombreEquipoB;
                        else
                            return cuadro.NombreEquipoA;
                    }
                return equipo;
            }
            else
            {
                EquipoDTO equipoClasificacion = await _temporadaClasificacionRepository.GetEquipoPuesto(tempCompCategoria.Temporada.Id,
                    tempCompCategoria.Competicion.Id, tempCompCategoria.Categoria.Id, puesto, jornada).ConfigureAwait(false);

                if (equipoClasificacion != null)
                    return equipoClasificacion.Nombre;
            }
            return equipo;
        }

        public async Task<ICollection<ReglamentoViewModel>> GetAllReglamentos()
        {
            ICollection<DocumentsDTO> documentos = await _documentsRepository.GetAllAsyn().ConfigureAwait(false);
            List<ReglamentoViewModel> lista = new List<ReglamentoViewModel>();
            foreach (var doc in documentos)
            {
                ReglamentoViewModel reglamento = _mapper.Map<ReglamentoViewModel>(doc);
                lista.Add(reglamento);
            }
            return lista;
        }
        public async Task<ReglamentoViewModel> FindReglamento(int fileId)
        {
            var documento = await _documentsRepository.GetAsync(fileId).ConfigureAwait(false);
            return _mapper.Map<ReglamentoViewModel>(documento);
        }
        public async Task<Response> SaveDocument(string descripcion, string filename, string contentType, byte[] bytes)
        {
            try
            {
                DocumentsDTO doc = new DocumentsDTO
                {
                    Content = bytes,
                    Description = descripcion,
                    ContentType = contentType,
                    Nombre = filename
                };
                await _documentsRepository.AddAsyn(doc).ConfigureAwait(false);
                await _documentsRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Result = true, Message = "Documento guardado", Status = EResponseStatus.Success};
            }
            catch (Exception x)
            {
                return new Response { Result = false, Message = "Error al guardar documento", Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> DeleteDocumento(int id)
        {
            try
            {
                var doc = _documentsRepository.GetById(id);
                if (doc != null)
                    await _documentsRepository.DeleteAsyn(doc).ConfigureAwait(false);
                await _documentsRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Result = true, Message = "Documento borrado", Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                return new Response { Result = false, Message = "Error al eliminar documento", Status = EResponseStatus.Error };
            }
        }
        public async Task<ICollection<CalendarioViewModel>> GetCalendarios()
        {
            ICollection<CalendarioViewModel> calendarios = new List<CalendarioViewModel>();
            var competicionesActivas = await _temporadaCompeticionRepository.GetCompeticiones().ConfigureAwait(false);
            foreach (var comp in competicionesActivas)
            {
                CalendarioViewModel calendario = new CalendarioViewModel
                {
                    Competicion = comp.Competicion.Nombre,
                    Orden = comp.Competicion.Orden,
                    Categorias = new List<CalendarioCategoriaViewModel>()
                };
                calendarios.Add(calendario);
                var categorias = await _temporadaCompeticionCategoriaRepository
                    .FindAllIncludingAsync(tcc => tcc.Temporada.Actual && tcc.CompeticionId.Equals(comp.CompeticionId),
                    tcc => tcc.Competicion, tcc => tcc.Categoria).ConfigureAwait(false);
                var jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                    tcj => tcj.Temporada.Actual && tcj.CompeticionId.Equals(comp.CompeticionId)).ConfigureAwait(false);
                foreach (var cat in categorias)
                {
                    CalendarioCategoriaViewModel categoria = new CalendarioCategoriaViewModel
                    {
                        Categoria = cat.Categoria.Nombre,
                        Orden = cat.Categoria.Orden,
                        Jornadas = new List<CalendarioCategoriaJornadaViewModel>()
                    };
                    calendario.Categorias.Add(categoria);
                    foreach (var jor in jornadas)
                    {
                        CalendarioCategoriaJornadaViewModel jornada = new CalendarioCategoriaJornadaViewModel
                        {
                            Jornada = jor.NumeroJornada,
                            Fecha = jor.Fecha,
                            Partidos = new List<TemporadaPartidoViewModel>()
                        };
                        categoria.Jornadas.Add(jornada);
                        ICollection<TemporadaPartidoDTO> partidos = await _temporadaPartidoRepository.FindAllIncludingAsync(
                            tp => tp.Temporada.Actual && tp.JornadaId.Equals(jor.Id) && tp.CategoriaId.Equals(cat.CategoriaId),
                            tp => tp.EquipoA, tp => tp.EquipoB).ConfigureAwait(false);
                        jornada.Partidos = _mapper.Map<List<TemporadaPartidoDTO>, List<TemporadaPartidoViewModel>>(partidos.ToList());
                    }
                    categoria.JornadaSelected = jornadas.FirstOrDefault(j => j.Actual) != null ? jornadas.FirstOrDefault(j => j.Actual).NumeroJornada : 1;
                }
            }
            return calendarios;
        }
    }
}
