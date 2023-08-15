using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public interface IEdicionesServices
{
    Task<Edicion?> GetEdicion(int edicionId);
}
