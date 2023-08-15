using Newtonsoft.Json;

using RestSharp;

using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public class TemporadasService : ITemporadasService
{
    private RestClient _restClient;
    private IConfiguration _configuration;

    public TemporadasService(IConfiguration configuration)
    {
        this._configuration = configuration;
        _restClient = new RestClient(_configuration.GetValue<string>("AggregatorSettings:TemporadasEndPoint") 
            ?? throw new ArgumentNullException("Mandatory parameter", "AggregatorSettings:TemporadasEndPoint"));
    }
    public async Task<Temporada?> GetTemporada(int temporadaId)
    {
        var request = new RestRequest("/{id}", Method.Get);
        request.AddParameter("id", temporadaId, ParameterType.UrlSegment);
        var response = await _restClient.ExecuteAsync(request);
        if (!response.IsSuccessful) return null;
        return JsonConvert.DeserializeObject<Temporada>(response.Content ?? "");
    }
}
