using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Organizer
{
    public class OrganizerVM
    {
        public int Id { get; set; }

        [Display(Name = "Tam Ad")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
