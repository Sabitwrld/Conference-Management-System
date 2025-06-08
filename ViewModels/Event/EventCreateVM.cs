using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Event
{
    public class EventCreateVM
    {
        [Display(Name = "Başlıq")]
        [Required(ErrorMessage = "Başlıq sahəsi boş ola bilməz.")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Display(Name = "Təsvir")]
        public string Description { get; set; }

        [Display(Name = "Tarix")]
        [Required(ErrorMessage = "Tarix sahəsi boş ola bilməz.")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Display(Name = "Məkan")]
        [Required(ErrorMessage = "Məkan seçilməlidir.")]
        public int LocationId { get; set; }

        [Display(Name = "Tədbir Növü")]
        [Required(ErrorMessage = "Tədbir növü seçilməlidir.")]
        public int EventTypeId { get; set; }

        [Display(Name = "Təşkilatçı")]
        [Required(ErrorMessage = "Təşkilatçı seçilməlidir.")]
        public int OrganizerId { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Organizers { get; set; } = new List<SelectListItem>();
    }
}

