using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Notification
{
    public class NotificationEditVM
    {
        public int Id { get; set; }
        [Display(Name = "Tədbir")]
        [Required(ErrorMessage = "Tədbir seçilməlidir.")]
        public int EventId { get; set; }

        [Display(Name = "Mesaj")]
        [Required(ErrorMessage = "Mesaj sahəsi boş ola bilməz.")]
        public string Message { get; set; }

        public IEnumerable<SelectListItem> Events { get; set; } = new List<SelectListItem>();
    }
}
