using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.GlobalViewModels
{
    public class SettingsViewModel
    {
        public bool VerRotuloCopa { get; set; }
        public bool VerNoticias { get; set; }
        public bool VerEquiposPretemporada { get; set; }
        public bool VerCuadroCopa { get; set; }
        public string TemporadaPremios { get; set; }
        [Display(Name="Nº de jornadas para que vuelva un jugador eliminado")]
        public int NumeroJornadasVolverEliminados { get; set; }
        [Display(Name = "Notificación a visualizar encima de las clasificaciones")]
        public string NotificacionClasificaciones { get; set; }

    }
}
//public class SettingsDocument_Info
//{
//    public int Id { get; set; }
//    public string Nombre { get; set; }
//    public string Descripcion { get; set; }
//    public byte[] Content { get; set; }
//}
