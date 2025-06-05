using Conference_Management_System.Enums;
using Conference_Management_System.Models.Common;

namespace Conference_Management_System.Models
{
    public class Person : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public PersonRole Role { get; set; }
    }
}
