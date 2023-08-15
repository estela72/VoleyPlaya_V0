using Common.Domain;

using System;
using System.Collections.Generic;


namespace VoleyPlaya.Management.Domain;

public partial class Partido : BaseDomain, IAggregateRoot
{
    public string Label { get; set; } = string.Empty;
    public int NumPartido { get; set; }
    public string Ronda { get; set; } = null!;
    public DateTime? FechaHora { get; set; }
    public string? Pista { get; set; }
    public int? ResultadoLocal { get; set; }
    public int? ResultadoVisitante { get; set; }
    public string? NombreLocal { get; set; }
    public string? NombreVisitante { get; set; }
    public bool? ConResultado { get; set; }
    public string UserResultado { get; set; } = null!;
    public bool? Validado { get; set; }
    public string UserValidador { get; set; } = null!;

    public int EdicionGrupoId { get; set; }
    private EdicionGrupo? _edicionGrupo;
    public EdicionGrupo EdicionGrupo
    {
        get { return _edicionGrupo ?? throw new InvalidOperationException("Uninitialized property: " + nameof(EdicionGrupo)); }
        set { _edicionGrupo = value; }
    }
    public int? JornadaId { get; set; }
    private Jornada? _jornada;
    public Jornada Jornada
    {
        get { return _jornada ?? throw new InvalidOperationException("Unitialized property: " + nameof(Jornada)); }
        set { _jornada = value; }
    }
    public int? EquipoLocalId { get; set; }
    public int? EquipoVisitanteId { get; set; }
    public ICollection<Parcial> Parciales { get; set; } = new List<Parcial>();
}
