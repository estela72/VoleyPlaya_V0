using System;
using System.Collections.Generic;

using VoleyPlaya.Management.Domain.Common;

namespace VoleyPlaya.Management.Domain;

public partial class EdicionGrupo:IAggregateRoot
{
    public int Id { get; set; }

    public int EdicionId { get; set; }

    public string Tipo { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Nombre { get; set; }

    public virtual Edicion Edicion { get; set; } = null!;

    public virtual ICollection<Partido> Partidos { get; set; } = new List<Partido>();

    //public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}
