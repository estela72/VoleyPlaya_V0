using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public interface ICompeticionesService
{
    Task<Competicion?> GetCompeticion(int id);
}
