using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.Dto.OpenWeathers;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Models.OpenWeathers;

namespace ShopTARge24.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IOpenWeathersServices _openWeathersServices;

        public OpenWeatherController
            (
                IOpenWeathersServices openWeathersServices
            )
        {
            _openWeathersServices = openWeathersServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(OpenWeatherSearchCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("WeatherForecast", "OpenWeather", new {cityName = model.CityName });
            }
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> WeatherForecast(string cityName)
        {
            OpenWeathersDto dto = new()
            {
                Name = cityName
            };

            var weatherResult = await _openWeathersServices.OpenWeatherResult(dto);

            OpenWeatherWeatherForecastViewModel vm = new();

            vm.Name = weatherResult.Name;
            vm.Temp = weatherResult.Main.Temp;
            vm.FeelsLike = weatherResult.Main.FeelsLike;
            vm.Humidity = weatherResult.Main.Humidity;
            vm.Pressure = weatherResult.Main.Pressure;
            vm.Speed = weatherResult.Wind.Speed;
            vm.Desctiption = weatherResult.Weather.FirstOrDefault()?.Description;

            return View("WeatherForecast", vm);
        }
    
    }
}
