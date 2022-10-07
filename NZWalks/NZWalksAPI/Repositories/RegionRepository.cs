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

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionAsync(Guid id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
