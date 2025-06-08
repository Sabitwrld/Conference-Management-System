using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Event
{
    public class EventVM
    {
        public int Id { get; set; }

        [Display(Name = "Başlıq")]
        public string Title { get; set; }

        [Display(Name = "Təsvir")]
        public string Description { get; set; }

        [Display(Name = "Tarix")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Məkan")]
        public string LocationName { get; set; }

        [Display(Name = "Tədbir Növü")]
        public string EventTypeName { get; set; }

        [Display(Name = "Təşkilatçı")]
        public string OrganizerFullName { get; set; }
    }
}
