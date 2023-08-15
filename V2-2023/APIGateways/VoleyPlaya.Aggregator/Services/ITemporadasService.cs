using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public interface ITemporadasService
{
    Task<Temporada?> GetTemporada(int temporadaId);
}
