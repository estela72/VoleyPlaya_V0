namespace VoleyPlaya.Aggregator.Model
{
    public class Partido
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
        public EdicionGrupo? EdicionGrupo { get; set; }
        public int JornadaId { get; set; }
        public Jornada? Jornada { get; set; }
        public int? EquipoLocalId { get; set; }
        public int? EquipoVisitanteId { get; set; }
    }
}
