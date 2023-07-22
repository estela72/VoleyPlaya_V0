using AutoMapper;

using Ligamania.API.Lib.Models;
using Ligamania.Repository;
using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Services
{
    public interface IEquipoService
    {
        Task<List<Equipo>> GetAllEquipos();
        Task<Equipo> AddNewEquipo(byte[] imagen, string nombre, bool esBot, string entrenadorId);
        Task<Equipo> AccionEquipo(int equipoId, string accion);
    }

    public class EquipoService : IEquipoService
    {
        private readonly ILigamaniaUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EquipoService(ILigamaniaUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Equipo> AccionEquipo(int equipoId, string accion)
        {
            var equipo = await _unitOfWork.EquipoRepository.GetByIdAsync(equipoId);
            switch (accion)
            {
                case "bot":
                    equipo.EsBot = true;
                    break;
                case "regular":
                    equipo.EsBot = false;
                    break;
                case "baja":
                    equipo.Baja = true;
                    break;
                case "alta":
                    equipo.Baja = false;
                    break;
                case "borrar":
                    _ = await _unitOfWork.EquipoRepository.DeleteAsync(equipoId);
                    //return new Equipo { Message = "Equipo eliminado correctamente", Error = true };
                    break;
            }
            EquipoDTO equipoUpdated = equipo;
            if (!accion.Equals("borrar"))
                equipoUpdated = await _unitOfWork.EquipoRepository.UpdateAsync(equipo);
            var sync = await _unitOfWork.SaveEntitiesAsync();
            if (sync>0)
                return _mapper.Map<Equipo>(equipoUpdated);
            return new Equipo { Message = "Se ha producido un error al guardar los cambios", Error = true };
        }

        public async Task<Equipo> AddNewEquipo(byte[] imagen, string nombre, bool esBot, string entrenadorId)
        {
            var user = await _unitOfWork.UserManager.FindByIdAsync(entrenadorId);
            var equipo = await _unitOfWork.EquipoRepository.AddNewEquipo(imagen, nombre, esBot, user);
            var saved = await _unitOfWork.SaveEntitiesAsync();
            if (saved > 0)
                return _mapper.Map<Equipo>(equipo);
            return new Equipo { Message = "Se ha producido un error al guardar los cambios", Error = true };
        }

        public async Task<List<Equipo>> GetAllEquipos()
        {
            var equipos = await _unitOfWork.EquipoRepository.GetAllIncludingAsync(e => e.ApplicationUser);
            return _mapper.Map<List<Equipo>>(equipos);
        }
    }
}