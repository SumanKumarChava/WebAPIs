namespace NZWalksAPI.Models.DTO
{
    public class AddWalkRequest
    {
        public double Length { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid WalkDifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
