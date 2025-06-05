using Conference_Management_System.Models.Common;

namespace Conference_Management_System.Models
{
    public class Participation : BaseEntity
    {
        public int InvitationId { get; set; }
        public DateTime? CheckInTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public string SeatNumber { get; set; } = string.Empty;
        public Invitation Invitation { get; set; }
    }
}
