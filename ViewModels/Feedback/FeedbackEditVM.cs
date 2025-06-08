using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Feedback
{
    public class FeedbackEditVM
    {
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }

        [Required]
        public int PersonId { get; set; }

        [Display(Name = "Reytinq (1-5)")]
        [Required(ErrorMessage = "Reytinq sahəsi boş ola bilməz.")]
        [Range(1, 5, ErrorMessage = "Reytinq 1 ilə 5 arasında olmalıdır.")]
        public int Rating { get; set; }

        [Display(Name = "Rəy")]
        [MaxLength(1000, ErrorMessage = "Rəy 1000 simvoldan çox ola bilməz.")]
        public string Comment { get; set; }

        public IEnumerable<SelectListItem> Events { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Persons { get; set; } = new List<SelectListItem>();
    }
}
