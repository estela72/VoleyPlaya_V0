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
    public interface IJugadorService
    {
        Task<IEnumerable<Jugador>> GetAllJugadores();
        Task<Jugador> Create(Jugador JugadorToCreate);
        Task<Jugador> GetJugadorById(int id);
        Task<Jugador> UpdateJugador(int id, Jugador JugadorUpdated);
        Task<Jugador> DeleteById(int id);
    }
    public class JugadorService : IJugadorService
    {
        private readonly IMapper _mapper;
        private readonly ILigamaniaUnitOfWork _ligamaniaUnitOfWork;

        public JugadorService(ILigamaniaUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _ligamaniaUnitOfWork = unitOfWork;
        }

        public async Task<Jugador> Create(Jugador jugadorToCreate)
        {
            var jugador = _mapper.Map<JugadorDTO>(jugadorToCreate);
            var jugadorCreated = await _ligamaniaUnitOfWork.JugadorRepository.CreateAsync(jugador);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return _mapper.Map<Jugador>(jugadorCreated);
        }

        public async Task<Jugador> DeleteById(int id)
        {
            var jugador = await _ligamaniaUnitOfWork.JugadorRepository.DeleteAsync(id);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return new Jugador("Jugador borrado correctamente");
        }

        public async Task<IEnumerable<Jugador>> GetAllJugadores()
        {
            var jugadores = await _ligamaniaUnitOfWork.JugadorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Jugador>>(jugadores);
        }

        public async Task<Jugador> GetJugadorById(int id)
        {
            return _mapper.Map<Jugador>(await _ligamaniaUnitOfWork.JugadorRepository.GetByIdAsync(id));
        }

        public async Task<Jugador> UpdateJugador(int id, Jugador jugadorUpdated)
        {
            var jugadorToUpdate = _mapper.Map<JugadorDTO>(jugadorUpdated);
            var jugador = await _ligamaniaUnitOfWork.JugadorRepository.UpdateAsyn(jugadorToUpdate, id);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return _mapper.Map<Jugador>(jugador);
        }
    }
}
