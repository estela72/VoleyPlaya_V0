using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using RestSharp;

using System.Net;

using VoleyPlaya.Web.Models;

using Xunit;

namespace VoleyPlaya.Web.Controllers
{
    public class TemporadaController : Controller
    {
        private RestClient _restClient;
        private static readonly string RESOURCE_API = "Temporadas";

        private IConfiguration _configuration;

        public TemporadaController(IConfiguration configuration)
        {
            this._configuration = configuration;
            if (_configuration == null) throw new WebException("No se ha podido cargar la configuración");
            _restClient = new RestClient(_configuration.GetValue<string>("WebSettings:APIEndPoint"));
        }

        // GET: TemporadaController
        public async Task<ActionResult> IndexAsync()
        {
            var request = new RestRequest(RESOURCE_API, Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var temporadas = JsonConvert.DeserializeObject<IList<Temporada>>(response.Content);
            return View(temporadas);
        }

        // GET: TemporadaController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var temporada = JsonConvert.DeserializeObject<Temporada>(response.Content);
            if (temporada == null) return NotFound();
            return View(temporada);
        }

        // GET: TemporadaController/Create
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        // POST: TemporadaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Nombre")] Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                var request = new RestRequest(RESOURCE_API, Method.Post);
                request.AddBody(temporada);
                var response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(temporada);
        }

        // GET: TemporadaController/Edit/5
        public async Task<ActionResult> EditAsync(int? id)
        {
            if (id == null) return BadRequest();
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var temporada = JsonConvert.DeserializeObject<Temporada>(response.Content);
            if (temporada == null) return NotFound();
            return View(temporada);
        }

        // POST: TemporadaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, [Bind("Id, Nombre")] Temporada temporada)
        {
            if (id != temporada.Id) return NotFound();
            if (ModelState.IsValid)
            {
                var request = new RestRequest(RESOURCE_API + "/{id}", Method.Put);
                request.AddParameter("id", id, ParameterType.UrlSegment);
                request.AddBody(temporada);
                var response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(temporada);
        }

        // GET: TemporadaController/Delete/5
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id == null) return BadRequest();
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var temporada = JsonConvert.DeserializeObject<Temporada>(response.Content);
            if (temporada == null) return NotFound();
            return View(temporada);
        }

        // POST: TemporadaController/Delete/5
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
