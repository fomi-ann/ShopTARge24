using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Nancy.Json;
using ShopTARge24.Core.Dto.ChuckNorrisDto;
using ShopTARge24.Core.ServiceInterface;
using static System.Net.WebRequestMethods;

namespace ShopTARge24.ApplicationServices.Services
{
    public class ChuckNorrisServices : IChuckNorrisServices
    {
        public async Task<ChuckNorrisResponseDto> GetChuckNorrisJoke(ChuckNorrisResponseDto dto, string selectedCategory = null)
        {
            string url = $"https://api.chucknorris.io/jokes/random";

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                url += $"?category={selectedCategory}";
            }

            using (WebClient client = new WebClient ())
            {
                string json = client.DownloadString (url);
                ChuckNorrisResponseDto responseDto = new JavaScriptSerializer()
                    .Deserialize<ChuckNorrisResponseDto>(json);

                dto.Categories = responseDto.Categories;
                dto.Created_at = responseDto.Created_at;
                dto.Icon_url = responseDto.Icon_url;
                dto.Id = responseDto.Id;
                dto.Updated_at = responseDto.Updated_at;
                dto.Url = responseDto.Url;
                dto.Value = responseDto.Value;
            }

            return dto;
        }

        public List<string> GetCategoriesList()
        {
            string url = "https://api.chucknorris.io/jokes/categories";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var categoriesList = new JavaScriptSerializer().Deserialize<List<string>>(json);
                return categoriesList ?? new List<string>();
            }
        }
    }
}
