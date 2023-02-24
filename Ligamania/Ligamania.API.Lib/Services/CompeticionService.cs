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
    public interface ICompeticionService
    {
        Task<IEnumerable<Competicion>> GetAllCompeticiones();
        Task<IEnumerable<Categoria>> GetCategorias(int idCompeticion);
        Task<Competicion> GetCompeticionById(int id);
        Task<Competicion> DeleteCompeticionById(int id);
        Task<Competicion> UpdateCompeticion(int id, Competicion competicionUpdated);
        Task<Competicion> Create(Competicion competicionCreated);
        Task<Competicion> UpdateCategoriaToCompeticion(int newCategoria, int competicionId);
        Task<Competicion> DeleteCategoriaFromCompeticion(int competicionId, int categoriaId);
    }
    public class CompeticionService : ICompeticionService
    {
        private readonly IMapper _mapper;
        private readonly ILigamaniaUnitOfWork _ligamaniaUnitOfWork;

        public CompeticionService(ILigamaniaUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _ligamaniaUnitOfWork = unitOfWork;
        }

        public async Task<Competicion> Create(Competicion competicionCreated)
        {
            var competicion = _mapper.Map<CompeticionDTO>(competicionCreated);
            competicion.Orden = await _ligamaniaUnitOfWork.CompeticionRepository.Count();
            var comp = await _ligamaniaUnitOfWork.CompeticionRepository.CreateAsync(competicion);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return _mapper.Map<Competicion>(comp);
        }

        public async Task<Competicion> DeleteCategoriaFromCompeticion(int competicionId, int categoriaId)
        {
            await _ligamaniaUnitOfWork.CompeticionCategoriaRepository.DeleteCategoriaFromCompeticion(competicionId,categoriaId);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return await GetCompeticionById(competicionId);
        }

        public async Task<Competicion> DeleteCompeticionById(int id)
        {
            var competicion = await _ligamaniaUnitOfWork.CompeticionRepository.DeleteAsync(id);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return new Competicion("Competición borrada correctamente");
        }

        public async Task<IEnumerable<Competicion>> GetAllCompeticiones()
        {
            var competiciones = await _ligamaniaUnitOfWork.CompeticionRepository.GetAllAsync();
            return _mapper.Map<List<Competicion>>(competiciones);
        }

        public async Task<IEnumerable<Categoria>> GetCategorias(int idCompeticion)
        {
            IEnumerable<CategoriaDTO> categorias;
            if (idCompeticion != -1)
            {
                categorias = await _ligamaniaUnitOfWork.CompeticionCategoriaRepository.GetCategorias(idCompeticion);
            }
            else { categorias = await _ligamaniaUnitOfWork.CategoriaRepository.GetAllAsync(); }
            return _mapper.Map<List<Categoria>>(categorias);
        }

        public async Task<Competicion> GetCompeticionById(int id)
        {
            var competicion = await _ligamaniaUnitOfWork.CompeticionRepository.GetByIdAsync(id);
            return _mapper.Map<Competicion>(competicion);
        }

        public async Task<Competicion> UpdateCategoriaToCompeticion(int newCategoria, int competicionId)
        {
            await _ligamaniaUnitOfWork.CompeticionCategoriaRepository.UpdateCategoriaToCompeticion(competicionId, newCategoria);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return await GetCompeticionById(competicionId);
        }

        public async Task<Competicion> UpdateCompeticion(int id, Competicion competicionUpdated)
        {
            var competicion = _mapper.Map<CompeticionDTO>(competicionUpdated);
            var comp = await _ligamaniaUnitOfWork.CompeticionRepository.UpdateAsyn(competicion,id);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return _mapper.Map<Competicion>(comp);
        }
    }
}
