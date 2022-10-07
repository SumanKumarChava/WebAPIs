namespace NZWalksAPI.Models.DTO
{
    public class AddRegionRequest
    {
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long TotalPopulation { get; set; }
    }
}
