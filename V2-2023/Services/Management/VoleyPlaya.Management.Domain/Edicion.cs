using Common.Domain;

using System;
using System.Collections.Generic;

using VoleyPlaya.Management.Domain.Enums;

namespace VoleyPlaya.Management.Domain;

public partial class Edicion : BaseDomain, IAggregateRoot
{
    public string Nombre { get; set; } = string.Empty;
    public string Prueba { get; set; } = string.Empty;
    public Generos Genero { get; set; } = Generos.None;
    public EstadosEdicion Estado { get; set; } = EstadosEdicion.Registrada;
    //public string? TipoCalendario { get; set; } // indica numero de vueltas y numero de equipos en la fase de grupos. Igual se puede mejorar
    public ModelosCompeticion? ModeloCompeticion { get; set; }
    public int TemporadaId { get; set; }
    public int CompeticionId { get; set; }
    public int CategoriaId { get; set; }
    public ICollection<EdicionGrupo> EdicionGrupos { get; set; } = new List<EdicionGrupo>();
    public ICollection<Jornada> Jornada { get; set; } = new List<Jornada>();
}
