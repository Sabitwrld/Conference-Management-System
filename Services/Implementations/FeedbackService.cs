using AutoMapper;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;
using Conference_Management_System.Services.Interfaces;
using Conference_Management_System.ViewModels.Feedback;

namespace Conference_Management_System.Services.Implementations
{
    public class FeedbackService : GenericService<FeedbackVM, Feedback>, IFeedbackService
    {
        public FeedbackService(IGenericRepository<Feedback> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
