using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using RestSharp;

using System.Net;

using VoleyPlaya.Web.Models;

using Xunit;

namespace VoleyPlaya.Web.Controllers
{
    public class TablaController : Controller
    {
        private RestClient _restClient;
        private static readonly string RESOURCE_API = "Tablas";

        private IConfiguration _configuration;

        public TablaController(IConfiguration configuration)
        {
            this._configuration = configuration;
            if (_configuration == null) throw new WebException("No se ha podido cargar la configuración");
            _restClient = new RestClient(_configuration.GetValue<string>("WebSettings:APIEndPoint"));
        }

        // GET: TablaController
        public async Task<ActionResult> IndexAsync()
        {
            var request = new RestRequest(RESOURCE_API, Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var tablas = JsonConvert.DeserializeObject<IList<Tabla>>(response.Content);
            return View(tablas);
        }

        // GET: TablaController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var tabla = JsonConvert.DeserializeObject<Tabla>(response.Content);
            if (tabla == null) return NotFound();
            return View(tabla);
        }

        // GET: TablaController/Create
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        // POST: TablaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Nombre,Ronda,Equipo1,Equipo2")] Tabla tabla)
        {
            if (ModelState.IsValid)
            {
                var request = new RestRequest(RESOURCE_API, Method.Post);
                request.AddBody(tabla);
                var response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(tabla);
        }

        // GET: TablaController/Edit/5
        public async Task<ActionResult> EditAsync(int? id)
        {
            if (id == null) return BadRequest();
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var tabla = JsonConvert.DeserializeObject<Tabla>(response.Content);
            if (tabla == null) return NotFound();
            return View(tabla);
        }

        // POST: TablaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, [Bind("Id, Nombre,Ronda,Equipo1,Equipo2")] Tabla tabla)
        {
            if (id != tabla.Id) return NotFound();
            if (ModelState.IsValid)
            {
                var request = new RestRequest(RESOURCE_API + "/{id}", Method.Put);
                request.AddParameter("id", id, ParameterType.UrlSegment);
                request.AddBody(tabla);
                var response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(tabla);
        }

        // GET: TablaController/Delete/5
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id == null) return BadRequest();
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var tabla = JsonConvert.DeserializeObject<Tabla>(response.Content);
            if (tabla == null) return NotFound();
            return View(tabla);
        }

        // POST: TablaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync(int? id)
        {
            if (id == null) return BadRequest();
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Delete);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            return RedirectToAction(nameof(Index));
        }
    }
}
