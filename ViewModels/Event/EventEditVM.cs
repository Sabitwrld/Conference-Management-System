using Conference_Management_System.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Event
{
    public class EventEditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlıq tələb olunur.")]
        [MaxLength(200)]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Tarix tələb olunur.")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Məkan tələb olunur.")]
        [Display(Name = "Məkan")]
        public int LocationId { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }

        [Required(ErrorMessage = "Tədbir tipi tələb olunur.")]
        [Display(Name = "Tədbir Tipi")]
        public EventTypeEnum EventType { get; set; }

        [Required(ErrorMessage = "Təşkilatçı tələb olunur.")]
        [Display(Name = "Təşkilatçı")]
        public int OrganizerId { get; set; }
        public IEnumerable<SelectListItem> Organizers { get; set; }
    }
}
