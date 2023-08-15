using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using RestSharp;

using System.Net;

using VoleyPlaya.Web.Models;

using Xunit;

namespace VoleyPlaya.Web.Controllers
{
    public class CompeticionController : Controller
    {
        private RestClient _restClient;
        private static readonly string RESOURCE_API = "Competiciones";

        private IConfiguration _configuration;

        public CompeticionController(IConfiguration configuration)
        {
            this._configuration = configuration;
            if (_configuration == null) throw new WebException("No se ha podido cargar la configuración");
            _restClient = new RestClient(_configuration.GetValue<string>("WebSettings:APIEndPoint"));
        }

        // GET: CompeticionController
        public async Task<ActionResult> IndexAsync()
        {
            var request = new RestRequest(RESOURCE_API, Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var competicions = JsonConvert.DeserializeObject<IList<Competicion>>(response.Content);
            return View(competicions);
        }

        // GET: CompeticionController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var competicion = JsonConvert.DeserializeObject<Competicion>(response.Content);
            if (competicion == null) return NotFound();
            return View(competicion);
        }

        // GET: CompeticionController/Create
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        // POST: CompeticionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Nombre")] Competicion competicion)
        {
            if (ModelState.IsValid)
            {
                var request = new RestRequest(RESOURCE_API, Method.Post);
                request.AddBody(competicion);
                var response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(competicion);
        }

        // GET: CompeticionController/Edit/5
        public async Task<ActionResult> EditAsync(int? id)
        {
            if (id == null) return BadRequest();
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var competicion = JsonConvert.DeserializeObject<Competicion>(response.Content);
            if (competicion == null) return NotFound();
            return View(competicion);
        }

        // POST: CompeticionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, [Bind("Id, Nombre")] Competicion competicion)
        {
            if (id != competicion.Id) return NotFound();
            if (ModelState.IsValid)
            {
                var request = new RestRequest(RESOURCE_API + "/{id}", Method.Put);
                request.AddParameter("id", id, ParameterType.UrlSegment);
                request.AddBody(competicion);
                var response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(competicion);
        }

        // GET: CompeticionController/Delete/5
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id == null) return BadRequest();
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var competicion = JsonConvert.DeserializeObject<Competicion>(response.Content);
            if (competicion == null) return NotFound();
            return View(competicion);
        }

        // POST: CompeticionController/Delete/5
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
