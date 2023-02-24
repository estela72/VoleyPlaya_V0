using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using LigamaniaCoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LigamaniaCoreApp.Controllers.Menus
{
    [AllowAnonymous]
    public class InvitadoRController : BaseController
    {
        ILogger _logger;
        IInvitadoService _invitadoService;

        public InvitadoRController(ILogger<InvitadoRController> logger
            , IInvitadoService invitadoService)
        {
            _logger = logger;
            _invitadoService = invitadoService;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<ReglamentoViewModel> reglamentos = await _invitadoService.GetAllReglamentos().ConfigureAwait(false);
            return View(reglamentos);
        }
        public async Task<FileContentResult> DownloadFile(int? fileId)
        {
            if (fileId == null) return null;

            ReglamentoViewModel reglamento = await _invitadoService.FindReglamento(fileId.Value).ConfigureAwait(false);
            var file = File(reglamento.Content, reglamento.ContentType, reglamento.Name);
            var mimeType = reglamento.ContentType;

            return new FileContentResult(reglamento.Content, mimeType);
        }
    }
}