using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Organizer
{
    public class OrganizerCreateVM
    {
        [Display(Name = "Tam Ad")]
        [Required(ErrorMessage = "Tam ad sahəsi boş ola bilməz.")]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email sahəsi boş ola bilməz.")]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "Düzgün email formatı daxil edin.")]
        public string Email { get; set; }
    }
}
