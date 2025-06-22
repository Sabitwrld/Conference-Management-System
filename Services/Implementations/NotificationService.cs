using AutoMapper;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;
using Conference_Management_System.Services.Interfaces;
using Conference_Management_System.ViewModels.Notification;

namespace Conference_Management_System.Services.Implementations
{
    public class NotificationService : GenericService<NotificationVM, Notification>, INotificationService
    {
        public NotificationService(IGenericRepository<Notification> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
