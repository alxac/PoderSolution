using Dominio.Entidades;

namespace AnelPages.Services
{
    public class AnelApiService
    {
        private readonly HttpClient _httpClient;

        public AnelApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AnelEntidade>> GetAneisAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<IEnumerable<AnelEntidade>>("https://localhost:7191/api/Anel");
            // URL da sua API
        }

        public async Task<AnelEntidade> GetAnelByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<AnelEntidade>($"https://localhost:7191/api/Anel/{id}");
        }

        public async Task<bool> AddAnelAsync(AnelEntidade anel)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7191/api/Anel", anel);
            return response.IsSuccessStatusCode;
        }
    }
}
