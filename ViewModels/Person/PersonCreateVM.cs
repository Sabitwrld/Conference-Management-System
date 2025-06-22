using Conference_Management_System.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Person
{
    public class PersonCreateVM
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad sahəsi boş ola bilməz.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad sahəsi boş ola bilməz.")]
        [MaxLength(100)]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email sahəsi boş ola bilməz.")]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "Düzgün email formatı daxil edin.")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Rol sahəsi boş ola bilməz.")]
        public PersonRoleEnum Role { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
    }
}
