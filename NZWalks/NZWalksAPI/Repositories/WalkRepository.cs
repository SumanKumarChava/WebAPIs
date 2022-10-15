using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDBContext _NZWalksDBContext;
        public WalkRepository(NZWalksDBContext nZWalksDBContext)
        {
            _NZWalksDBContext = nZWalksDBContext;
        }


        public async Task<Walk?> DeleteWalk(Guid id)
        {
            var walk = await GetWalkById(id);
            if(walk == null)
            {
                return null;
            }
            _NZWalksDBContext.Walks.Remove(walk);
            await _NZWalksDBContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalks()
        {
            return await _NZWalksDBContext.Walks
                .Include(w => w.Region)
                .Include(w => w.WalkDifficulty) 
                .ToListAsync();
        }

        public async Task<Walk?> GetWalkById(Guid id)
        {
           return await _NZWalksDBContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<Walk> InsertWalk(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await _NZWalksDBContext.Walks.AddAsync(walk);
            await _NZWalksDBContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> UpdateWalk(Guid id, Walk walk)
        {
            var tempWalk = await GetWalkById(id);

            if(tempWalk == null)
            {
                return null;
            }

            tempWalk.WalkDifficultyId = walk.WalkDifficultyId;
            tempWalk.Name = walk.Name;
            tempWalk.Length = walk.Length;
            tempWalk.RegionId = walk.RegionId;
            await _NZWalksDBContext.SaveChangesAsync();

            return tempWalk;
        }
    }
}
