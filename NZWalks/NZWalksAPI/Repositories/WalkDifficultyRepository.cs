using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDBContext _NZWalksDBContext;
        public WalkDifficultyRepository(NZWalksDBContext nZWalksDBContext)
        {
            _NZWalksDBContext = nZWalksDBContext;
        }


        public async Task<WalkDifficulty?> DeleteWalkDifficulty(Guid id)
        {
            var walkDifficulty = await GetWalkDifficultyById(id);
            if (walkDifficulty == null)
            {
                return null;
            }
            _NZWalksDBContext.WalkDifficulty.Remove(walkDifficulty);
            await _NZWalksDBContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<List<WalkDifficulty>> GetAllWalkDifficulties()
        {
            return await _NZWalksDBContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty?> GetWalkDifficultyById(Guid id)
        {
            return await _NZWalksDBContext.WalkDifficulty.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<WalkDifficulty> InsertWalkDifficulty(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await _NZWalksDBContext.WalkDifficulty.AddAsync(walkDifficulty);
            await _NZWalksDBContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public Task<Walk> InsertWalkDifficulty(Walk walk)
        {
            throw new NotImplementedException();
        }

        public async Task<WalkDifficulty?> UpdateWalkDifficulty(Guid id, WalkDifficulty walkDifficulty)
        {
            var tempWalkDifficulty = await GetWalkDifficultyById(id);
            if (tempWalkDifficulty == null)
            {
                return null;
            }
            tempWalkDifficulty.Code = walkDifficulty.Code;
            await _NZWalksDBContext.SaveChangesAsync();
            return tempWalkDifficulty;
        }
    }
}
