using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Notification
{
    public class NotificationVM
    {
        public int Id { get; set; }

        [Display(Name = "Tədbir Başlığı")]
        public string EventTitle { get; set; }

        [Display(Name = "Mesaj")]
        public string Message { get; set; }

        [Display(Name = "Göndərilmə Vaxtı")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime SentAt { get; set; }
    }
}
