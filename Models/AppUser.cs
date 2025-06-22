using Conference_Management_System.Enums;
using Microsoft.AspNetCore.Identity;

namespace Conference_Management_System.Models
{
    public class AppUser : IdentityUser
    {
        public int? PersonId { get; set; }
        public Person Person { get; set; }
    }
}
