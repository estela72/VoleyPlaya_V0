using VoleyPlaya.Management.Domain.Enums;

namespace VoleyPlaya.Aggregator.Model;

public class Edicion
{
    public int EdicionId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Prueba { get; set; } = string.Empty;
    public Generos Genero { get; set; } = Generos.None;
    public EstadosEdicion Estado { get; set; } = EstadosEdicion.Registrada;
    public ModelosCompeticion? ModeloCompeticion { get; set; }
    public int TemporadaId { get; set; }
    public string Temporada { get; set; } = string.Empty;
    public int CompeticionId { get; set; }
    public string Competicion { get; set; } = string.Empty;
    public int CategoriaId { get; set; }
    public string Categoria { get; set; } = string.Empty;
}
