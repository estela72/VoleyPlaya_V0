

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
        IVoleyPlayaService _serviceVP;
        IMapper _mapper;
        public ConfiguracionModel(IVoleyPlayaService service, IMapper mapper) : base()
        {
            _serviceVP = service;
            _mapper = mapper;
        }
        public async Task OnGetAsyn()
        {

        }
        public async Task OnPostLoadCalendariosAsync()
        {
            TablaCalendarioCircuito tablas = new TablaCalendarioCircuito(_serviceVP, _mapper);
            await tablas.LoadAsync();
        }
    }
}
