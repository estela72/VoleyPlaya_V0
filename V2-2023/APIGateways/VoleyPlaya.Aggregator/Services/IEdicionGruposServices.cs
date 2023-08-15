using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public interface IEdicionGruposServices
{
    Task<EdicionGrupo?> GetEdicionGrupo(int edicionGrupoId);
}
