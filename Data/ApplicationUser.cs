using Microsoft.AspNetCore.Identity;

namespace JNFinalProject.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEmployer { get; set; }
    }
}
