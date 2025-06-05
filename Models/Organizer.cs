using Conference_Management_System.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.Models
{
    public class Organizer : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
