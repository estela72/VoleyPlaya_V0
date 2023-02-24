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
    public interface ICalendarioService
    {
        Task<IEnumerable<Calendario>> GetAllCalendarios();
        Task<Calendario> Create(Calendario calendarioToCreate);
        Task<Calendario> GetCalendarioById(int id);
        Task<Calendario> UpdateCalendario(int id, Calendario calendarioUpdated);
        Task<Calendario> DeleteById(int id);
        Task<Calendario> UpdatePartidoCalendario(int calendarioId, int id, int jornada, string local, string visitante);
        Task<Calendario> DeletePartidoCalendario(int calendarioId, int id);
    }
    public class CalendarioService : ICalendarioService
    {
        private readonly IMapper _mapper;
        private readonly ILigamaniaUnitOfWork _ligamaniaUnitOfWork;

        public CalendarioService(ILigamaniaUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _ligamaniaUnitOfWork = unitOfWork;
        }

        public async Task<Calendario> Create(Calendario calendarioToCreate)
        {
            var calendario = _ligamaniaUnitOfWork.CalendarioRepository.FindBy(c=>c.Nombre.Equals(calendarioToCreate.Nombre));
            if (calendario.Any()) // ya existe un calendario con este nombre
                return new Calendario("Ya existe un calendario con este nombre");

            CalendarioDTO newCalendario = new CalendarioDTO { Nombre = calendarioToCreate.Nombre, NumEquipos = calendarioToCreate.NumEquipos };
            calendarioToCreate.Partidos.ForEach(cd =>
                newCalendario.CalendarioDetalle.Add(new CalendarioDetalleDTO { Jornada = cd.Jornada, Local = cd.Local, Visitante = cd.Visitante })
                );
            var calendarioCreated = await _ligamaniaUnitOfWork.CalendarioRepository.CreateAsync(newCalendario);
            var saved = await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            if (saved) return _mapper.Map<Calendario>(calendarioCreated);
            return new Calendario("Se ha producido un error al crear el calendario");
        }

        public async Task<Calendario> DeleteById(int id)
        {
            var calendario = await _ligamaniaUnitOfWork.CalendarioRepository.FindAllQueryableIncludingAsync(c => c.Id.Equals(id), c => c.CalendarioDetalle);
            calendario.FirstOrDefault().CalendarioDetalle.Clear();
            //foreach (var partido in calendario.First().CalendarioDetalle.ToList())
            //    var deletedPartido = await _ligamaniaUnitOfWork.CalendarioDetalleRepository.DeleteAsync(partido.Id);
            var deleted = await _ligamaniaUnitOfWork.CalendarioRepository.DeleteAsync(id);
            var saved = await _ligamaniaUnitOfWork.SaveEntitiesAsync();

            if (saved) return new Calendario("Calendario eliminado correctamente");
            return new Calendario("Se ha producido un error al eliminar el calendario");
        }

        public async Task<Calendario> DeletePartidoCalendario(int calendarioId, int id)
        {
            var calendario = await _ligamaniaUnitOfWork.CalendarioRepository.FindAllQueryableIncludingAsync(c => c.Id.Equals(calendarioId), c => c.CalendarioDetalle);
            var partido = calendario.First().CalendarioDetalle.SingleOrDefault(p => p.Id.Equals(id));
            if (partido != null)
            {
                var deleted = await _ligamaniaUnitOfWork.CalendarioDetalleRepository.DeleteAsync(id);
                if (deleted) await _ligamaniaUnitOfWork.SaveEntitiesAsync();
                return _mapper.Map<Calendario>(calendario);
            }
            return new Calendario("Se ha producido un error al eliminar un partido del calendario");
        }
        public async Task<IEnumerable<Calendario>> GetAllCalendarios()
        {
            var list = await _ligamaniaUnitOfWork.CalendarioRepository.GetAllIncludingAsync(c=>c.CalendarioDetalle);
            return _mapper.Map<IEnumerable<Calendario>>(list);
        }

        public async Task<Calendario> GetCalendarioById(int id)
        {
            var calendario = await _ligamaniaUnitOfWork.CalendarioRepository.GetByIdAsync(id);
            return _mapper.Map<Calendario>(calendario);
        }

        public async Task<Calendario> UpdateCalendario(int id, Calendario calendarioToUpdate)
        {
            var calendario = await _ligamaniaUnitOfWork.CalendarioRepository.GetByIdAsync(id);
            calendario.Nombre = calendarioToUpdate.Nombre;
            calendario.NumEquipos = calendarioToUpdate.NumEquipos;
            var calendarioUpdated = await _ligamaniaUnitOfWork.CalendarioRepository.UpdateAsync(calendario);
            var saved = await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            if (saved) return _mapper.Map<Calendario>(calendarioUpdated);
            return new Calendario("Se ha producido un error al actualizar el calendario");
        }

        public async Task<Calendario> UpdatePartidoCalendario(int calendarioId, int id, int jornada, string local, string visitante)
        {
            var calendario = await _ligamaniaUnitOfWork.CalendarioRepository.FindAllQueryableIncludingAsync(c=>c.Id.Equals(calendarioId), c=>c.CalendarioDetalle);
            var partido = calendario.First().CalendarioDetalle.SingleOrDefault(p => p.Id.Equals(id));
            if (partido != null)
            {
                partido.Jornada = jornada;
                partido.Local = local;
                partido.Visitante = visitante;
                var updated = await _ligamaniaUnitOfWork.CalendarioDetalleRepository.UpdateAsync(partido);
                var saved = await _ligamaniaUnitOfWork.SaveEntitiesAsync();
                if (saved)
                {
                    var calendarioUpdated = await _ligamaniaUnitOfWork.CalendarioRepository.GetByIdAsync(calendarioId);
                    return _mapper.Map<Calendario>(calendarioUpdated);
                }
            }
            return new Calendario("Se ha producido un error al actualizar el partido del calendario");

        }
    }
}
