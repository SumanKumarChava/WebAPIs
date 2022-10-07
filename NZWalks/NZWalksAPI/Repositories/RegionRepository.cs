using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDBContext _dbContext;
        public RegionRepository(NZWalksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Region> GetAllRegions()
        {
            return _dbContext.Regions.ToList();
        }
    }
}
