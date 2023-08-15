using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public interface ICategoriasService
{
    Task<Categoria?> GetCategoria(int id);
}
