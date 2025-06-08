using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Participation
{
    public class ParticipationEditVM
    {
        public int Id { get; set; }
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
