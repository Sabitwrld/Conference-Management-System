using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Location
{
    public class LocationVM
    {
        public int Id { get; set; }

        [Display(Name = "Məkan Adı")]
        public string Name { get; set; }

        [Display(Name = "Ünvan")]
        public string Address { get; set; }

        [Display(Name = "Tutum")]
        public int Capacity { get; set; }
    }
}
