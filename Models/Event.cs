using Conference_Management_System.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conference_Management_System.Models
{
    public class Event : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public int EventTypeId { get; set; }
        public int OrganizerId { get; set; }
        public Location Location { get; set; }
        public EventType EventType { get; set; }
        public Organizer Organizer { get; set; }
        public ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
