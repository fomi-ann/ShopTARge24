using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.ServiceInterface;

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
    }
}
