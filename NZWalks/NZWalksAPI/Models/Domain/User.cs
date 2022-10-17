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
        public List<string>? Roles { get; set; }
    }
}
