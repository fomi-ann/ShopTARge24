using Microsoft.Extensions.Configuration;
using ShopTARge24.Core.Dto.OpenWeathers;
using ShopTARge24.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge24.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeathersServices

    {
        private readonly IConfiguration _configuration;

        public OpenWeatherServices(IConfiguration configuration)
        {
            _configuration = configuration;
            //OpenWeatherApiKey
        }

        public async Task<OpenWeathersDto> OpenWeatherResult(OpenWeathersDto dto)
        {
            string apiKey = _configuration["OpenWeatherApiKey"];
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.Name}&appid={apiKey}&units=metric";
            return null;
        }
    }
}
