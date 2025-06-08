using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Participation
{
    public class ParticipationVM
    {
        public int Id { get; set; }

        [Display(Name = "Dəvət ID")]
        public int InvitationId { get; set; }

        [Display(Name = "Tədbir Başlığı")]
        public string EventTitle { get; set; }

        [Display(Name = "İştirakçı")]
        public string ParticipantName { get; set; }

        [Display(Name = "Check-in Vaxtı")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? CheckInTime { get; set; }

        [Display(Name = "Oturacaq Nömrəsi")]
        public string SeatNumber { get; set; }
    }
}
