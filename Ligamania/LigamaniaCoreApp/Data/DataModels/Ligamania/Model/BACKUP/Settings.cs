using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    [Table("Settings")]
    public class Settings : AuditableEntity
    {
        public bool Clasificacion_RotuloCopa { get; set; }
        public bool Ver_Noticias { get; set; }
        public bool Ver_EquiposPretemporada { get; set; }
        public bool Ver_CuadroCopa { get; set; }
        public string TemporadaPremios { get; set; }
    }
}
