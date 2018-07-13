using Microsoft.Extensions.Logging;
using Polly.CircuitBreaker;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ResilientHttpClient
{
    public class UsersClient
    {
        private HttpClient _client;
        private ILogger<UsersClient> _logger;

        public UsersClient(HttpClient client, ILogger<UsersClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                var response = await _client.GetAsync("users");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<IEnumerable<User>>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"An error occured connecting to Users API {ex.ToString()}");
                return Enumerable.Empty<User>();
            }
            catch (BrokenCircuitException ex)
            {
                _logger.LogError($"CircuitBreaker is open Users API {ex.ToString()}");
                return Enumerable.Empty<User>();
            }
        }
    }
}