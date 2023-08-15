using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public interface IJornadasServices
{
    Task<Jornada?> GetJornada(int jornadaId);
}
