using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegionsAsync();
        Task<Region?> GetRegionAsync(Guid id);
        Task<Region?> AddRegionAsync(Region region);
        Task<Region?> DeleteRegionAsync(Guid id);
        Task<Region?> UpdateRegionAsync(Guid id, Region region);
    }
}
