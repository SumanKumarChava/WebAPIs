using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDBContext _dbContext;
        public RegionRepository(NZWalksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Region?> AddRegionAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _dbContext.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var region = _dbContext.Regions.FirstOrDefault(r => r.Id == id);
            if(region == null)
            {
                return null;
            }
            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionAsync(Guid id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var res = await _dbContext.Regions.FirstOrDefaultAsync(t => t.Id == id);
            if(res == null)
            {
                return null;
            }

            res.Area = region.Area;
            res.Name = region.Name;
            res.Population = region.Population;
            res.Long = region.Long;
            res.Lat = region.Lat;
            res.Code = region.Code;
            await _dbContext.SaveChangesAsync();
            return res;
        }
    }
}
