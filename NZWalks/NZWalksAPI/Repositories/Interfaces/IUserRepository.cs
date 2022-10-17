using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User? AuthenticateUser(string username, string password);
    }
}
