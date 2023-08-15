namespace VoleyPlaya.Aggregator.Model;

public class Jornada
{
    public string Nombre { get; set; } = string.Empty;
    public int Numero { get; set; }
    public DateTime Fecha { get; set; }

    public int EdicionId { get; set; }
    public Edicion? Edicion { get; set; }
}
