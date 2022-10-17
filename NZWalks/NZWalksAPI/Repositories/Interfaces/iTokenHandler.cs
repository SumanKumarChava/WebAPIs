using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.Interfaces
{
    public interface iTokenHandler
    {
        Task<string> GetTokenAsync(User user);
    }
}
