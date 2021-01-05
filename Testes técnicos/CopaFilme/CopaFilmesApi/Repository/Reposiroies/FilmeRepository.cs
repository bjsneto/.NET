using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Domain;
using Repository.Contracts;

namespace Repository.Reposiroies
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly HttpClient _httpClient;

        public FilmeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Filme>> ObterTodos()
        {

            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(
                    ""
                );

                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue(
                        "application/json"
                    )
                );
            }

            var response = await _httpClient.GetAsync("api/filmes");

            if (!response.IsSuccessStatusCode) return new List<Filme>().ToList();
           
            var jsonResult = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Filme>>(jsonResult, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});
           
        }
    }
}
