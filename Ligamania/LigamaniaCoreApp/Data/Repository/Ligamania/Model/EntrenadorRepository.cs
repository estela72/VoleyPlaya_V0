using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{

    public class EntrenadorRepository : GenericAuditableNameRepository<Entrenador_DTO>, IEntrenadorRepository
    {
        public EntrenadorRepository(DbContext context)
            : base(context)
        {

        }
    }
}
