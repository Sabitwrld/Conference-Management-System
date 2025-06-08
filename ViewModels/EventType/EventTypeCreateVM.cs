using Conference_Management_System.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.EventType
{
    public class EventTypeCreateVM
    {
        [Display(Name = "Tədbir Növü Adı")]
        [Required(ErrorMessage = "Tədbir növü adı boş ola bilməz.")]
        public EventTypeEnum Name { get; set; }
        public IEnumerable<SelectListItem> AvailableEventTypes { get; set; } = new List<SelectListItem>();
    }
}
