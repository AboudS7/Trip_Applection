using Microsoft.AspNetCore.Identity;

namespace Trip_Applection.Areas.admin.Models
{
    public class User:IdentityUser
    {
        public string FirestName { get; set; }
        public string LastName { get; set; }
    }
}
