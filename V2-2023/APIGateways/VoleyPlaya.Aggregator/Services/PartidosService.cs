using Newtonsoft.Json;

using RestSharp;

using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public class PartidosService : IPartidosServices
{
    private RestClient _restClient;
    private IConfiguration _configuration;

    public PartidosService(IConfiguration configuration)
    {
        this._configuration = configuration;
        _restClient = new RestClient(_configuration.GetValue<string>
            ("AggregatorSettings:PartidosEndPoint") ??
            throw new ArgumentNullException("Mandatory parameter", "AggregatorSettings:PartidosEndPoint"));
    }
    public async Task<Partido?> GetPartido(int partidoId)
    {
        var request = new RestRequest("/{id}", Method.Get);
        request.AddParameter("id", partidoId, ParameterType.UrlSegment);
        var response = await _restClient.ExecuteAsync(request);
        if (!response.IsSuccessful) return null;
        return JsonConvert.DeserializeObject<Partido>(response.Content ?? "");
    }
}
