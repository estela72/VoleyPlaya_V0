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
        Task<bool> DeleteEdicionAsync(string nombre);
        Task<bool> DeleteEdicionAsync(int id);
        Task<string> GetAllEdicionesAsync();
        Task<string> GetEdicionAsync(string name);
        string GetEdicion(string name);
        Task<string> GetEdicionAsync(int id);

    }
}
