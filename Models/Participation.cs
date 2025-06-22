using Conference_Management_System.Models.Common;

namespace Conference_Management_System.Models
{
    public class Participation : BaseEntity
    {
        public int InvitationId { get; set; }
        public Invitation Invitation { get; set; }

        public DateTime CheckInTime { get; set; }
        public int SeatNumber { get; set; }
    }
}
