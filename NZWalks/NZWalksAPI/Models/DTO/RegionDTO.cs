using System.Text.Json.Serialization;

namespace NZWalksAPI.Models.DTO
{
    public class RegionDTO
    {
        public Guid RegionId { get; set; }
        public string RegionCode { get; set; } = string.Empty;
        public string RegionName { get; set; } = String.Empty;
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long TotalPopulation { get; set; }

    }
}
