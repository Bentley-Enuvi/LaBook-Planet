using Microsoft.AspNetCore.Identity;

namespace LaBook_Planet.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}
