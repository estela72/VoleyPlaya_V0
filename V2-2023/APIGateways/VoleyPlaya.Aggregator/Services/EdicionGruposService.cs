using Newtonsoft.Json;

using RestSharp;

using VoleyPlaya.Aggregator.Model;

namespace VoleyPlaya.Aggregator.Services;

public class EdicionGruposService : IEdicionGruposServices
{
    private RestClient _restClient;
    private IConfiguration _configuration;

    public EdicionGruposService(IConfiguration configuration)
    {
        this._configuration = configuration;
        _restClient = new RestClient(_configuration.GetValue<string>
            ("AggregatorSettings:EdicionGruposEndPoint") ??
            throw new ArgumentNullException("Mandatory parameter", "AggregatorSettings:EdicionGruposEndPoint"));
    }
    public async Task<EdicionGrupo?> GetEdicionGrupo(int id)
    {
        var request = new RestRequest("/{id}", Method.Get);
        request.AddParameter("id", id, ParameterType.UrlSegment);
        var response = await _restClient.ExecuteAsync(request);
        if (!response.IsSuccessful) return null;
        return JsonConvert.DeserializeObject<EdicionGrupo>(response.Content ?? "");
    }
}
