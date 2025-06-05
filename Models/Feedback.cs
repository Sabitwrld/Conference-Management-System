using Conference_Management_System.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.Models
{
    public class Feedback : BaseEntity 
    {
        public int EventId { get; set; }
        public int PersonId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime SubmittedAt { get; set; }
        public Event Event { get; set; }
        public Person Person { get; set; }
    }
}
