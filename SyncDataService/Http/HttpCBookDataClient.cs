using LibraryManagementSystem.Dtos;
using System.Text;
using System.Text.Json;

namespace LibraryManagementSystem.SyncDataService.Http
{
    public class HttpCBookDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCBookDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendBookToCommand(BookReadDto book)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(book),
                  encoding: Encoding.UTF8,
                  "application/json"
                );

            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> POST to BookService was OK!");
            }
            else
            {
                Console.WriteLine("POST to BookService was NOT OK!");
            }
        }
    }
}
