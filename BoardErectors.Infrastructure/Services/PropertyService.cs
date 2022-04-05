using BoardErectors.Application.Services;
using BoardErectors.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BoardErectors.Infrastructure.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly ILogger<PropertyService> _logger;
        private readonly IConfiguration _configuration;

        private readonly string _baseUrl;

        public PropertyService(IHttpClientFactory httpClientFactory, ILogger<PropertyService> logger, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _baseUrl = configuration["BoardErectors:BaseUrl"];
        }


        public async Task<(IEnumerable<Property>, string)> GetPropertiesByAgentCode(string accountCode)
        {
            IEnumerable<Property> properties;
            (IEnumerable<Property>, string) result;

            var httpClient = _httpClientFactory.CreateClient();
            using (var response = await httpClient.GetAsync($"{_baseUrl}/{accountCode}/properties",
                HttpCompletionOption.ResponseHeadersRead))
            {
                //response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                {
                    properties = await JsonSerializer.DeserializeAsync<IEnumerable<Property>>(stream, _options);
                    foreach (var property in properties)
                    {
                        if (property.ErectedBoardType.Title.Equals("Sold") )
                        {
                            var levy = ((float)7.5 / 100) * property.TotalFeeCharged;
                            property.TotalFeeCharged += levy;
                        }
                        if (property.ErectedBoardType.Title.Equals("Sale Agreed") )
                        {
                            var levy = ((float)4 / 100) * property.TotalFeeCharged;
                            property.TotalFeeCharged += levy;
                        }
                    }
                    result.Item1 = properties;
                    result.Item2 = "Successful";
                }
                else
                {
                    ProblemDetails problemDetails = await JsonSerializer.DeserializeAsync<ProblemDetails>(stream, _options);
                    result.Item1 = null;
                    result.Item2 = problemDetails.Detail ?? problemDetails.Title;

                }

            }

            return result;
        }
    }
}
