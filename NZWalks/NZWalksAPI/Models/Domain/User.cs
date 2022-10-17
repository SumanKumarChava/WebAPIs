using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalksAPI.Models.Domain
{
    public class User
    {
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public Guid Id { get; set; }
        public string EmailAddress { get; set; } = String.Empty;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;

        [NotMapped]
        public List<string>? Roles { get; set; }

        // Navigation property
        public List<User_Role> UserRoles { get; set; }
    }
}
