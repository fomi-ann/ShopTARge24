using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopTARge24.Core.Domain;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;

namespace ShopTARge24.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstateServices
    {
        private readonly ShopTARge24Context _context;

        public RealEstateServices
            (
            ShopTARge24Context context
            )
        {
            _context = context;
        }

        public async Task<RealEstate> DetailAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
