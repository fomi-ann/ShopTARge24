using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Core.Dto.CocktailsDto;
using Nancy;
using System.Net;
using Nancy.Json;

namespace ShopTARge24.ApplicationServices.Services
{
    public class CocktailsServices : ICocktailsServices
    {
        public async Task<DrinkDto> GetRandomCocktail(DrinkDto dto)
        {
            string url = $"https://www.thecocktaildb.com/api/json/v1/1/random.php";
            
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var root = new JavaScriptSerializer().Deserialize<Root>(json);
                var drinkResponseDto = root.Drinks.FirstOrDefault();
                //DrinkDto drinkResponseDto = new JavaScriptSerializer()
                    //.Deserialize<DrinkDto>(json);
                
                dto.idDrink = drinkResponseDto.idDrink;
                dto.strDrink = drinkResponseDto.strDrink;
                dto.strDrinkAlternate = drinkResponseDto.strDrinkAlternate;
                dto.strTags = drinkResponseDto.strTags;
                dto.strVideo = drinkResponseDto.strVideo;
                dto.strCategory = drinkResponseDto.strCategory;
                dto.strIBA = drinkResponseDto.strIBA;
                dto.strAlcoholic = drinkResponseDto.strAlcoholic;
                dto.strGlass = drinkResponseDto.strGlass;
                dto.strInstructions = drinkResponseDto.strInstructions;
                dto.strInstructionsES = drinkResponseDto.strInstructionsES;
                dto.strInstructionsDE = drinkResponseDto.strInstructionsDE;
                dto.strInstructionsFR = drinkResponseDto.strInstructionsFR;
                dto.strInstructionsIT = drinkResponseDto.strInstructionsIT;
                dto.strInstructionsZHHANS = drinkResponseDto.strInstructionsZHHANS;
                dto.strInstructionsZHHANT = drinkResponseDto.strInstructionsZHHANT;
                dto.strDrinkThumb = drinkResponseDto.strDrinkThumb;
                
                dto.strIngredient1 = drinkResponseDto.strIngredient1;
                dto.strIngredient2 = drinkResponseDto.strIngredient2;
                dto.strIngredient3 = drinkResponseDto.strIngredient3;
                dto.strIngredient4 = drinkResponseDto.strIngredient4;
                dto.strIngredient5 = drinkResponseDto.strIngredient5;
                dto.strIngredient6 = drinkResponseDto.strIngredient6;
                dto.strIngredient7 = drinkResponseDto.strIngredient7;
                dto.strIngredient8 = drinkResponseDto.strIngredient8;
                dto.strIngredient9 = drinkResponseDto.strIngredient9;
                dto.strIngredient10 = drinkResponseDto.strIngredient10;
                dto.strIngredient11 = drinkResponseDto.strIngredient11;
                dto.strIngredient12 = drinkResponseDto.strIngredient12;
                dto.strIngredient13 = drinkResponseDto.strIngredient13;
                dto.strIngredient14 = drinkResponseDto.strIngredient14;
                dto.strIngredient15 = drinkResponseDto.strIngredient15;

                dto.strMeasure1 = drinkResponseDto.strMeasure1;
                dto.strMeasure2 = drinkResponseDto.strMeasure2;
                dto.strMeasure3 = drinkResponseDto.strMeasure3;
                dto.strMeasure4 = drinkResponseDto.strMeasure4;
                dto.strMeasure5 = drinkResponseDto.strMeasure5;
                dto.strMeasure6 = drinkResponseDto.strMeasure6;
                dto.strMeasure7 = drinkResponseDto.strMeasure7;
                dto.strMeasure8 = drinkResponseDto.strMeasure8;
                dto.strMeasure9 = drinkResponseDto.strMeasure9;
                dto.strMeasure10 = drinkResponseDto.strMeasure10;
                dto.strMeasure11 = drinkResponseDto.strMeasure11;
                dto.strMeasure12 = drinkResponseDto.strMeasure12;
                dto.strMeasure13 = drinkResponseDto.strMeasure13;
                dto.strMeasure14 = drinkResponseDto.strMeasure14;
                dto.strMeasure15 = drinkResponseDto.strMeasure15;

                dto.strImageSource = drinkResponseDto.strImageSource;
                dto.strImageAttribution = drinkResponseDto.strImageAttribution;
                dto.strCreativeCommonsConfirmed = drinkResponseDto.strCreativeCommonsConfirmed;
                dto.dateModified = drinkResponseDto.dateModified;
            }

            return dto;
        }
    }
}
