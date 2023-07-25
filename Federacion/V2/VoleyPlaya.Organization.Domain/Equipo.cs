using System;
using System.Collections.Generic;

using VoleyPlaya.Organization.Domain.Common;

namespace VoleyPlaya.Organization.Domain;

public partial class Equipo : IAggregateRoot
{
    public int Id { get; set; }

    public int? EdicionId { get; set; }

    public int? EdicionGrupoId { get; set; }

    public int? OrdenCalendario { get; set; }

    public int? Jugados { get; set; }

    public int? Ganados { get; set; }

    public int? Perdidos { get; set; }

    public int? PuntosFavor { get; set; }

    public int? PuntosContra { get; set; }

    public double? Coeficiente { get; set; }

    public int? Puntos { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Nombre { get; set; }

    public bool? Retirado { get; set; }

    public int? OrdenEntrada { get; set; }

    public int ClasificacionFinal { get; set; }

    //public virtual Edicione? Edicion { get; set; }

    //public virtual ICollection<Partido> PartidoEquipoLocals { get; set; } = new List<Partido>();

    //public virtual ICollection<Partido> PartidoEquipoVisitantes { get; set; } = new List<Partido>();

    //public virtual ICollection<EdicionGrupo> Grupos { get; set; } = new List<EdicionGrupo>();
}
