using Conference_Management_System.Enums;
using Conference_Management_System.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conference_Management_System.Models
{
    public class Invitation : BaseEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public InvitationStatusEnum Status { get; set; }
        public DateTime SentAt { get; set; }

        public Participation Participation { get; set; }
    }
}
