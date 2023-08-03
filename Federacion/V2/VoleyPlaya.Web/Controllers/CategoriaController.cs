using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using RestSharp;

using System.Net;

using VoleyPlaya.Web.Models;

using Xunit;

namespace VoleyPlaya.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private RestClient _restClient;
        private static readonly string RESOURCE_API = "Categorias";

        private IConfiguration _configuration;

        public CategoriaController(IConfiguration configuration)
        {
            this._configuration = configuration;
            if (_configuration == null) throw new WebException("No se ha podido cargar la configuración");
            _restClient = new RestClient(_configuration.GetValue<string>("WebSettings:APIEndPoint"));
        }

        // GET: CategoriaController
        public async Task<ActionResult> IndexAsync()
        {
            var request = new RestRequest(RESOURCE_API, Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var categorias = JsonConvert.DeserializeObject<IList<Categoria>>(response.Content);
            return View(categorias);
        }

        // GET: CategoriaController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var categoria = JsonConvert.DeserializeObject<Categoria>(response.Content);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        // GET: CategoriaController/Create
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Nombre")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var request = new RestRequest(RESOURCE_API, Method.Post);
                request.AddBody(categoria);
                var response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: CategoriaController/Edit/5
        public async Task<ActionResult> EditAsync(int? id)
        {
            if (id == null) return BadRequest();
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var categoria = JsonConvert.DeserializeObject<Categoria>(response.Content);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, [Bind("Id, Nombre")] Categoria categoria)
        {
            if (id != categoria.Id) return NotFound();
            if (ModelState.IsValid)
            {
                var request = new RestRequest(RESOURCE_API + "/{id}", Method.Put);
                request.AddParameter("id", id, ParameterType.UrlSegment);
                request.AddBody(categoria);
                var response = await _restClient.ExecuteAsync(request);
                if (!response.IsSuccessful)
                    return BadRequest();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: CategoriaController/Delete/5
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id == null) return BadRequest();
            var request = new RestRequest(RESOURCE_API + "/{id}", Method.Get);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful) return BadRequest();
            var categoria = JsonConvert.DeserializeObject<Categoria>(response.Content);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        // POST: CategoriaController/Delete/5
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
