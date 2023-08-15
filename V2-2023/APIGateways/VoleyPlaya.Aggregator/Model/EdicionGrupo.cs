using VoleyPlaya.Management.Domain.Enums;

namespace VoleyPlaya.Aggregator.Model;

public class EdicionGrupo
{
    public string Nombre { get; set; } = string.Empty;
    public FaseEdicionGrupo Fase { get; set; } = FaseEdicionGrupo.None;

    public int EdicionId { get; set; }
    public Edicion? Edicion { get; set;}
}
