using AutoMapper;

using Ligamania.Web.Helpers;
using Ligamania.Web.Models;
using Ligamania.Web.Services;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class DocumentosController : BaseController<DocumentosController>
    {
        private readonly IPreparacionService _preparacionService;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _hostingEnvironment;

        public DocumentosController(ILogger<DocumentosController> logger, IPreparacionService service, IMapper mapper, IWebHostEnvironment hostingEnvironment) : base(logger)
        {
            _preparacionService = service;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            DocumentoListVM model = new DocumentoListVM();
            return View(model);
        }
        public async Task<IActionResult> getListaDocumentos()
        {
            IEnumerable<DocumentoVM> documentos = await _preparacionService.GetAllDocumentos();
            return Json(documentos);
        }
        public async Task<FileResult> ShowFile(int id)
        {
            var documento = await _preparacionService.GetDocumentoById(id);
            if (documento!=null)
            {
                var fileContent = documento.Contenido;
                var fileContentBytes = fileContent;
                return File(fileContentBytes, System.Net.Mime.MediaTypeNames.Application.Pdf);
            }
            return File("El documento seleccionado no se puede mostrar", System.Net.Mime.MediaTypeNames.Application.Json);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string nombre, string descripcion, string tipo)
        {
            DocumentoVM documento = new DocumentoVM { Documento = nombre, Descripcion = descripcion, Tipo = tipo };
            try
            {
                if (ModelState.IsValid)
                {
                    IFormFile file = Request.Form.Files[0];
                    string folderName = "Upload";
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    DocumentParser.Parse(documento, file, folderName, webRootPath);

                    var documentoCreated = await _preparacionService.CreateDocumento(documento);
                    if (!documentoCreated.Error)
                    {
                        var model = new DocumentoListVM();
                        string msg = "Documento creado correctamente.";
                        var documentos = await _preparacionService.GetAllDocumentos();
                        model.documentos = documentos.ToList();
                        model.Set(false, msg);
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new DocumentoListVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Index", model);
                    }
                }
                else
                {
                    var model = new DocumentoListVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Index", model);
                }
            }
            catch (Exception x)
            {
                var model = new DocumentoListVM();
                model.Set(true, x.Message);
                return View("Index", model);
            }
        }
        // GET: UsersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            DocumentoVM model = new DocumentoVM();
            try
            {
                var documento = await _preparacionService.GetCalendarioById(id);
                model = _mapper.Map<DocumentoVM>(documento);
            }
            catch (Exception x)
            {
                model.Set(true, x.Message);
            }
            return View(model);
        }
        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DocumentoVM updatedDocumento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var documento = _mapper.Map<DocumentoVM>(updatedDocumento);
                    var documentoUpdated = await _preparacionService.UpdateDocumento(id, documento);
                    if (!documentoUpdated.Error)
                    {
                        var model = new DocumentoListVM();
                        var documentos = await _preparacionService.GetAllDocumentos();
                        model.documentos = documentos.ToList();
                        model.Set(false, "Documento actualizado correctamente");
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new DocumentoListVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Edit", model);
                    }
                }
                else
                {
                    var model = new DocumentoListVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Edit", model);
                }
            }
            catch (Exception x)
            {
                var model = new DocumentoListVM();
                model.Set(true, x.Message);
                return View("Edit", model);
            }
        }
        // GET: Club/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            DocumentoVM model = new DocumentoVM();
            try
            {
                var documento = await _preparacionService.GetDocumentoById(id);
                model = _mapper.Map<DocumentoVM>(documento);
            }
            catch (Exception x)
            {
                model.Set(true, x.Message);
            }
            return View(model);
        }
        // POST: Club/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _preparacionService.DeleteDocumentoById(id);
                    if (result.Error)
                        return View(result);
                    else
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception x)
            {
                DocumentoVM model = new DocumentoVM();
                model.Set(true, x.Message);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
