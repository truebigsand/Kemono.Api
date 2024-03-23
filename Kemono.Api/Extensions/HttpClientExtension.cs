using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kemono.Api.Extensions
{
    public static class HttpClientExtension
    {
        public async static Task<T> GetJsonAsync<T>(this HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync()) ?? throw new Exception("Json deserialize failed!");
        }
    }
}
