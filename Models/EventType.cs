using Conference_Management_System.Enums;
using Conference_Management_System.Models.Common;

namespace Conference_Management_System.Models
{
    public class EventType : BaseEntity
    {
        public Enums.EventTypeEnum Name { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
