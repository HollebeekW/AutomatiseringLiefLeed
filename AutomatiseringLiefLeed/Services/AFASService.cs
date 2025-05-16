using System.Net.Http.Headers;
using System.Text.Json;

namespace AutomatiseringLiefLeed.Services
{
    // Dummy Employee class for compilation. Replace with your actual Employee model.
    public class Employee
    {
        
    }

    public class Department
    {
    }

    public class Reason
    {
    }

    public class AFASService
    {
        private readonly HttpClient _httpClient;
        private readonly string _tokenXml;
        private readonly string _baseUrl;

        public AFASService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            var envId = configuration["AFAS:EnvironmentId"];
            var token = configuration["AFAS:Token"];
            var baseUrlTemplate = configuration["AFAS:BaseUrlTemplate"];

            _tokenXml = $"<token><version>1</version><data>{token}</data></token>";
            _baseUrl = string.Format(baseUrlTemplate, envId);
        }

        public async Task<List<T>> GetDataAsync<T>(string connectorId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}{connectorId}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("Authorization", $"AfasToken {_tokenXml}");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
        }

        public Task<List<Employee>> GetEmployeesAsync() => GetDataAsync<Employee>("employees");
        public Task<List<Department>> GetDepartmentsAsync() => GetDataAsync<Department>("departments");
        public Task<List<Reason>> GetReasonsAsync() => GetDataAsync<Reason>("reasons");

    }
}
