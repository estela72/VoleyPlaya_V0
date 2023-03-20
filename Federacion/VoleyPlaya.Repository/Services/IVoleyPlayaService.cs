using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Services
{
    public interface IVoleyPlayaService
    {
        Task<bool> SaveEdicionAsync(string json);
        Task<bool> DeleteEdicionAsync(string json);
        Task<string> GetAllEdicionesAsync();
        Task<string> GetEdicionAsync(string json);
        string GetEdicion(string json);
    }
}
