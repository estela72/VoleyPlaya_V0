using AutoMapper;

using Ligamania.API.Lib.Models;
using Ligamania.API.Lib.Services;
using Ligamania.Web.Models.Club;
using Ligamania.Web.Models.Competicion;
using Ligamania.Web.Models.Jugador;
using Ligamania.Web.Models.Temporada;

namespace Ligamania.Web.Services
{
    public interface IGestionTemporadaService
    {
        Task<IEnumerable<TemporadaVM>> GetAllTemporadas();
        Task<byte[]> GetClasificacionById(int id);
        Task<TemporadaVM> GetTemporadaById(int id);
        Task<TemporadaVM> UpdateTemporada(int id, TemporadaVM temp);
        Task<TemporadaVM> DeleteTemporadaById(int id);
        Task<TemporadaVM> CreateTemporada(TemporadaVM temporada);
        Task<IEnumerable<CompeticionVM>> GetCompeticiones(int idTemporada);
        Task<IEnumerable<CategoriaVM>> GetCategorias(int idTemporada, int idCompeticion);
        Task<IEnumerable<ClubVM>> GetAllClubs();
        Task<string> UpdateClubsTemporada(List<ClubVM> clubs);
        Task<IEnumerable<JugadorVM>> GetAllJugadores();
        Task<string> UpdateJugadoresTemporada(List<JugadorVM> jugadores);
        Task<string> CopiarJugadoresTemporada(string temporada);
        Task<string> CrearJugadorTemporada(JugadorVM jugador);
    }
    public class GestionTemporadaService : IGestionTemporadaService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly ITemporadaService _temporadaService;

        public GestionTemporadaService(
            ILocalStorageService localStorageService
            , IMapper mapper
            , ITemporadaService temporadaService)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _temporadaService = temporadaService;
        }

        public async Task<string> CopiarJugadoresTemporada(string temporada)
        {
            return await _temporadaService.CopiarJugadoresTemporada(temporada);
        }

        public async Task<string> CrearJugadorTemporada(JugadorVM jugador)
        {
            var jug = _mapper.Map<Jugador>(jugador);
            return await _temporadaService.CrearJugadorTemporada(jug);
        }

        public async Task<TemporadaVM> CreateTemporada(TemporadaVM temporada)
        {
            var temp = _mapper.Map<Temporada>(temporada);
            var tempCreated = await _temporadaService.CreateTemporada(temp);
            return _mapper.Map<TemporadaVM>(tempCreated);
        }

        public async Task<TemporadaVM> DeleteTemporadaById(int id)
        {
            var temporada = await _temporadaService.DeleteTemporadaById(id);
            return _mapper.Map<TemporadaVM>(temporada);
        }

        public async Task<IEnumerable<ClubVM>> GetAllClubs()
        {
            var list = await _temporadaService.GetAllClubs();
            return _mapper.Map<IEnumerable<ClubVM>>(list);
        }

        public async Task<IEnumerable<JugadorVM>> GetAllJugadores()
        {
            var list = await _temporadaService.GetAllJugadores();
            return _mapper.Map<IEnumerable<JugadorVM>>(list);
        }

        public async Task<IEnumerable<TemporadaVM>> GetAllTemporadas()
        {
            var list = await _temporadaService.GetAllTemporadas();
            return _mapper.Map<IEnumerable<TemporadaVM>>(list);
        }

        public async Task<IEnumerable<CategoriaVM>> GetCategorias(int idTemporada, int idCompeticion)
        {
            var list = await _temporadaService.GetCategorias(idTemporada, idCompeticion);
            return _mapper.Map<IEnumerable<CategoriaVM>>(list);
        }

        public async Task<byte[]> GetClasificacionById(int id)
        {
            byte[] imageData = await _temporadaService.GetClasificacionById(id);
            return imageData;
        }

        public async Task<IEnumerable<CompeticionVM>> GetCompeticiones(int idTemporada)
        {
            var list = await _temporadaService.GetCompeticiones(idTemporada);
            return _mapper.Map<IEnumerable<CompeticionVM>>(list);
        }

        public async Task<TemporadaVM> GetTemporadaById(int id)
        {
            var temp = await _temporadaService.GetTemporadaById(id);
            return _mapper.Map<TemporadaVM>(temp);
        }

        public async Task<string> UpdateClubsTemporada(List<ClubVM> clubs)
        {
            var listClubs = _mapper.Map<List<Club>>(clubs);
            var response = await _temporadaService.UpdateClubs(listClubs);
            return response;
        }

        public async Task<string> UpdateJugadoresTemporada(List<JugadorVM> jugadores)
        {
            var listJugadores = _mapper.Map<List<Jugador>>(jugadores);
            var response = await _temporadaService.UpdateJugadores(listJugadores);
            return response;
        }

        public async Task<TemporadaVM> UpdateTemporada(int id, TemporadaVM temp)
        {
            var temporada = _mapper.Map<Temporada>(temp);
            var tempUpdated = await _temporadaService.UpdateTemporada(id, temporada);
            return _mapper.Map<TemporadaVM>(tempUpdated);
        }
    }
}
