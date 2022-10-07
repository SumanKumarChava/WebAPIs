using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegionsAsync();
        Task<Region?> GetRegionAsync(Guid id);
    }
}
