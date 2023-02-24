using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class SettingsDTO : AuditableEntity
    {
        public bool ClasificacionRotuloCopa { get; set; }
        public bool? VerNoticias { get; set; }
        public bool? VerEquiposPretemporada { get; set; }
        public bool? VerCuadroCopa { get; set; }
        public string TemporadaPremios { get; set; }
        public int NumeroJornadasVolverEliminados { get; set; }
        public string NotificacionClasificaciones { get; set; }
    }
}
