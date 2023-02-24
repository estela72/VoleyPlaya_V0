using Microsoft.AspNetCore.Http;

using System.Text.Json;
using System.Threading.Tasks;

namespace Ligamania.Web.Services
{
    public interface ILocalStorageService
    {
        Task<T> GetItem<T>(string key);

        void SetItem<T>(string key, T value);

        void RemoveItem(string key);
    }

    public class LocalStorageService : ILocalStorageService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public LocalStorageService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<T> GetItem<T>(string key)
        {
            var json = _httpContextAccessor.HttpContext.Session.GetString("user");
            if (json == null)
                return default;
            T js = JsonSerializer.Deserialize<T>(json);
            return await Task.FromResult(js);
        }

        public void SetItem<T>(string key, T value)
        {
            _httpContextAccessor.HttpContext.Session.SetString("user", JsonSerializer.Serialize(value));
        }

        public void RemoveItem(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove("user");
        }
    }
}