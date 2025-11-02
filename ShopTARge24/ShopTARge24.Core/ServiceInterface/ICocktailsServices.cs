using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge24.Core.Dto.CocktailsDto;

namespace ShopTARge24.Core.ServiceInterface
{
    public interface ICocktailsServices
    {
        Task<DrinkDto> GetCocktail(DrinkDto dto);
    }
}
