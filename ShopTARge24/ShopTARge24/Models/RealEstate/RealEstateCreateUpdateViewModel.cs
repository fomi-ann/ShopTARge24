﻿using ShopTARge24.Core.Dto;

namespace ShopTARge24.Models.RealEstate
{
    public class RealEstateCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public double? Area { get; set; }
        public string? Location { get; set; }
        public int? RoomNumber { get; set; }
        public string? BuildingType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<RealEstateImageViewModel> Images { get; set; }
            = new List<RealEstateImageViewModel>();
    }
}
