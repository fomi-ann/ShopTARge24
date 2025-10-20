using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client.Kerberos;

namespace ShopTARge24.Core.Dto
{

    public class AccuCityCodeRootDto
    {
        public int Version { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string LocalizedName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public string PrimaryPostalCode { get; set; } = string.Empty;
        public Region? Region { get; set; }
        public Country? Country { get; set; }
        public AdministrativeArea? AdministrativeArea { get; set; }
        public TimeZone? TimeZone { get; set; }
        public GeoPosition? GeoPosition { get; set; }
        public bool IsAlias { get; set; }
        public SupplementalAdminAreas? SupplementalAdminAreas { get; set; }
        public List<string> DataSets { get; set; }
    }


    public class Region
    {
        public string Id { get; set; } = string.Empty;
        public string LocalizedName {  set; get; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
    }

    public class Country
    {
        public string Id { get; set; } = string.Empty;
        public string LocalizedName { set; get; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
    }

    public class AdministrativeArea
    {
        public string Id { get; set; } = string.Empty;
        public string LocalizedName { set; get; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public int Level { get; set; }
        public string LocalizedType { get; set; } = string.Empty;
        public string EnglishType { get; set; } = string.Empty;
        public string CountryId { get; set; } = string.Empty;
    }

    public class TimeZone
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
        public string NextOffsetChange { get; set; } = string.Empty;
    }

    public class GeoPosition
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Elevation? Metric { get; set; }
        public Elevation? Imperial{ get; set; }
    }

    public class Elevation
    {
        public Metric? Metric { get; set; }
        public Imperial? Imperial { get; set; }
    }

    public class Metric
    {
        public int Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int UnitType { get; set; }
    }

    public class Imperial
    {
        public int Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int UnitType { get; set; }
    }

    public class SupplementalAdminAreas
    {
        public int Level { get; set; }
        public string LocalizedType { get; set; } = string.Empty;
        public string EnglishType { get; set; } = string.Empty;
    }

}
