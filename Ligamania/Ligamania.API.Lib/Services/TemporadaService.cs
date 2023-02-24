using AutoMapper;

using Ligamania.API.Lib.Models;
using Ligamania.Repository;
using Ligamania.Repository.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Services
{
    public interface ITemporadaService
    {
        Task<IEnumerable<Temporada>> GetAllTemporadas();
        Task<byte[]> GetClasificacionById(int id);
        Task<Temporada> GetTemporadaById(int id);
        Task<Temporada> DeleteTemporadaById(int id);
        Task<Temporada> UpdateTemporada(int id, Temporada temporada);
        Task<Temporada> CreateTemporada(Temporada temp);
        Task<IEnumerable<Competicion>> GetCompeticiones(int idTemporada);
        Task<IEnumerable<Categoria>> GetCategorias(int idTemporada, int idCompeticion);
        Task<IEnumerable<Club>> GetAllClubs();
        Task<string> UpdateClubs(List<Club> listClubs);
        Task<IEnumerable<Jugador>> GetAllJugadores();
        Task<string> UpdateJugadores(List<Jugador> listJugadores);
    }
    internal class TemporadaService : ITemporadaService
    {
        private readonly IMapper _mapper;
        private readonly ILigamaniaUnitOfWork _ligamaniaUnitOfWork;

        public TemporadaService(ILigamaniaUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _ligamaniaUnitOfWork = unitOfWork;
        }

        public async Task<Temporada> CreateTemporada(Temporada temp)
        {
            var t = _mapper.Map<TemporadaDTO>(temp);
            var temporada = await _ligamaniaUnitOfWork.TemporadaRepository.CreateAsync(t);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return _mapper.Map<Temporada>(temporada);
        }

        public async Task<Temporada> DeleteTemporadaById(int id)
        {
            var deleted = await _ligamaniaUnitOfWork.TemporadaRepository.DeleteAsync(id);
            if (!deleted)
                return new Temporada("Se producido un error al borrar la temporada");
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return new Temporada("Temporada eliminada");
        }

        public async Task<IEnumerable<Temporada>> GetAllTemporadas()
        {
            var temporadas = await _ligamaniaUnitOfWork.TemporadaRepository.GetAllAsync();
            return _mapper.Map<List<Temporada>>(temporadas);
        }

        public async Task<byte[]> GetClasificacionById(int id)
        {
            var image = await _ligamaniaUnitOfWork.TemporadaRepository.GetImg_Clasificacion(id);
            return image;
        }

        public async Task<IEnumerable<Competicion>> GetCompeticiones(int idTemporada)
        {
            var competiciones = await _ligamaniaUnitOfWork.TemporadaRepository.GetCompeticionesByTemporada(idTemporada);
            competiciones = _formatCompeticiones(competiciones);
            return _mapper.Map<List<Competicion>>(competiciones);
        }

        private ICollection<TemporadaCompeticionDTO> _formatCompeticiones(ICollection<TemporadaCompeticionDTO> competiciones)
        {
            competiciones.ToList().ForEach(c =>
                 c.DescripcionEstado = c.GetEstadoOperacion()
                );
            return competiciones;
        }

        public async Task<Temporada> GetTemporadaById(int id)
        {
            var temp = await _ligamaniaUnitOfWork.TemporadaRepository.GetByIdAsync(id);
            return _mapper.Map<Temporada>(temp);
        }

        public async Task<Temporada> UpdateTemporada(int id, Temporada temporada)
        {
            var temp = _mapper.Map<TemporadaDTO>(temporada);
            var t = await _ligamaniaUnitOfWork.TemporadaRepository.UpdateAsync(temp);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return _mapper.Map<Temporada>(t);
        }

        public async Task<IEnumerable<Categoria>> GetCategorias(int idTemporada, int idCompeticion)
        {
            var categorias = await _ligamaniaUnitOfWork.TemporadaRepository.GetCategoriasByTemporadaAndCompeticion(idTemporada, idCompeticion);
            //categorias = _formatCategorias(categorias);
            return _mapper.Map<List<Categoria>>(categorias);
        }

        public async Task<IEnumerable<Club>> GetAllClubs()
        {
            var allClubs = await _ligamaniaUnitOfWork.ClubRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Club>>(allClubs);
        }

        private async Task<TemporadaDTO> GetTemporadaEnCurso()
        {
            var ta = await _ligamaniaUnitOfWork.TemporadaRepository.GetActualAsync();
            if (ta == null)
                ta = await _ligamaniaUnitOfWork.TemporadaRepository.GetPreTemporada();
            return ta;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listClubs"></param> Lista de clubs a dar de baja en la temporada
        /// <returns></returns>
        public async Task<string> UpdateClubs(List<Club> listClubs)
        {
            var response = string.Empty;
            var allClubs = await GetAllClubs();
            foreach (var club in allClubs)
                if (listClubs.Select(c => c.Alias).Contains(club.Alias))
                    await _ligamaniaUnitOfWork.ClubRepository.Baja(club.Alias);
                else
                    await _ligamaniaUnitOfWork.ClubRepository.Alta(club.Alias);

            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            response = "Clubs dados de baja correctamente";
            return response;
        }

        public async Task<IEnumerable<Jugador>> GetAllJugadores()
        {
            var temporada = await GetTemporadaEnCurso();
            if (temporada == null)
                return new List<Jugador>();
            var jugadores = await _ligamaniaUnitOfWork.TemporadaRepository.GetJugadoresByTemporada(temporada.Id);
            var jugRepo = await _ligamaniaUnitOfWork.JugadorRepository.GetAllAsync();
            var list1 = _mapper.Map<List<Jugador>>(jugadores);
            var list2 = _mapper.Map<List<Jugador>>(jugRepo);

            var list = list2;
            foreach(var jugA in list1)
            {
                var v = list.Find(j => j.Nombre.Equals(jugA.Nombre));
                list.Remove(v);
                list.Add(jugA);
            }

            return list;
        }

        public async Task<string> UpdateJugadores(List<Jugador> listJugadores)
        {
            var response = string.Empty;
            var temporada = await GetTemporadaEnCurso();
            if (temporada == null)
                return "No hay temporada en curso";

            if (listJugadores.Count == 0)
                return "No hay jugadores para dar de alta";


            var clubDto = await _ligamaniaUnitOfWork.ClubRepository.GetByAliasAsync(listJugadores.First().Club);
            var puestoDto = await _ligamaniaUnitOfWork.PuestoRepository.GetByNameAsync(listJugadores.First().Puesto);
            foreach (var jug in listJugadores)
            {
                var jugadorDto = await _ligamaniaUnitOfWork.JugadorRepository.GetByNameAsync(jug.Nombre);
                var jugExiste = await ExisteJugadorTemporada(jugadorDto, temporada);
                if (jugExiste != null)
                    await _ligamaniaUnitOfWork.TemporadaJugadorRepository.Baja(jugExiste);

                if (jug.Activo)
                {
                    await _ligamaniaUnitOfWork.TemporadaJugadorRepository.Alta(jugadorDto, clubDto, puestoDto, temporada);
                    await _ligamaniaUnitOfWork.JugadorRepository.Alta(jugadorDto);
                }
                else
                {
                    await _ligamaniaUnitOfWork.JugadorRepository.Baja(jugadorDto);
                }
            }

            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            response = "Jugadores dados de alta correctamente";
            return response;
        }

        private async Task<TemporadaJugadorDTO> ExisteJugadorTemporada(JugadorDTO jugadorDto, TemporadaDTO temporada)
        {
            var existe = await _ligamaniaUnitOfWork.TemporadaJugadorRepository.ExistsAsync(tj => tj.Temporada_ID.Equals(temporada.Id) && tj.Jugador_ID.Equals(jugadorDto.Id));
            if (existe)
                return await _ligamaniaUnitOfWork.TemporadaJugadorRepository.FindAsync(tj => tj.Temporada_ID.Equals(temporada.Id) && tj.Jugador_ID.Equals(jugadorDto.Id));
            return null;
        }
    }
}
