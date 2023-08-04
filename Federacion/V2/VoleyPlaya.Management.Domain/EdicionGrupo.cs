using GenericLib;

using System;
using System.Collections.Generic;
namespace VoleyPlaya.Management.Domain;

public partial class EdicionGrupo : BaseDomain, IAggregateRoot
{

    public int EdicionId { get; set; }
    private Edicion? _edicion;
    public Edicion Edicion
    {
        get { return _edicion ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Edicion)); }
        set { _edicion = value; }
    }
    public string Tipo { get; set; } = null!;

    public string? Nombre { get; set; }

    public ICollection<Partido> Partidos { get; set; } = new List<Partido>();

    //public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}
