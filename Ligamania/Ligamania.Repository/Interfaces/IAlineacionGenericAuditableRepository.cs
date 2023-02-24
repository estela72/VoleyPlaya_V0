using General.CrossCutting.Lib;

namespace Ligamania.Repository.Interfaces
{
    public interface IAlineacionRepository<T> : IRepository<T> where T : Entity
    {
        int GetLastId();
    }
}