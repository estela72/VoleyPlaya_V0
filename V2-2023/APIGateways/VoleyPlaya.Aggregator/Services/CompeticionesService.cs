using Newtonsoft.Json;
using RestSharp;

using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public class CompeticionesService : ICompeticionesService
{
    private RestClient _restClient;
    private IConfiguration _configuration;

    public CompeticionesService(IConfiguration configuration)
    {
        this._configuration = configuration;
        _restClient = new RestClient(_configuration.GetValue<string>("AggregatorSettings:CompeticionesEndPoint")
            ?? throw new ArgumentNullException("Mandatory parameter", "AggregatorSettings:CompeticionesEndPoint"));
    }
    public async Task<Competicion?> GetCompeticion(int id)
    {
        var request = new RestRequest("/{id}", Method.Get);
        request.AddParameter("id", id, ParameterType.UrlSegment);
        var response = await _restClient.ExecuteAsync(request);
        if (!response.IsSuccessful) return null;
        return JsonConvert.DeserializeObject<Competicion>(response.Content ?? "");
    }
}
