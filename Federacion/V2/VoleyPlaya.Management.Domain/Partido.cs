using System;
using System.Collections.Generic;

using VoleyPlaya.Management.Domain.Common;

namespace VoleyPlaya.Management.Domain;

public partial class Partido:IAggregateRoot
{
    public int Id { get; set; }

    public int? GrupoId { get; set; }

    public int? EquipoLocalId { get; set; }

    public int? EquipoVisitanteId { get; set; }

    public int? ResultadoLocal { get; set; }

    public int? ResultadoVisitante { get; set; }

    public int? Jornada { get; set; }

    public int? NumPartido { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Pista { get; set; }

    public string? Label { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Nombre { get; set; }

    public bool? Validado { get; set; }

    public string? NombreLocal { get; set; }

    public string? NombreVisitante { get; set; }

    public string Ronda { get; set; } = null!;

    public bool? ConResultado { get; set; }

    public string UserResultado { get; set; } = null!;

    public string UserValidador { get; set; } = null!;

    //public virtual Equipo? EquipoLocal { get; set; }

    //public virtual Equipo? EquipoVisitante { get; set; }

    public virtual EdicionGrupo? Grupo { get; set; }

    public virtual ICollection<Parcial> Parciales { get; set; } = new List<Parcial>();
}
