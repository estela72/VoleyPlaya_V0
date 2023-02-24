using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class DocumentsRepository : Repository<DocumentsDTO>, IDocumentsRepository
    {
        public DocumentsRepository(LigamaniaDbContext context)
            : base(context)
        {
        }
    }
}