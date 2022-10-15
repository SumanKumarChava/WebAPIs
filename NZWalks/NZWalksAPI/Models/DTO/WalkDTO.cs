using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Models.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public double Length { get; set; }
        public string Name { get; set; } = String.Empty;
        public Guid WalkDifficultyId { get; set; }
        public Guid RegionId { get; set; }

        // Navigation property
        public RegionDTO? Region { get; set; }
        public WalkDifficultyDTO? WalkDifficulty { get; set; }
    }
}
