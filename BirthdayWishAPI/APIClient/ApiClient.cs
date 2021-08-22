using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using BirthdayWishAPI.Services.Logging;
using BirthdayWishAPI.Models;

namespace BirthdayWishAPI.APIClient
{
		public class ApiClient : IApiClient
    {
				private readonly IHttpClientFactory  _httpClientFactory;
        private readonly ILoggerManager _logger;

				public ApiClient(IHttpClientFactory httpClientFactory, ILoggerManager logger)
				{
						_httpClientFactory = httpClientFactory;
            _logger = logger;
				}
				public async Task<List<T>> GetTAsync<T>(string requestUrl)
				{
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                //create or pull the client from the client pool using the _httpClientFactory 
                var client = _httpClientFactory.CreateClient();

                HttpResponseMessage httpResponse = await client.SendAsync(request);

                if (httpResponse.IsSuccessStatusCode)
                {

                    var result = await httpResponse.Content.ReadFromJsonAsync<List<T>>();
                    _logger.Information("Data returned successfully");
                    return result;
                }
                else
                {
                    _logger.Error($"{httpResponse.StatusCode} {httpResponse.ReasonPhrase}");
                    return default(List<T>);

                }

            }
            catch (HttpRequestException ex)
            {
                _logger.LogFatal(ex);
                return default(List<T>);
            }
            catch (Exception ex)
            {
                _logger.LogFatal(ex);
                return default(List<T>);
            }
        }
		}
}
