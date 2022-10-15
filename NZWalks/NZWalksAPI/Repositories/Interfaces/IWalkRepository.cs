using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.Interfaces
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllWalks();

        Task<Walk?> GetWalkById(Guid id);

        Task<Walk> InsertWalk(Walk walk);

        Task<Walk?> UpdateWalk(Guid id, Walk walk);

        Task<Walk?> DeleteWalk(Guid id);
    }
}
