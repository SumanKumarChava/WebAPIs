using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAllRegions();
    }
}
