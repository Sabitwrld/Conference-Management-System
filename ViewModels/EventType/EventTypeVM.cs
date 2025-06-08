using Conference_Management_System.Enums;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.ViewModels.EventType
{
    public class EventTypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Tədbir Növü Adı")]
        public EventTypeEnum Name { get; set; }

        [Display(Name = "Növ Adı")]
        public string NameString => Name.ToString();
    }
}
