using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NZWalksDBContext nZWalksDBContext;
        public UserRepository(NZWalksDBContext nZWalksDBContext)
        {
            this.nZWalksDBContext = nZWalksDBContext;
        }

        public async Task<User?> AuthenticateUser(string username, string password)
        {
            var dbUser = this.nZWalksDBContext.Users.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower() && password.Equals(password));
            if(dbUser == null)
            {
                return null;
            }

            var roles = new List<string>();
            var userRoles = await this.nZWalksDBContext.UserRoles.Where(t => t.UserId == dbUser.Id).ToListAsync();
            if(userRoles != null && userRoles.Count > 0)
            {
                userRoles.ForEach(u =>
                {
                    var roleName = nZWalksDBContext.Roles.FirstOrDefault(t => t.Id == u.RoleId)?.Name;
                    roles.Add(roleName);
                });
            }
            dbUser.Roles = roles;
            return dbUser;
        }
    }
}
