using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.Interfaces
{
    public interface IWalkDifficultyRepository
    {
        Task<List<WalkDifficulty>> GetAllWalkDifficulties();

        Task<WalkDifficulty?> GetWalkDifficultyById(Guid id);

        Task<WalkDifficulty> InsertWalkDifficulty(WalkDifficulty walk);

        Task<WalkDifficulty?> UpdateWalkDifficulty(Guid id, WalkDifficulty walk);

        Task<WalkDifficulty?> DeleteWalkDifficulty(Guid id);
    }
}
