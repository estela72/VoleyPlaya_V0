using Newtonsoft.Json;

using RestSharp;

using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public class JornadasService : IJornadasServices
{
    private RestClient _restClient;
    private IConfiguration _configuration;

    public JornadasService(IConfiguration configuration)
    {
        this._configuration = configuration;
        _restClient = new RestClient(_configuration.GetValue<string>
            ("AggregatorSettings:JornadasEndPoint") ??
            throw new ArgumentNullException("Mandatory parameter", "AggregatorSettings:JornadasEndPoint"));
    }
    public async Task<Jornada?> GetJornada(int jornadaId)
    {
        var request = new RestRequest("/{id}", Method.Get);
        request.AddParameter("id", jornadaId, ParameterType.UrlSegment);
        var response = await _restClient.ExecuteAsync(request);
        if (!response.IsSuccessful) return null;
        return JsonConvert.DeserializeObject<Jornada>(response.Content ?? "");
    }
}
