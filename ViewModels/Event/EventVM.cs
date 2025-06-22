using Conference_Management_System.Enums;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Event
{
    public class EventVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string LocationName { get; set; }
        public EventTypeEnum EventType { get; set; }
        public string OrganizerFullName { get; set; }
        public int AcceptedInvitationsCount { get; set; }
        public int CheckedInParticipantsCount { get; set; }
        public double AverageRating { get; set; }
    }
}
