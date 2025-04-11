using Axa.NadraClient.Nadra.Models.OtcVerify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Axa.NadraClient.Nadra
{
    public sealed class NadraHttpClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public NadraHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken)
        {
            if(request.GetType() == typeof(OtcVerifyFingerprintsRequest))
            {
                _httpClient.DefaultRequestHeaders.Add("x-client-id", ((OtcVerifyFingerprintsRequest)(object)request).clientId);
            }

            var response = await _httpClient.PostAsJsonAsync(endpoint, request, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
