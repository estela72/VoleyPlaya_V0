using General.CrossCutting.Lib;

namespace Ligamania.Repository.Models
{
    public interface IAuditableAlineacionEntity : IEntity
    {
        int Temporada_ID { get; set; }
        int Competicion_ID { get; set; }
        int Categoria_ID { get; set; }
        int Equipo_ID { get; set; }
        int Jugador_ID { get; set; }
        int Club_ID { get; set; }
        int Puesto_ID { get; set; }
        CategoriaDTO Categoria { get; set; }
        ClubDTO Club { get; set; }
        CompeticionDTO Competicion { get; set; }
        JugadorDTO Jugador { get; set; }
        PuestoDTO Puesto { get; set; }
        TemporadaEquipoDTO Equipo { get; set; }
        TemporadaDTO Temporada { get; set; }
    }
}