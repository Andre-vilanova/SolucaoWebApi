using System;


using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;


namespace SoftPlan.Calc.Integration.Tests.Helpers
{
    public abstract class BaseHttpServiceClient
    {
        private readonly HttpClient _cliente;
        private readonly int _port = 44350;
        // json

        internal BaseHttpServiceClient(TestServer client)
        {
            this._cliente = client.CreateClient();
            this._cliente.DefaultRequestHeaders.Accept.Clear();
            this._cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> GetAsync(string route)
            => await _cliente
                .SendAsync(CreateRequestMessage(HttpMethod.Get, $"http://localhost:{this._port}/api/v1/{route}"));

        private static HttpRequestMessage CreateRequestMessage(HttpMethod method, string route)
            => new HttpRequestMessage { Method = method, RequestUri = new Uri(route) };
    }
}
