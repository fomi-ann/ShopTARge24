using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.Dto.CocktailsDto;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Models.Cocktails;

namespace ShopTARge24.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ICocktailsServices _cocktailServices;

        public CocktailsController
            (
                ICocktailsServices cocktailServices
            )
        {
            _cocktailServices = cocktailServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCocktail(string cocktail)
        {
            DrinkDto dto = new() { strDrink = cocktail};
            //await _cocktailServices.GetCocktail(dto);

            var result = await _cocktailServices.GetCocktail( dto );

            if (result == null)
            {
                ViewBag.ErrorMessage = "No cocktail found, try another name";
                return View("Index");
            }

            var vm = new CocktailRecipeViewModel
            {
                idDrink = result.idDrink,
                strDrink = result.strDrink,
                strDrinkAlternate = result.strDrinkAlternate,
                strTags = result.strTags,
                strVideo = result.strVideo,
                strCategory = result.strCategory,
                strIBA = result.strIBA,
                strAlcoholic = result.strAlcoholic,
                strGlass = result.strGlass,
                strInstructions = result.strInstructions,
                strInstructionsES = result.strInstructionsES,
                strInstructionsDE = result.strInstructionsDE,
                strInstructionsFR = result.strInstructionsFR,
                strInstructionsIT = result.strInstructionsIT,
                strInstructionsZHHANS = result.strInstructionsZHHANS,
                strInstructionsZHHANT = result.strInstructionsZHHANT,
                strDrinkThumb = result.strDrinkThumb,

                strIngredient1 = result.strIngredient1,
                strIngredient2 = result.strIngredient2,
                strIngredient3 = result.strIngredient3,
                strIngredient4 = result.strIngredient4,
                strIngredient5 = result.strIngredient5,
                strIngredient6 = result.strIngredient6,
                strIngredient7 = result.strIngredient7,
                strIngredient8 = result.strIngredient8,
                strIngredient9 = result.strIngredient9,
                strIngredient10 = result.strIngredient10,
                strIngredient11 = result.strIngredient11,
                strIngredient12 = result.strIngredient12,
                strIngredient13 = result.strIngredient13,
                strIngredient14 = result.strIngredient14,
                strIngredient15 = result.strIngredient15,

                strMeasure1 = result.strMeasure1,
                strMeasure2 = result.strMeasure2,
                strMeasure3 = result.strMeasure3,
                strMeasure4 = result.strMeasure4,
                strMeasure5 = result.strMeasure5,
                strMeasure6 = result.strMeasure6,
                strMeasure7 = result.strMeasure7,
                strMeasure8 = result.strMeasure8,
                strMeasure9 = result.strMeasure9,
                strMeasure10 = result.strMeasure10,
                strMeasure11 = result.strMeasure11,
                strMeasure12 = result.strMeasure12,
                strMeasure13 = result.strMeasure13,
                strMeasure14 = result.strMeasure14,
                strMeasure15 = result.strMeasure15,

                strImageSource = result.strImageSource,
                strImageAttribution = result.strImageAttribution,
                strCreativeCommonsConfirmed = result.strCreativeCommonsConfirmed,
                dateModified = result.dateModified,
            };

            return View("CocktailRecipe", vm);
        }
    }
}
