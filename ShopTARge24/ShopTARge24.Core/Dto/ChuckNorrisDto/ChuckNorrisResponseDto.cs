using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge24.Core.Dto.ChuckNorrisDto
{
    public class ChuckNorrisResponseDto
    {
        public List<object> Categories { get; set; }
        public string Created_at { get; set; } = string.Empty;
        public string Icon_url { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Updated_at { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class Categories
    {
        public string Animal { get; set; } = string.Empty;
        public string Career { get; set; } = string.Empty;
        public string Celebrity { get; set; } = string.Empty;
        public string Dev { get; set; } = string.Empty;
        public string Explicit { get; set; } = string.Empty;
        public string Fashion { get; set; } = string.Empty;
        public string Food { get; set; } = string.Empty;
        public string History { get; set; } = string.Empty;
        public string Money { get; set; } = string.Empty;
        public string Movie { get; set; } = string.Empty;
        public string Music { get; set; } = string.Empty;
        public string Political { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public string Science { get; set; } = string.Empty;
        public string Sport { get; set; } = string.Empty;
        public string Travel { get; set; } = string.Empty;
    }
}
