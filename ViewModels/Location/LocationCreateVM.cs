using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Location
{
    public class LocationCreateVM
    {
        [Display(Name = "Məkan Adı")]
        [Required(ErrorMessage = "Məkan adı boş ola bilməz.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Ünvan")]
        [Required(ErrorMessage = "Ünvan sahəsi boş ola bilməz.")]
        [MaxLength(250)]
        public string Address { get; set; }

        [Display(Name = "Tutum")]
        [Required(ErrorMessage = "Tutum sahəsi boş ola bilməz.")]
        [Range(1, int.MaxValue, ErrorMessage = "Tutum ən az 1 olmalıdır.")]
        public int Capacity { get; set; }
    }
}
