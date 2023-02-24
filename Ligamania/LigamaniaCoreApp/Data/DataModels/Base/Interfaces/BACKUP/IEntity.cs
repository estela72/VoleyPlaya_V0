using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Interfaces
{
    public interface IEntity : IBaseEntity
    {
        int Id { get; set; }
    }
}
