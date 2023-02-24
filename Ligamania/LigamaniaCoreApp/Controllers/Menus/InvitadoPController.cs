using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LigamaniaCoreApp.Controllers.Menus
{
    [AllowAnonymous]
    public class InvitadoPController : BaseController
    {
        ILogger<InvitadoPController> _logger;
        IInvitadoService _invitadoService;
        IManagerService _managerService;

        public InvitadoPController(
            ILogger<InvitadoPController> logger
            , IInvitadoService invitadoService
            , IManagerService managerService)
        {
            _logger = logger;
            _invitadoService = invitadoService;
            _managerService = managerService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //TemporadaDTO temporada = await _managerService.GetTemporadaFinalizada().ConfigureAwait(false);
            //ICollection<TemporadaEquipoDTO> equipos = await _managerService.GetEquiposEnTemporada(temporada.Id).ConfigureAwait(false);

            //PremiosViewModel model = await _invitadoService.GetPremiosTemporada(temporada, equipos).ConfigureAwait(false);
            //return View(model);
            return await PremiosTemporada(null);
        }
        public async Task<IActionResult> PremiosTemporada(string temporada)
        {
            PremiosViewModel premiosTemporada = await _invitadoService.GetPremiosTemporada(temporada).ConfigureAwait(false);
            premiosTemporada.Editable = false;
            if (User.IsInRole(LigamaniaEnum.ERol.Manager.ToString()))
                premiosTemporada.Editable = true;

            return  RedirectToAction("PremiosTemporada", "ManagerC");
        }

    }
}