using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        private List<User> Users = new List<User>()
        {
            new User()
            {
                UserName = "Reader",
                Password = "123456",
                Roles = new List<string>(){"reader"},
                EmailAddress = "reader@NZWalks.com",
                FirstName = "Reader",
                LastName = "Only",
                Id = Guid.NewGuid()
            },
            new User()
            {
                UserName = "ReaderWriter",
                Password = "123456",
                Roles = new List<string>(){"reader", "writer"},
                EmailAddress = "readerwriter@NZWalks.com",
                FirstName = "Reader",
                LastName = "Writer",
                Id = Guid.NewGuid()
            }
        };

        public User? AuthenticateUser(string username, string password)
        {
            var dbUser = Users.FirstOrDefault(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase) && password.Equals(password));
            if(dbUser == null)
            {
                return null;
            }
            return dbUser;
        }
    }
}
