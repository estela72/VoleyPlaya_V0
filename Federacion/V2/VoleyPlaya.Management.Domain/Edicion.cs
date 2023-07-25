using System;
using System.Collections.Generic;

using VoleyPlaya.Management.Domain.Common;

namespace VoleyPlaya.Management.Domain;

public partial class Edicion:IAggregateRoot
{
    public int Id { get; set; }

    public int TemporadaId { get; set; }

    public int CompeticionId { get; set; }

    public int CategoriaId { get; set; }

    public string Genero { get; set; } = null!;

    public string? TipoCalendario { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public string? Nombre { get; set; }

    public string? ModeloCompeticion { get; set; }

    public string Prueba { get; set; } = null!;

    public int Estado { get; set; }

    //public virtual Categoria Categoria { get; set; } = null!;

    //public virtual Competicione Competicion { get; set; } = null!;

    public virtual ICollection<EdicionGrupo> EdicionGrupos { get; set; } = new List<EdicionGrupo>();

    //public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

    public virtual ICollection<Jornada> Jornada { get; set; } = new List<Jornada>();

    //public virtual Temporada Temporada { get; set; } = null!;
}
