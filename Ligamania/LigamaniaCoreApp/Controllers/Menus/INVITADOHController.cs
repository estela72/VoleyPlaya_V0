using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using LigamaniaCoreApp.Services;
using LigamaniaCoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LigamaniaCoreApp.Controllers
{
    [AllowAnonymous]
    public class INVITADOHController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IInvitadoService _invitadoService;
        private readonly ILigamaniaService _ligamaniaService;
        private readonly ILogger<INVITADOHController> _logger;
        public INVITADOHController(IHostingEnvironment hostingEnvironment
            , IInvitadoService invitadoService
            , ILigamaniaService ligamaniaService
            , ILogger<INVITADOHController> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _invitadoService = invitadoService;
            _ligamaniaService = ligamaniaService;
            _logger = logger;
        }
		public async Task<IActionResult> Historial()
        {
            ICollection<HistorialViewModel> historial = await _invitadoService.GetHistorial().ConfigureAwait(false);
            return View(historial);
        }
        [HttpGet]
        public async Task<PartialViewResult> ClasificacionesLiga(string temporada)
        {
            ICollection<Models.GlobalViewModels.ClasificacionViewModel> clasificaciones = await _ligamaniaService.GetClasificacionesTemporada(temporada).ConfigureAwait(false);
            if (clasificaciones != null && clasificaciones.FirstOrDefault()!=null && clasificaciones.First().Equipos.Any())
                // Only grid query values will be available here.
                return PartialView("_ClasificacionesTemporada", clasificaciones);
            else
                return PartialView("_ImageClasificacionesTemporada", temporada);
        }
        [HttpGet]
        public async Task<IActionResult> HistorialEquipo(string equipo)
        {
            HistorialEquipoViewModel historial = await _invitadoService.GetHistorialEquipo(equipo).ConfigureAwait(false);
            return View(historial);
        }

        public async Task<IActionResult> Vitrina()
        {
            ICollection<HistorialViewModel> historial = await _invitadoService.GetHistorial().ConfigureAwait(false);
            return View(historial);
        }
        public async Task<IActionResult> Clasificacion()
        {
            ClasificacionHistoricaViewModel clasificacion = await _invitadoService.GetClasificacionHistorica().ConfigureAwait(false);
            return View(clasificacion);
        }
        public ActionResult GetImgClasificacion(string temporada)
        {
            IQueryable<byte[]> q = _ligamaniaService.GetImgClasificacionTemporada(temporada);

            //var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", $"{img}");
            //var imageFileStream = System.IO.File.OpenRead(q);
            byte[] imageByteData = q.First();
            if (imageByteData != null)
            {
                string imageData = @"data:image/jpeg; base64," + Convert.ToBase64String(imageByteData);
                return File(imageData, "image/jpeg");
            }
            else
            {
                return File("~/images/cabecera_ligamania.jpg", "image/jpg");
            }


            //return File(imageData, "image/jpg");

            //if (q == null || !q.Any())
            //    return View("Historial");
            //byte[] cover = q.First();
            //if (cover != null)
            //{
            //    return File(cover, "image/jpg");
            //}
            //else
            //{
            //    return File("~/images/cabecera_ligamania.jpg", "image/jpg");
            //}
        }
        public IActionResult GetImagenCategoria(string categoria, int puesto)
        {
            var img = _invitadoService.GetImageCategoriaHistorial(categoria, puesto);
            if (!string.IsNullOrEmpty(img))
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", $"{img}");
                var imageFileStream = System.IO.File.OpenRead(path);
                return File(imageFileStream, "image/jpeg");
            }
            else
            {
                return File("~/images/cabecera_ligamania.jpg", "image/jpg");
            }
        }
    }
}