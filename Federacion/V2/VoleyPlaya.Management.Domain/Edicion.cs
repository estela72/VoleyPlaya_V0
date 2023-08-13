using Common.Domain;

using System;
using System.Collections.Generic;


namespace VoleyPlaya.Management.Domain;

public partial class Edicion : BaseDomain, IAggregateRoot
{

    public int TemporadaId { get; set; }

    public int CompeticionId { get; set; }

    public int CategoriaId { get; set; }

    public string Genero { get; set; } = null!;

    public string? TipoCalendario { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string? ModeloCompeticion { get; set; }

    public string Prueba { get; set; } = null!;

    public int Estado { get; set; }

    public ICollection<EdicionGrupo> EdicionGrupos { get; set; } = new List<EdicionGrupo>();

    public ICollection<Jornada> Jornada { get; set; } = new List<Jornada>();
}
