using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge24.Core.Dto.ChuckNorrisDto
{
    public class ChuckNorrisResponseDto
    {
        public List<string> Categories { get; set; } = new();
        public string Created_at { get; set; } = string.Empty;
        public string Icon_url { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Updated_at { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
