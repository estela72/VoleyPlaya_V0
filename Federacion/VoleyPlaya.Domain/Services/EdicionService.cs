using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Repository.Services;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VoleyPlaya.Domain.Services
{
    public interface IEdicionService
    {
        Task<string> GetAllAsync();
        IEnumerable<Edicion> EdicionesFromJson(string jsonEdiciones);
        Edicion FromJson(string jsonEdicion);
        Task<string> GetEdicionByName(string id);
        Task UpdateEdicionAsync(Edicion edicion);
        Task<string> GetEdicionById(int id);
        Task DeleteEdicion(string nombre);
        Task DeleteEdicion(int id);
        Task UpdatePartidosAsync(Edicion edicion);
    }
    public class EdicionService : IEdicionService
    {
        IVoleyPlayaService _service;
        public EdicionService(IVoleyPlayaService service) 
        {
            _service = service;
        }

        public async Task<string> GetAllAsync()
        {
            return await _service.GetAllEdicionesAsync();
        }

        public IEnumerable<VoleyPlaya.Domain.Models.Edicion> EdicionesFromJson(string jsonEdiciones)
        {
            List<VoleyPlaya.Domain.Models.Edicion> list = new List<VoleyPlaya.Domain.Models.Edicion>();
            JsonNode node = JsonNode.Parse(jsonEdiciones)!;
            JsonArray ediciones = node!.AsArray();
            foreach (var edicion in ediciones)
                list.Add(VoleyPlaya.Domain.Models.Edicion.FromJson(edicion));
            return list;
        }
        public Edicion FromJson(string jsonEdicion)
        {
            Edicion edicion = new Edicion();
            JsonNode node = JsonNode.Parse(jsonEdicion)!;
            edicion = Edicion.FromJson(node);
            return edicion;
        }

        public async Task<string> GetEdicionByName(string id)
        {
            return await _service.GetEdicionAsync(id);
        }

        public async Task UpdateEdicionAsync(Edicion edicion)
        {
            await edicion.GenerarPartidosAsync();
            string jsonString = JsonSerializer.Serialize(edicion);
            await _service.SaveEdicionAsync(jsonString);
        }

        public async Task<string> GetEdicionById(int id)
        {
            return await _service.GetEdicionAsync(id);
        }

        public async Task DeleteEdicion(string nombre)
        {
            await _service.DeleteEdicionAsync(nombre);
        }

        public async Task DeleteEdicion(int id)
        {
            await _service.DeleteEdicionAsync(id);
        }

        public async Task UpdatePartidosAsync(Edicion edicion)
        {
            string jsonString = JsonSerializer.Serialize(edicion);
            await _service.UpdatePartidosAsync(jsonString);
        }
    }
}
