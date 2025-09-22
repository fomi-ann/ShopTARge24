using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopTARge24.Core.Domain;

namespace ShopTARge24.Data
{
    public class ShopTARge24Context : DbContext
    {
        public ShopTARge24Context(DbContextOptions<ShopTARge24Context> options) : base(options)
        {
        }
        public DbSet<Spaceships> Spaceships { get; set; }
        public DbSet<FileToApi> FileToApis { get; set; }


    }
}
