using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge24.Core.Dto.ChuckNorrisDto;

namespace ShopTARge24.Core.ServiceInterface
{
    public interface IChuckNorrisServices
    {
        Task<ChuckNorrisResponseDto> GetChuckNorrisJoke(ChuckNorrisResponseDto dto);
    }
}
