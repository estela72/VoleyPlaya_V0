using AutoMapper;

using System.Xml;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Repository.Services;

namespace VoleyPlaya.Domain.Services
{
    public interface IConfiguracionService
    {
        Task ArreglarGruposEquipos();
        Task<int> GetNumJornadas(int numEquipos);
        Task<List<PartidoCalendarioCircuito>> GetTablaCalendario(int numEquipos);
        Task LoadTablasCalendarios();
    }
    public class ConfiguracionService : IConfiguracionService
    {
        private readonly IVoleyPlayaService _vpService;
        private readonly IMapper _mapper;
        TablaCalendarioCircuito TablasCalendarios;

        public ConfiguracionService(IVoleyPlayaService service, IMapper mapper)
        {
            _vpService = service;
            _mapper = mapper;
            TablasCalendarios = new TablaCalendarioCircuito(_vpService, _mapper);
        }

        public async Task ArreglarGruposEquipos()
        {
            await _vpService.ArreglarGruposEquipos();
        }

        public async Task<int> GetNumJornadas(int numEquipos)
        {
            var partidos = await GetTablaCalendario(numEquipos);
            return partidos.Max(p => p.Jornada);
        }

        public async Task<List<PartidoCalendarioCircuito>> GetTablaCalendario(int numEquipos)
        {
            var partidos = await _vpService.GetCalendarioPartidosCircuito(numEquipos);
            return _mapper.Map<List<PartidoCalendarioCircuito>>(partidos);
        }

        public async Task LoadTablasCalendarios()
        {
            await TablasCalendarios.LoadAsync();
        }
         
    }
}
