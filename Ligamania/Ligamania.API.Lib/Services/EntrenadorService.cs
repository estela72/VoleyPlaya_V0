using AutoMapper;

using Ligamania.API.Lib.Models;
using Ligamania.Repository;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Services
{
    public interface IEntrenadorService 
    {
        Task<IEnumerable<Entrenador>> GetAllEntrenadores();
    }
    public class EntrenadorService : IEntrenadorService
    {
        private readonly IMapper _mapper;
        private readonly ILigamaniaUnitOfWork _ligamaniaUnitOfWork;

        public EntrenadorService(ILigamaniaUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _ligamaniaUnitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Entrenador>> GetAllEntrenadores()
        {
            var entrenadores = await _ligamaniaUnitOfWork.UserManager.GetUsersInRoleAsync("Entrenador");
            var listEntrenadores = _mapper.Map<List<Entrenador>>(entrenadores);
            foreach (var entrenador in listEntrenadores)
            {
                var equipos = await _ligamaniaUnitOfWork.EquipoRepository.FindAllAsync(e => e.ApplicationUser.Id.Equals(entrenador.Id));
                entrenador.SetNumEquipos(equipos != null ? equipos.Count : 0);
            }
            return listEntrenadores;
        }
    }
}