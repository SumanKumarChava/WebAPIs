namespace NZWalksAPI.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public double Length { get; set; }
        public string Name { get; set; }= String.Empty;
        public Guid WalkDifficultyId { get; set; }
        public Guid RegionId { get; set; }

        // Navigation property
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
