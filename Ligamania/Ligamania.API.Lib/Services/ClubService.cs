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
    public interface IClubService
    {
        Task<IEnumerable<Club>> GetAllClubs();
        Task<Club> Create(Club clubToCreate);
        Task<Club> GetClubById(int id);
        Task<Club> UpdateClub(int id, Club clubUpdated);
        Task<Club> DeleteById(int id);
    }
    public class ClubService : IClubService
    {
        private readonly IMapper _mapper;
        private readonly ILigamaniaUnitOfWork _ligamaniaUnitOfWork;

        public ClubService(ILigamaniaUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _ligamaniaUnitOfWork = unitOfWork;
        }

        public async Task<Club> Create(Club clubToCreate)
        {
            var club = _mapper.Map<ClubDTO>(clubToCreate);
            var clubCreated = await _ligamaniaUnitOfWork.ClubRepository.CreateAsync(club);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return _mapper.Map<Club>(clubCreated);
        }

        public async Task<Club> DeleteById(int id)
        {
            var club = await _ligamaniaUnitOfWork.ClubRepository.DeleteAsync(id);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return new Club("Club borrado correctamente");
        }

        public async Task<IEnumerable<Club>> GetAllClubs()
        {
            var clubs = await _ligamaniaUnitOfWork.ClubRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Club>>(clubs);
        }

        public async Task<Club> GetClubById(int id)
        {
            return _mapper.Map<Club>(await _ligamaniaUnitOfWork.ClubRepository.GetByIdAsync(id));
        }

        public async Task<Club> UpdateClub(int id, Club clubUpdated)
        {
            var clubToUpdate = _mapper.Map<ClubDTO>(clubUpdated);
            var club = await _ligamaniaUnitOfWork.ClubRepository.UpdateAsyn(clubToUpdate, id);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return _mapper.Map<Club>(club);
        }
    }
}
