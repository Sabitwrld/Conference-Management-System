using Conference_Management_System.Enums;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Invitation
{
    public class InvitationVM
    {
        public int Id { get; set; }

        [Display(Name = "Tədbir")]
        public string EventTitle { get; set; }

        [Display(Name = "İştirakçı")]
        public string PersonFullName { get; set; }

        [Display(Name = "Status")]
        public InvitationStatus Status { get; set; }

        [Display(Name = "Status Adı")]
        public string StatusName => Status.ToString();

        [Display(Name = "Göndərilmə Vaxtı")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime SentAt { get; set; }
    }
}
