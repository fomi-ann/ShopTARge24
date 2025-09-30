﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge24.Core.Domain;
using ShopTARge24.Core.Dto;

namespace ShopTARge24.Core.ServiceInterface
{
    public interface IRealEstateServices
    {
        Task<RealEstate> DetailAsync(Guid id);
        Task<RealEstate> Create(RealEstateDto dto);
    }
}
