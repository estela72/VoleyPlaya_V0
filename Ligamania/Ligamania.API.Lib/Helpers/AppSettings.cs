using Microsoft.Extensions.Configuration;

namespace Ligamania.API.Lib
{
    public interface ILigamaniaConfiguration
    {
        string Secret { get; }
        string ValidAudience { get; }
        string ValidIssuer { get; }

        IConfigurationSection GetConfigurationSection(string Key);
    }

    public class LigamaniaConfiguration : ILigamaniaConfiguration
    {
        public LigamaniaConfiguration(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        private readonly IConfiguration _configuration;
        public string Secret { get { return GetConfigurationSection("JWT")["Secret"]; } }
        public string ValidAudience { get { return GetConfigurationSection("JWT")["ValidAudience"]; } }
        public string ValidIssuer { get { return GetConfigurationSection("JWT")["ValidIssuer"]; } }

        public IConfigurationSection GetConfigurationSection(string Key)
        {
            return _configuration.GetSection(Key);
        }
    }
}