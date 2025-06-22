using Conference_Management_System.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.Models
{
    public class Notification : BaseEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
