using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Common;

namespace Ui.WebAssembly.Services
{
    public class FooHttpClient
    {
        private readonly HttpClient _client;

        public FooHttpClient(HttpClient client)
        {
            this._client = client;
        }

        public async Task<IEnumerable<WeatherForecast>> GetOrdersAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<WeatherForecast>>($"order/api/WeatherForecast");
        }

        public async Task<IEnumerable<WeatherForecast>> GetShipmentsAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<WeatherForecast>>($"shipment/api/WeatherForecast");
        }
    }
}
