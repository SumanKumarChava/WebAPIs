namespace NZWalksAPI.Models.DTO
{
    public class AddRegionRequest
    {
        public string RegionCode { get; set; } = string.Empty;
        public string RegionName { get; set; } = string.Empty;
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long TotalPopulation { get; set; }
    }
}
