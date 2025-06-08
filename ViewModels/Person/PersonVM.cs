using Conference_Management_System.Enums;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Person
{
    public class PersonVM
    {
        public int Id { get; set; }

        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Rol")]
        public PersonRole Role { get; set; }

        [Display(Name = "Rol Adı")]
        public string RoleName => Role.ToString();
    }
}
