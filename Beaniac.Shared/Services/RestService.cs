using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Beaniac.Shared.Models;

namespace Beaniac.Shared.Services
{
    public class RestService
    {
        private readonly HttpClient _httpClient;
        private Dictionary<Type, object> _cache = new();
        public RestService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(nameof(RestService));
        }

        public async Task<List<T>?> GetAsync<T>(bool forceRefresh = false)
        {
            if(_cache.ContainsKey(typeof(T)) && !forceRefresh){
                Console.WriteLine("Cache hit");
                var items = _cache[typeof(T)] as List<T>;
                Console.WriteLine(items.Count);
                return _cache[typeof(T)] as List<T>;
            }
            else {
                Console.WriteLine("Cache miss");
                var _endpoint = typeof(T).Name.ToLower();
                try{
                    var result = await _httpClient.GetFromJsonAsync<ApiResult<T>>(_endpoint);
                    if(result?.Items is List<T> items){
                        _cache[typeof(T)] = items;
                        return items;
                    }
                    return null;
                } catch (Exception e){
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public async Task<T?> GetByIdAsync<T>(Guid id, bool forceRefresh = false, bool skipCache = false) where T : class
        {
            var _endpoint = typeof(T).Name.ToLower();
            if(!forceRefresh && !skipCache && _cache.ContainsKey(typeof(T)) && _cache[typeof(T)] is List<T> items){
                var item = items.FirstOrDefault(i => (i as IDisplayItem)?.Id == id);
                if(item is T){
                    return item as T;
                }
                else {
                    var result = await _httpClient.GetFromJsonAsync<T>($"{_endpoint}/{id}");
                    if (result != null)
                    {
                        items.Add(result);
                        _cache[typeof(T)] = items;
                    }
                    return result;
                }
            }
            else {
                var result = await _httpClient.GetFromJsonAsync<T>($"{_endpoint}/{id}");
                if (!skipCache && result != null)
                {
                    _cache[typeof(T)] = new List<T>{result};
                }
                return result;
            }
        }

        public async Task<IEnumerable<PopularityResult<T>>?> GetTopAsync<T>()
        {
            var _endpoint = typeof(T).Name.ToLower();
            return await _httpClient.GetFromJsonAsync<IEnumerable<PopularityResult<T>>>($"{_endpoint}/top");
        }

        public async Task AddAsync<T>(T item)
        {
            var _endpoint = typeof(T).Name.ToLower();
            var response = await _httpClient.PostAsJsonAsync(_endpoint, item);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync<T>(T item, Guid id)
        {
            var _endpoint = typeof(T).Name.ToLower();
            var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{id}", item);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync<T>(Guid id)
        {
            var _endpoint = typeof(T).Name.ToLower();
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}