using Conference_Management_System.Enums;
using Conference_Management_System.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.Models
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public PersonRoleEnum Role { get; set; }

        public ICollection<Invitation> Invitations { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }

        public AppUser AppUser { get; set; }
    }
}
