using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Feedback
{
    public class FeedbackVM
    {
        public int Id { get; set; }

        [Display(Name = "Tədbir Başlığı")]
        public string EventTitle { get; set; }

        [Display(Name = "Rəy Verən")]
        public string PersonFullName { get; set; }

        [Display(Name = "Reytinq")]
        public int Rating { get; set; }

        [Display(Name = "Rəy")]
        public string Comment { get; set; }

        [Display(Name = "Göndərilmə Vaxtı")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime SubmittedAt { get; set; }
    }
}
