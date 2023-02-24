using LigamaniaCoreApp.Data.DataModels.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Model
{
    public abstract class NameEntity : Entity, INameEntity
    {
        [StringLength(200)]
        public virtual string Nombre { get; set; }
    }
}
