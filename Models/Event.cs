using Conference_Management_System.Enums;
using Conference_Management_System.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conference_Management_System.Models
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public EventTypeEnum EventType { get; set; }

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        public ICollection<Invitation> Invitations { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
