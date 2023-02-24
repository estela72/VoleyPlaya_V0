using AutoMapper;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Models.AdminViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Services
{
    // TODO: agregar _logger y añadir try catch en todas las operaciones devolviendo Response (success o error)
    public class AdministradorService : IAdministradorService
    {
        private readonly IMapper _mapper;
        private readonly IClubRepository _clubRepository;
        private readonly IJugadorRepository _jugadorRepository;
        private readonly ITemporadaJugadorRepository _temporadaJugadorRepository;
        private readonly IPuestoRepository _puestoRepository;
        private readonly ILogger<AdministradorService> _logger;
        private readonly ITemporadaRepository _temporadaRepository;
        private readonly ITemporadaCompeticionRepository _temporadaCompeticionRepository;
        private readonly ITemporadaCompeticionJornadaRepository _temporadaCompeticionJornadaRepository;
        private readonly ITemporadaJornadaJugadorRepository _temporadaJornadaJugadorRepository;
        private readonly IAlineacionCambiosRepository _alineacionCambioRepository;
        private readonly IAlineacionPreviaRepository _alineacionPreviaRepository;

        public AdministradorService(IMapper mapper
            , ILogger<AdministradorService> logger
            , IClubRepository clubRepository
            , IJugadorRepository jugadorRepository
            , ITemporadaJugadorRepository temporadaJugadorRepository
            , IPuestoRepository puestoRepository
            , ITemporadaRepository temporadaRepository
            , ITemporadaCompeticionRepository temporadaCompeticionRepository
            , ITemporadaCompeticionJornadaRepository temporadaCompeticionJornadaRepository
            , ITemporadaJornadaJugadorRepository temporadaJornadaJugadorRepository
            , IAlineacionCambiosRepository alineacionCambiosRepository
            , IAlineacionPreviaRepository alineacionPreviaRepository
            )
        {
            _mapper = mapper;
            _logger = logger;
            _clubRepository = clubRepository;
            _jugadorRepository = jugadorRepository;
            _temporadaJugadorRepository = temporadaJugadorRepository;
            _puestoRepository = puestoRepository;
            _temporadaRepository = temporadaRepository;
            _temporadaCompeticionRepository = temporadaCompeticionRepository;
            _temporadaCompeticionJornadaRepository = temporadaCompeticionJornadaRepository;
            _temporadaJornadaJugadorRepository = temporadaJornadaJugadorRepository;
            _alineacionCambioRepository = alineacionCambiosRepository;
            _alineacionPreviaRepository = alineacionPreviaRepository;
        }

        public async Task<ICollection<ClubViewModel>> GetClubsViewModel()
        {
            var clubs = await _clubRepository.GetAllAsyn().ConfigureAwait(false);
            ICollection<ClubViewModel> clubViewModels = new List<ClubViewModel>();
            foreach (var club in clubs)
            {
                var clubVM = _mapper.Map<ClubViewModel>(club);
                clubViewModels.Add(clubVM);
            }
            return clubViewModels;
        }
        public async Task<ICollection<JugadorViewModel>> GetJugadoresViewModel()
        {
            ICollection<JugadorDTO> jugadores = await _jugadorRepository.GetAllAsyn().ConfigureAwait(false);
            ICollection<JugadorViewModel> jugadorViewModels = new List<JugadorViewModel>();
            foreach (var jugador in jugadores)
            {
                var jugadorVM = _mapper.Map<JugadorViewModel>(jugador);
                jugadorViewModels.Add(jugadorVM);
            }
            return jugadorViewModels;
        }
        public async Task<ICollection<TemporadaJugadorViewModel>> GetJugadoresViewModelFromTemporada(int temporadaId)
        {
            var jugadores = await GetJugadoresFromTemporada(temporadaId).ConfigureAwait(false);
            ICollection<TemporadaJugadorViewModel> jugadorViewModels = new List<TemporadaJugadorViewModel>();
            foreach (var jugador in jugadores)
            {
                var jugadorVM = _mapper.Map<TemporadaJugadorViewModel>(jugador);
                jugadorViewModels.Add(jugadorVM);
            }
            return jugadorViewModels;
        }
        async Task<ICollection<TemporadaJugadorDTO>> GetJugadoresFromTemporada(int temporadaId)
        {
            var jugadores = await _temporadaJugadorRepository.GetJugadoresFromTemporada(temporadaId).ConfigureAwait(false);
            jugadores = jugadores.GroupBy(j => new { j.Activo, Jugador = j.Jugador.Nombre, Club = j.Club.Nombre, Puesto = j.Puesto.Nombre })
                .Select(grp => grp.FirstOrDefault()).ToList();
            return jugadores;
        }

        public async Task<List<TemporadaJugadorViewModel>> GetAllJugadoresWithTemporada()
        {
            var jugadores = await _temporadaJugadorRepository.GetAllIncludingAsync(tj=>tj.Temporada,tj=>tj.Jugador,tj=>tj.Club,tj=>tj.Puesto).ConfigureAwait(false);
            List<TemporadaJugadorViewModel> lista = _mapper.Map<List<TemporadaJugadorDTO>, List<TemporadaJugadorViewModel>>(jugadores.ToList());
            return lista;
        }

        public async Task<ResponseOfTReturn<ClubViewModel>> AltaClub(int id)
        {
            return await AltaBajaClub(id, true).ConfigureAwait(false);
        }

        public async Task<ResponseOfTReturn<ClubViewModel>> BajaClub(int id)
        {
            return await AltaBajaClub(id, false).ConfigureAwait(false);
        }
        private async Task<ResponseOfTReturn<ClubViewModel>> AltaBajaClub(int id, bool alta)
        {
            string altaBaja = alta ? "Alta" : "Baja";
            try
            {
                var club = await _clubRepository.GetAsync(id).ConfigureAwait(false);
                if (club == null)
                {
                    ResponseOfTReturn<ClubViewModel> warnResponse = new ResponseOfTReturn<ClubViewModel>
                    {
                        Message = "No se encuentra el club con id " + id,
                        Result = false,
                        ResultDTO = null,
                        Status = EResponseStatus.Warning
                    };
                    return warnResponse;
                }

                club.Baja = !alta;
                club = await _clubRepository.UpdateAsyn(club, id).ConfigureAwait(false);
                if (club == null)
                {
                    ResponseOfTReturn<ClubViewModel> errorResponse = new ResponseOfTReturn<ClubViewModel>
                    {
                        Message = "Error al dar " + altaBaja + " de club con id " + id,
                        Result = false,
                        ResultDTO = null,
                        Status = EResponseStatus.Error
                    };
                    return errorResponse;
                }
                await _clubRepository.SaveAsync().ConfigureAwait(false);

                ResponseOfTReturn<ClubViewModel> response = new ResponseOfTReturn<ClubViewModel>
                {
                    Message = altaBaja + " de club " + club.Nombre,
                    Result = true,
                    ResultDTO = _mapper.Map<ClubViewModel>(club),
                    Status = EResponseStatus.Success
                };
                return response;
            }
            catch (Exception x)
            {
                return new ResponseOfTReturn<ClubViewModel> { Message = "Error realizando "+alta+" de un club: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<Response> CopiarJugadoresEntreTemporadas(int fromTemporada, int toTemporada)
        {
            try
            {
                Response response = new Response { Message = string.Empty, Result = true, Status = EResponseStatus.Success };
                var jugadoresFrom = await GetJugadoresFromTemporada(fromTemporada).ConfigureAwait(false);
                var jugadoresTo = await GetJugadoresFromTemporada(toTemporada).ConfigureAwait(false);
                List<TemporadaJugadorDTO> listaAgregar = new List<TemporadaJugadorDTO>();

                var jugadoresClubsActivos = jugadoresFrom.Where(j => !j.Club.Baja).ToList();
                foreach (var jugador in jugadoresClubsActivos)
                {
                    if (!jugadoresTo.Contains(jugador))
                    {
                        TemporadaJugadorDTO newJug = new TemporadaJugadorDTO
                        {
                            Activo = true,
                            Club = jugador.Club,
                            Eliminado = false,
                            Jugador = jugador.Jugador,
                            Puesto = jugador.Puesto,
                            Temporada_ID = toTemporada
                        };
                        listaAgregar.Add(newJug);
                    }
                }
                // insertar todos los jugadoresTo en la base de datos
                await _temporadaJugadorRepository.AddRangeAsyn(listaAgregar).ConfigureAwait(false);

                await _temporadaJugadorRepository.SaveAsync().ConfigureAwait(false);
                return response;
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error copiando jugadores entre temporadas: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }

        // Existe y está Activo
        // Existe y está Inactivo
        // No existe
        public eCheckJugadorResponse CheckNombreJugador(string jugadorName)
        {
            var jugador = _jugadorRepository.GetByName(jugadorName);
            if (jugador == null) return eCheckJugadorResponse.NoExiste;
            else if (jugador.Baja) return eCheckJugadorResponse.ExisteInactivo;
            return eCheckJugadorResponse.ExisteActivo;
        }
        public async Task<Response> AltaJugador(TemporadaJugadorViewModel jugadorInfo, TemporadaDTO preTemporada)
        {
            try
            {
                JugadorDTO nuevoJugador = null;
                var checkJugador = CheckNombreJugador(jugadorInfo.Jugador);
                // dar el alta en la tabla Jugadores
                if (checkJugador == eCheckJugadorResponse.NoExiste)
                {
                    JugadorDTO jugador = new JugadorDTO
                    {
                        Baja = false,
                        Nombre = jugadorInfo.Jugador
                    };
                    nuevoJugador = await _jugadorRepository.AddAsyn(jugador).ConfigureAwait(false);
                    await _jugadorRepository.SaveAsync().ConfigureAwait(false);
                }
                else if (checkJugador == eCheckJugadorResponse.ExisteInactivo)
                {
                    nuevoJugador = await _jugadorRepository.GetByNameAsync(jugadorInfo.Jugador).ConfigureAwait(false);
                    nuevoJugador.Baja = false;
                    await _jugadorRepository.UpdateAsyn(nuevoJugador, nuevoJugador.Id).ConfigureAwait(false);
                    await _jugadorRepository.SaveAsync().ConfigureAwait(false);
                }
                else
                {
                    //return new Response { Message = "El jugador ya existe y está activo", Result = false, Status = EResponseStatus.Error };
                    // el jugador existe, en la temporada actual y está activo.
                    // Como el usuario confirmó que lo quiere cambiar al club y puesto seleccionado, primero lo busco en la temporada actual y le doy de baja
                    nuevoJugador = await _jugadorRepository.GetByNameAsync(jugadorInfo.Jugador).ConfigureAwait(false);
                    var tempJug = await _temporadaJugadorRepository.FindAsync(tj => tj.Temporada_ID.Equals(preTemporada.Id) && tj.Jugador_ID.Equals(nuevoJugador.Id) && tj.Activo).ConfigureAwait(false);
                    if (tempJug != null)
                    {
                        await _temporadaJugadorRepository.DeleteAsyn(tempJug).ConfigureAwait(false);
                        await _temporadaJugadorRepository.SaveAsync().ConfigureAwait(false);
                    }
                }

                // buscar el club
                var club = await _clubRepository.GetByNameAsync(jugadorInfo.Club).ConfigureAwait(false);
                if (club == null)
                    return new Response { Message = "El club " + jugadorInfo.Club + " no existe", Result = false, Status = EResponseStatus.Error };

                // buscar el puesto
                var puesto = await _puestoRepository.GetByNameAsync(jugadorInfo.Puesto).ConfigureAwait(false);
                if (puesto == null)
                    return new Response { Message = "El puesto " + jugadorInfo.Puesto + " no existe", Result = false, Status = EResponseStatus.Error };

                // dar el alta en la tabla TemporadaJugador
                TemporadaJugadorDTO temporadaJugador = new TemporadaJugadorDTO
                {
                    Activo = true,
                    Eliminado = false,
                    Jugador = nuevoJugador,
                    PreEliminado = false,
                    Temporada = preTemporada,
                    VecesEliminado = 0,
                    VecesPreEliminado = 0,
                    Club = club,
                    Puesto = puesto
                };
                await _temporadaJugadorRepository.AddAsyn(temporadaJugador).ConfigureAwait(false);
                await _temporadaJugadorRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Jugador " + jugadorInfo.Jugador + " creado y/o activo", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error dando alta de jugador: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> EditarJugador(TemporadaJugadorViewModel jugadorInfo)
        {
            try
            {
                var jugador = await _jugadorRepository.GetAsync(jugadorInfo.IdJugador).ConfigureAwait(false);
                if (jugador == null)
                    return new Response { Message = "El jugador no existe", Result = false, Status = EResponseStatus.Error };

                jugador.Nombre = jugadorInfo.Jugador;
                jugador.Baja = !jugadorInfo.Activo;

                await _jugadorRepository.UpdateAsyn(jugador, jugadorInfo.IdJugador).ConfigureAwait(false);
                await _jugadorRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Jugador modificado", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error modificando de jugador: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> BorrarJugador(int idJugador)
        {
            try
            {
                var jugador = await _jugadorRepository.GetAsync(idJugador).ConfigureAwait(false);
                if (jugador == null)
                    return new Response { Message = "El jugador no existe", Result = false, Status = EResponseStatus.Error };

                //jugador.Nombre = jugadorInfo.Jugador;
                //jugador.Baja = true;

                await _jugadorRepository.DeleteAsyn(jugador).ConfigureAwait(false);
                await _jugadorRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Jugador borrado", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error borrando jugador: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> BajaJugador(int idJugador)
        {
            try
            {
                var jugador = await _jugadorRepository.GetAsync(idJugador).ConfigureAwait(false);
                if (jugador == null)
                    return new Response { Message = "El jugador no existe", Result = false, Status = EResponseStatus.Error };

                //jugador.Nombre = jugadorInfo.Jugador;
                jugador.Baja = true;

                await _jugadorRepository.UpdateAsyn(jugador, idJugador).ConfigureAwait(false);
                await _jugadorRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Baja del jugador", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error dando baja de jugador: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> BorrarTemporadaJugador(int idJugador)
        {
            try
            {
                var jugador = await _temporadaJugadorRepository.GetAsync(idJugador).ConfigureAwait(false);
                if (jugador == null)
                    return new Response { Message = "El jugador no existe", Result = false, Status = EResponseStatus.Error };

                //jugador.Nombre = jugadorInfo.Jugador;
                //jugador.Baja = true;
                // dar de baja al jugador en la tabla inventario
                Response bajaJugador = await BajaJugador(jugador.Jugador_ID).ConfigureAwait(false);
                if (!bajaJugador.Result)
                    return bajaJugador;

                await _temporadaJugadorRepository.DeleteAsyn(jugador).ConfigureAwait(false);
                await _temporadaJugadorRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Jugador borrado", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error borrando temporadajugador: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> BajaTemporadaJugador(int idJugador)
        {
            try
            {
                var jugador = await _temporadaJugadorRepository.GetAsync(idJugador).ConfigureAwait(false);
                if (jugador == null)
                    return new Response { Message = "El jugador no existe", Result = false, Status = EResponseStatus.Error };

                //jugador.Nombre = jugadorInfo.Jugador;
                jugador.Activo = false;

                await _temporadaJugadorRepository.UpdateAsyn(jugador, idJugador).ConfigureAwait(false);
                await _temporadaJugadorRepository.SaveAsync().ConfigureAwait(false);

                await BajaJugador(jugador.Jugador_ID).ConfigureAwait(false);

                return new Response { Message = "Baja del jugador", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error dando baja de temporadajugador: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> EditarTemporadaJugador(TemporadaJugadorViewModel jugadorInfo)
        {
            try
            {
                var jugador = await _temporadaJugadorRepository.FindIncludingAsync(tj=>tj.Id.Equals(jugadorInfo.IdTemporadaJugador),
                    tj=>tj.Club, tj=>tj.Puesto).ConfigureAwait(false);
                if (jugador == null)
                    return new Response { Message = "El jugador no existe", Result = false, Status = EResponseStatus.Error };

                // buscar el club
                var club = await _clubRepository.GetByNameAsync(jugadorInfo.Club).ConfigureAwait(false);
                if (club == null)
                    return new Response { Message = "El club " + jugadorInfo.Club + " no existe", Result = false, Status = EResponseStatus.Error };
                jugador.Club = club;

                // el puesto sólo se podrá modificar si la competición LIGA no está iniciada (estado INICIAL)
                // buscar el puesto
                var puesto = await _puestoRepository.GetByNameAsync(jugadorInfo.Puesto).ConfigureAwait(false);
                if (puesto == null)
                    return new Response { Message = "El puesto " + jugadorInfo.Puesto + " no existe", Result = false, Status = EResponseStatus.Error };
                if (jugador.Puesto!=puesto)
                {
                    var competicionLiga = await _temporadaCompeticionRepository.GetLiga(jugador.Temporada_ID).ConfigureAwait(false);
                    if (competicionLiga != null && competicionLiga.GetEstadoOperacion().Equals(LigamaniaConst.JI_EstadoInicial))
                        jugador.Puesto = puesto;
                    else
                        return new Response { Message = "No se puede modificar el puesto de un jugador una vez iniciada la LIGA", Result = false, Status = EResponseStatus.Warning };
                }

                await _temporadaJugadorRepository.UpdateAsyn(jugador, jugadorInfo.IdTemporadaJugador).ConfigureAwait(false);

                // Revisar la tabla de alineacion_previa y alineacion_cambio
                ICollection<AlineacionCambioDTO> alineacionesCambios = await _alineacionCambioRepository.FindAllAsync(ac => ac.Jugador_ID.Equals(jugador.Jugador_ID)).ConfigureAwait(false);
                foreach(var ali in alineacionesCambios)
                {
                    ali.Club = club;
                    //ali.Puesto = puesto;
                    await _alineacionCambioRepository.UpdateAsyn(ali, ali.Id).ConfigureAwait(false);
                }
                ICollection<AlineacionPreviaDTO> alineacionesPrevias = await _alineacionPreviaRepository.FindAllAsync(ac => ac.Jugador_ID.Equals(jugador.Jugador_ID)).ConfigureAwait(false);
                foreach (var ali in alineacionesPrevias)
                {
                    ali.Club = club;
                    //ali.Puesto = puesto;
                    await _alineacionPreviaRepository.UpdateAsyn(ali, ali.Id).ConfigureAwait(false);
                }

                await _temporadaJugadorRepository.SaveAsync().ConfigureAwait(false);
                await _alineacionCambioRepository.SaveAsync().ConfigureAwait(false);
                await _alineacionPreviaRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Jugador modificado", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error editando temporadajugador: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }

        public eCheckClubResponse CheckNuevoClub(ClubViewModel club)
        {
            var regClub = _clubRepository.GetByName(club.Club);
            if (regClub == null)
            {
                regClub = _clubRepository.GetByAlias(club.Alias);
                if (regClub == null) return eCheckClubResponse.NoExiste;
                else return eCheckClubResponse.ExisteAlias;
            }
            return eCheckClubResponse.ExisteNombre;
        }
        public async Task<Response> NuevoClub(ClubViewModel club)
        {
            try
            {
                ClubDTO nuevoClub = new ClubDTO
                {
                    Nombre = club.Club,
                    Alias = club.Alias,
                    Baja = false
                };
                var inserted = await _clubRepository.AddAsyn(nuevoClub).ConfigureAwait(false);
                await _clubRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Club añadido con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error dando un nuevo club: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<ResponseOfTReturn<List<string>>> LoadJugadoresFromExcel(string clubName, List<JugadorActivoExcelDto> jugadores)
        {
            List<string> lErrors = new List<string>();
            ResponseOfTReturn<List<string>> response = new ResponseOfTReturn<List<string>>();
            response.ResultDTO = lErrors;

            if (string.IsNullOrEmpty(clubName))
            {
                response.Result = false;
                response.Status = EResponseStatus.Error;
                lErrors.Add("ERROR_CLUB: El nombre del club no debe estar vacío: " + clubName + " - JUGADORES 'NO cargados'");
                return response;
            }

            var temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            if (temporada == null)
                temporada = await _temporadaRepository.GetPreTemporada().ConfigureAwait(false);
            if (temporada == null)
            {
                response.Result = false;
                response.Status = EResponseStatus.Error;
                lErrors.Add("ERROR_GENERICO - CLUB " + clubName + " - 'NO EXISTE TEMPORADA ACTUAL O PRETEMPORADA'");
                return response;
            }

            var club = await _clubRepository.GetByNameAsync(clubName).ConfigureAwait(false);
            if (club==null)
            {
                response.Result = false;
                response.Status = EResponseStatus.Error;
                lErrors.Add("ERROR_CLUB: El club no existe: " + clubName + " - JUGADORES 'NO cargados'");
                return response;
            }
            if (jugadores == null || !jugadores.Any())
            {
                response.Result = false;
                response.Status = EResponseStatus.Error;
                lErrors.Add("ERROR_JUGADOR - CLUB " + clubName + " - JUGADORES 'Lista nula o vacía'");
                return response;
            }

            foreach (var jugadorExcel in jugadores)
            {
                try
                {
                    var puesto = await _puestoRepository.GetByNameAsync(jugadorExcel.Puesto).ConfigureAwait(false);
                    if (puesto==null)
                    {
                        lErrors.Add("ERROR_JUGADOR - CLUB " + clubName + " - JUGADOR " + jugadorExcel.Jugador + "'El puesto " + jugadorExcel.Puesto + " no existe");
                        continue;
                    }
                    var jugador = await _jugadorRepository.GetByNameAsync(jugadorExcel.Jugador).ConfigureAwait(false);
                    if (jugador == null)
                    {
                        JugadorDTO nuevoJugador = new JugadorDTO { Baja = false, Nombre = jugadorExcel.Jugador };
                        jugador = await _jugadorRepository.AddAsyn(nuevoJugador).ConfigureAwait(false);
                    }
                    else
                    {
                        jugador.Baja = false;
                        jugador = await _jugadorRepository.UpdateAsyn(jugador, jugador.Id).ConfigureAwait(false);
                    }
                    var jugadorTemporada = await _temporadaJugadorRepository.FindIncludingAsync(tj => tj.Temporada.Id == temporada.Id && tj.Jugador.Id == jugador.Id && tj.Activo && tj.Club.Id!=club.Id, tj=>tj.Club).ConfigureAwait(false);
                    if (jugadorTemporada!=null)
                    {
                        lErrors.Add("ERROR_JUGADOR - CLUB " + clubName + " - JUGADOR " + jugadorExcel.Jugador + "'El jugador " + jugadorExcel.Jugador + " ya existe en el club "+jugadorTemporada.Club.Nombre);
                        continue;
                    }
                    var jugadorTemporada2 = await _temporadaJugadorRepository.FindIncludingAsync(tj => tj.Temporada.Id == temporada.Id && tj.Jugador.Id == jugador.Id && tj.Activo && (tj.Club.Id != club.Id || tj.Puesto.Id!=puesto.Id), 
                        tj => tj.Club, tj=>tj.Puesto).ConfigureAwait(false);
                    if (jugadorTemporada2 != null)
                    {
                        lErrors.Add("ERROR_JUGADOR - CLUB " + clubName + " - JUGADOR " + jugadorExcel.Jugador + "'El jugador " + jugadorExcel.Jugador + " ya existe en el club " + jugadorTemporada2.Club.Nombre+" bajo el puesto "+jugadorTemporada2.Puesto.Nombre);
                        continue;
                    }

                    var existTemporadaJugador = await _temporadaJugadorRepository.ExistsAsync(tj => tj.Club.Id == club.Id && tj.Jugador.Id == jugador.Id && tj.Puesto.Id == puesto.Id && tj.Temporada.Id == temporada.Id).ConfigureAwait(false);
                    if (!existTemporadaJugador)
                    {
                        TemporadaJugadorDTO temporadaJugadorDTO = new TemporadaJugadorDTO { Club = club, Puesto = puesto, Jugador = jugador, Temporada = temporada, Activo = true };
                        var temporadaJugador = await _temporadaJugadorRepository.AddAsyn(temporadaJugadorDTO).ConfigureAwait(false);
                    }
                    else
                    {
                        var temporadaJugador = await _temporadaJugadorRepository.FindAsync(tj=> tj.Club.Id == club.Id && tj.Jugador.Id == jugador.Id && tj.Puesto.Id == puesto.Id && tj.Temporada.Id == temporada.Id && !tj.Activo).ConfigureAwait(false);
                        if (temporadaJugador != null)
                        {
                            temporadaJugador.Activo = true;
                            await _temporadaJugadorRepository.UpdateAsyn(temporadaJugador, temporadaJugador.Id).ConfigureAwait(false);
                        }
                    }
                }
                catch (Exception x)
                {
                    lErrors.Add("ERROR_JUGADOR - CLUB " + clubName + " - JUGADORES 'Error tratando jugador: '"+x.Message);
                }
            }
            await _jugadorRepository.SaveAsync().ConfigureAwait(false);
            await _temporadaJugadorRepository.SaveAsync().ConfigureAwait(false);
            return response;
        }

        public async Task<Response> DesactivarAllJugadores()
        {
            try
            {
                var allJugadores = await _jugadorRepository.FindAllAsync(j=>!j.Baja).ConfigureAwait(false);
                var allTemporadaJugadores = await _temporadaJugadorRepository.FindAllAsync(j=>j.Activo).ConfigureAwait(false);
                foreach(var jugador in allJugadores)
                {
                    jugador.Baja = true;
                    await _jugadorRepository.UpdateAsyn(jugador, jugador.Id).ConfigureAwait(false);
                }
                foreach(var tempJug in allTemporadaJugadores)
                {
                    tempJug.Activo = false;
                    await _temporadaJugadorRepository.UpdateAsyn(tempJug, tempJug.Id).ConfigureAwait(false);
                }
                await _temporadaJugadorRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Todos los jugadores han sido desactivados", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error desactivando todos los jugadores: " + x, Status = EResponseStatus.Error, Result = false };

            }
        }
        public async Task<Response> BorrarAllJugadoresTemporadaActiva()
        {
            try
            {
                var temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    temporada = await _temporadaRepository.GetPreTemporada().ConfigureAwait(false);
                if (temporada == null)
                {
                    _logger.LogError("No existe temporada activa");
                    return new Response { Message = "No existe temporada activa", Status = EResponseStatus.Error, Result = false };
                }

                var allTemporadaJugadores = await _temporadaJugadorRepository.FindAllAsync(j => j.Temporada_ID.Equals(temporada.Id));
                var jugadores = allTemporadaJugadores.ToList();
                for (int i=0; i < jugadores.Count;i++)
                {
                    int v = await _temporadaJugadorRepository.DeleteAsyn(jugadores[i]);
                }
                await _temporadaJugadorRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Todos los jugadores han sido desactivados", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error desactivando todos los jugadores: " + x, Status = EResponseStatus.Error, Result = false };

            }
        }
    }
}
