using Microsoft.Extensions.Configuration;
using ShopTARge24.Core.Dto.OpenWeathers;
using ShopTARge24.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopTARge24.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeathersServices

    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public OpenWeatherServices
            (
            IConfiguration configuration, 
            HttpClient httpClient
            )
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<OpenWeathersDto> OpenWeatherResult(OpenWeathersDto dto)
        {
            string apiKey = _configuration["OpenWeatherApiKey"];
            
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.Name}&appid={apiKey}&units=metric";
            
            var response = await _httpClient.GetAsync( url );
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();


            var weather = JsonSerializer.Deserialize<OpenWeathersDto>(jsonResponse);
            
            return weather;
        }
    }
}
