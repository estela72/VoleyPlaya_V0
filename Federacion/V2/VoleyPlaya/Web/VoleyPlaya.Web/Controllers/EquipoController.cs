using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using RestSharp;

using System.Net;

using VoleyPlaya.Web.Models;

using Xunit;

namespace VoleyPlaya.Web.Controllers
{
    public class EquipoController : Controller
    {
        private RestClient _restClient;
        private static readonly string RESOURCE_API = "Equipos";

        private IConfiguration _configuration;

        public EquipoController(IConfiguration configuration)
        {
            this._configuration = configuration;
            if (_configuration == null) throw new WebException("No se ha podido cargar la configuración");
            _restClient = new RestClient(_configuration.GetValue<string>("WebSettings:APIEndPoint"));
        }

        // GET: EquipoController
        public async Task<ActionResult> IndexAsync()
        {
            var request = new RestRequest(RESOURCE_API, Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var equipos = JsonConvert.DeserializeObject<IList<Equipo>>(response.Content);
            return View(equipos);
        }

        // GET: EquipoController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var equipo = JsonConvert.DeserializeObject<Equipo>(response.Content);
            if (equipo == null) return NotFound();
            return View(equipo);
        }

        // GET: EquipoController/Create
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        // POST: EquipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Nombre")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                var request = new RestRequest(RESOURCE_API, Method.Post);
                request.AddBody(equipo);
                var response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // GET: EquipoController/Edit/5
        public async Task<ActionResult> EditAsync(int? id)
        {
            if (id == null) return BadRequest();
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var equipo = JsonConvert.DeserializeObject<Equipo>(response.Content);
            if (equipo == null) return NotFound();
            return View(equipo);
        }

        // POST: EquipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, [Bind("Id, Nombre")] Equipo equipo)
        {
            if (id != equipo.Id) return NotFound();
            if (ModelState.IsValid)
            {
                var request = new RestRequest(RESOURCE_API + "/{id}", Method.Put);
                request.AddParameter("id", id, ParameterType.UrlSegment);
                request.AddBody(equipo);
                var response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // GET: EquipoController/Delete/5
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id == null) return BadRequest();
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var equipo = JsonConvert.DeserializeObject<Equipo>(response.Content);
            if (equipo == null) return NotFound();
            return View(equipo);
        }

        // POST: EquipoController/Delete/5
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
