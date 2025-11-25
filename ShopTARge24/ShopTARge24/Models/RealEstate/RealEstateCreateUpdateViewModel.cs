using System.ComponentModel.DataAnnotations;
using ShopTARge24.Core.Dto;

namespace ShopTARge24.Models.RealEstate
{
    public class RealEstateCreateUpdateViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage ="Value cannot be nagative or zero.")]
        public double? Area { get; set; }
        
        public string? Location { get; set; }

        ///[Range(1, int.MaxValue, ErrorMessage ="Value cannot be nagative or zero.")]
        [Range(1, 1000)]
        public int? RoomNumber { get; set; }

        public string? BuildingType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public List<IFormFile>? Files { get; set; }
        public List<RealEstateImageViewModel> Images { get; set; }
            = new List<RealEstateImageViewModel>();
    }
}
