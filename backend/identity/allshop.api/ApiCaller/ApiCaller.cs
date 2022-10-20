using allshop.api.Configuration;
using allshop.api.Contracts.ApiCaller;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace allshop.api.ApiCaller
{
   public class ApiCaller : IApiCaller
    {
        // se lllama un metodo de la api para evaluarlo como externo

        private readonly HttpClient _httpClient;
       
        public ApiCaller(IAppConfig _appConfig)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_appConfig.ServiceUrl)
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<T> GetServiceResponseById<T>(string controller, int id) {

            var response = await _httpClient.GetAsync(String.Format("/{0}/{1}",controller, id));
            if (!response.IsSuccessStatusCode)
            {
                return default(T);
            }

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);

        }


    }
}
