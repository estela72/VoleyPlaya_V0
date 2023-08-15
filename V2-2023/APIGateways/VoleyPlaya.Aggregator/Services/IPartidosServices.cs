using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public interface IPartidosServices
{
    Task<Partido?> GetPartido(int partidoId);
}
