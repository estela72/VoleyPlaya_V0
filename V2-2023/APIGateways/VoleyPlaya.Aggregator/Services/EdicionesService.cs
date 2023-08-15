using Newtonsoft.Json;

using RestSharp;

using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public class EdicionesService : IEdicionesServices
{
    private RestClient _restClient;
    private IConfiguration _configuration;

    public EdicionesService(IConfiguration configuration)
    {
        this._configuration = configuration;
        _restClient = new RestClient(_configuration.GetValue<string>
            ("AggregatorSettings:EdicionesEndPoint") ??
            throw new ArgumentNullException("Mandatory parameter", "AggregatorSettings:EdicionesEndPoint"));
    }
    public async Task<Edicion?> GetEdicion(int edicionId)
    {
        var request = new RestRequest("/{id}", Method.Get);
        request.AddParameter("id", edicionId, ParameterType.UrlSegment);
        var response = await _restClient.ExecuteAsync(request);
        if (!response.IsSuccessful) return null;
        return JsonConvert.DeserializeObject<Edicion>(response.Content ?? "");
    }
}
