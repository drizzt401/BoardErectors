using BoardErectors.Application.Services;
using BoardErectors.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BoardErectors.Infrastructure.Services
{
    public class EstateAgentAccountService : IEstateAgentAccountService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly ILogger<PropertyService> _logger;
        private readonly IConfiguration _configuration;

        private readonly string _baseUrl;

        public EstateAgentAccountService(IHttpClientFactory httpClientFactory, ILogger<PropertyService> logger, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _baseUrl = configuration["BoardErectors:BaseUrl"];
        }


        public async Task<Agent> GetAgentDetails(string accountCode)
        {
            Agent agent;

            var httpClient = _httpClientFactory.CreateClient();
            using (var response = await httpClient.GetAsync($"{_baseUrl}/{accountCode}",
                HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();
                agent = await JsonSerializer.DeserializeAsync<Agent>(stream, _options);
            }

            return agent;
        }
    }
}
