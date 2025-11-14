using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Modelo.Application.Interface;
using Modelo.Domain;

namespace Modelo.Application
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public CepService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Endereco> BuscarEnderecoPorCep(string cep)
        {
            try
            {
                cep = cep.Replace("-", "");
                string url = $"{_configuration["ApiCep:BaseUrl"]}/{cep}/json/";

                var result = await _httpClient.GetAsync(url);

                if(!result.IsSuccessStatusCode)
                    return null;

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var json = await result.Content.ReadAsStringAsync();

                var endereco = JsonSerializer.Deserialize<Endereco>(json, options);

                return endereco;

            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
