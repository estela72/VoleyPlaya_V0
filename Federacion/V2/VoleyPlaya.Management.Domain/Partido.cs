using Common.Domain;

using System;
using System.Collections.Generic;


namespace VoleyPlaya.Management.Domain;

public partial class Partido : BaseDomain, IAggregateRoot
{
    public int EdicionGrupoId { get; set; }
    private EdicionGrupo? _edicionGrupo;
    public EdicionGrupo EdicionGrupo
    {
        get { return _edicionGrupo ?? throw new InvalidOperationException("Uninitialized property: " + nameof(EdicionGrupo)); }
        set { _edicionGrupo = value; }
    }

    public int? EquipoLocalId { get; set; }

    public int? EquipoVisitanteId { get; set; }

    public int? ResultadoLocal { get; set; }

    public int? ResultadoVisitante { get; set; }

    public int? Jornada { get; set; }

    public int? NumPartido { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Pista { get; set; }

    public string? Label { get; set; }

    public bool? Validado { get; set; }

    public string? NombreLocal { get; set; }

    public string? NombreVisitante { get; set; }

    public string Ronda { get; set; } = null!;

    public bool? ConResultado { get; set; }

    public string UserResultado { get; set; } = null!;

    public string UserValidador { get; set; } = null!;

    public ICollection<Parcial> Parciales { get; set; } = new List<Parcial>();
}
