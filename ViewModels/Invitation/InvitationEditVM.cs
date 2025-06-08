using Conference_Management_System.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.Invitation
{
    public class InvitationEditVM
    {
        public int Id { get; set; }
        [Display(Name = "Tədbir")]
        [Required(ErrorMessage = "Tədbir seçilməlidir.")]
        public int EventId { get; set; }

        [Display(Name = "Şəxs")]
        [Required(ErrorMessage = "Şəxs seçilməlidir.")]
        public int PersonId { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status seçilməlidir.")]
        public InvitationStatus Status { get; set; } = InvitationStatus.Pending;
        public IEnumerable<SelectListItem> Events { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Persons { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Statuses { get; set; } = new List<SelectListItem>();
    }
}
