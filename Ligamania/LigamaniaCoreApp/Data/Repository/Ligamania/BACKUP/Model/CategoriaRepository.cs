using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class CategoriaRepository : GenericAuditableNameRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(DbContext context)
            : base(context)
        {

        }
    }
}
