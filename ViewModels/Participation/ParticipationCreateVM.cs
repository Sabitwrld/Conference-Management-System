using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Participation
{
    public class ParticipationCreateVM
    {
        [Display(Name = "Dəvət ID")]
        public int InvitationId { get; set; }

        [Display(Name = "Tədbir Başlığı")]
        public string EventTitle { get; set; }

        [Display(Name = "İştirakçı")]
        public string ParticipantName { get; set; }

        [Display(Name = "Oturacaq Nömrəsi")]
        [MaxLength(50)]
        public string SeatNumber { get; set; }
    }
}
