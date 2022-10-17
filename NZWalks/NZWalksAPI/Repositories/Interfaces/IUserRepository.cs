using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> AuthenticateUser(string username, string password);
    }
}
