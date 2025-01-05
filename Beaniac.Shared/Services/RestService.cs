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
        public RestService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(nameof(RestService));
        }

        public async Task<ApiResult<T>?> GetAsync<T>()
        {
            var _endpoint = typeof(T).Name.ToLower();
            Console.WriteLine(_httpClient.BaseAddress);
            try{
                return await _httpClient.GetFromJsonAsync<ApiResult<T>>(_endpoint);
            } catch (Exception e){
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<T?> GetByIdAsync<T>(Guid id)
        {
            var _endpoint = typeof(T).Name.ToLower();
            return await _httpClient.GetFromJsonAsync<T>($"{_endpoint}/{id}");
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