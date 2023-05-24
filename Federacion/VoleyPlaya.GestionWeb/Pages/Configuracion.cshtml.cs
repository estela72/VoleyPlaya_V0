

using AutoMapper;

using Microsoft.AspNetCore.Authorization;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;
using VoleyPlaya.Repository.Services;

namespace VoleyPlaya.GestionWeb.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class ConfiguracionModel : VPPageModel
    {
        IConfiguracionService _serviceConfig;
        IMapper _mapper;
        public ConfiguracionModel(IConfiguracionService service, IMapper mapper) : base()
        {
            _serviceConfig = service;
            _mapper = mapper;
        }
        public async Task OnGetAsyn()
        {

        }
        public async Task OnPostLoadCalendariosAsync()
        {
            await _serviceConfig.LoadTablasCalendarios();
            //TablaCalendarioCircuito tablas = new TablaCalendarioCircuito(_serviceVP, _mapper);
            //await tablas.LoadAsync();
        }
        public async Task OnPostArreglarGruposEquiposAsync()
        {
            await _serviceConfig.ArreglarGruposEquipos();
        }
    }
}
