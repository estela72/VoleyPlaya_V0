using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    [Table("Documents")]
    public class Documents : AuditableNameEntity
    {
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Fichero")]
        public byte[] Content { get; set; }
    }
}
