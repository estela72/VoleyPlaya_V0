using Newtonsoft.Json;
using RestSharp;

using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public class CategoriasService : ICategoriasService
{
    private RestClient _restClient;
    private IConfiguration _configuration;

    public CategoriasService(IConfiguration configuration)
    {
        this._configuration = configuration;
        _restClient = new RestClient(_configuration.GetValue<string>("AggregatorSettings:CategoriasEndPoint")
            ?? throw new ArgumentNullException("Mandatory parameter", "AggregatorSettings:CategoriasEndPoint"));
    }
    public async Task<Categoria?> GetCategoria(int id)
    {
        var request = new RestRequest("/{id}", Method.Get);
        request.AddParameter("id", id, ParameterType.UrlSegment);
        var response = await _restClient.ExecuteAsync(request);
        if (!response.IsSuccessful) return null;
        return JsonConvert.DeserializeObject<Categoria>(response.Content ?? "");
    }
}
