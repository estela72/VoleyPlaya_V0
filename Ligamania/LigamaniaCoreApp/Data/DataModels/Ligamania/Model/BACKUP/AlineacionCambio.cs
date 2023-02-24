namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Interfaces;
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public partial class Alineacion_Cambio: AuditableEntity, IAuditableAlineacionEntity
    {
        public int Temporada_ID { get; set; }
        public int Competicion_ID { get; set; }
        public int Categoria_ID { get; set; }
        public int Equipo_ID { get; set; }
        public int Jugador_ID { get; set; }
        public int Club_ID { get; set; }
        public int Puesto_ID { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Club Club { get; set; }
        public virtual Competicion Competicion { get; set; }
        public virtual Jugador Jugador { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual TemporadaEquipo Equipo { get; set; }
        public virtual Temporada Temporada { get; set; }

        public int? JugadorCambio_ID { get; set; }
        public int? ClubCambio_ID { get; set; }

        public virtual Club ClubCambio { get; set; }
        public virtual Jugador JugadorCambio { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            StringBuilder strB = new StringBuilder();

            strB.AppendLine("Jugador " + Club.Nombre+"-"+Jugador.Nombre+"-"+Puesto.Nombre + " cambio por " + ClubCambio?.Nombre+"-"+ JugadorCambio?.Nombre);
            return strB.ToString();

        }
    }
}
