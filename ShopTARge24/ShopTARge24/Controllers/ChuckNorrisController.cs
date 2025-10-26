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
        public async Task<IActionResult> GetJoke(string selectedCategory)
        {
            ChuckNorrisResponseDto dto = new();
            await _chuckNorrisServices.GetChuckNorrisJoke(dto, selectedCategory);
            var vm = new ChuckNorrisJokeViewModel
            {
                Value = dto.Value,
                SelectedCategory = selectedCategory,
                CategoriesList = _chuckNorrisServices.GetCategoriesList(),
                Icon_url = dto.Icon_url
            };

            return View("ChuckNorrisJoke", vm);
        }
    }
}
