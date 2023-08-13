using General.CrossCutting.Lib;

namespace Ligamania.Repository.Interfaces
{
    public interface IAlineacionRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        int GetLastId();
    }
}