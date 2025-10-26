using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.Dto.ChuckNorrisDto;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Models.ChuckNorris;

namespace ShopTARge24.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _chuckNorrisServices;

        public ChuckNorrisController
            (
                IChuckNorrisServices chuckNorrisServices
            )
        {
            _chuckNorrisServices = chuckNorrisServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetJoke(ChuckNorrisJokeViewModel model)
        {
            ChuckNorrisResponseDto dto = new();
            _chuckNorrisServices.GetChuckNorrisJoke(dto);
            ChuckNorrisJokeViewModel vm = new();

            vm.Value = dto.Value;

            return View("ChuckNorrisJoke", vm);
        }
    }
}
