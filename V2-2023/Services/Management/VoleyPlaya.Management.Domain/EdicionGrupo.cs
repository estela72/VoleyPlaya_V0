using Common.Domain;

using System;
using System.Collections.Generic;

using VoleyPlaya.Management.Domain.Enums;

namespace VoleyPlaya.Management.Domain;

public partial class EdicionGrupo : BaseDomain, IAggregateRoot
{
    public string Nombre { get; set; } = string.Empty;
    public FaseEdicionGrupo Fase { get; set; } = FaseEdicionGrupo.None;

    public int EdicionId { get; set; }
    private Edicion? _edicion;
    public Edicion Edicion
    {
        get { return _edicion ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Edicion)); }
        set { _edicion = value; }
    }
    public ICollection<Partido> Partidos { get; set; } = new List<Partido>();

    //public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}
