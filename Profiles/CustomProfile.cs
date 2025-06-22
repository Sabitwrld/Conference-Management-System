using AutoMapper;
using Conference_Management_System.Models;
using Conference_Management_System.ViewModels.Event;
using Conference_Management_System.ViewModels.Feedback;
using Conference_Management_System.ViewModels.Invitation;
using Conference_Management_System.ViewModels.Location;
using Conference_Management_System.ViewModels.Notification;
using Conference_Management_System.ViewModels.Organizer;
using Conference_Management_System.ViewModels.Participation;
using Conference_Management_System.ViewModels.Person;

namespace Conference_Management_System.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile() 
        {
            CreateMap<Person, PersonVM>().ReverseMap();
            CreateMap<Person, PersonCreateVM>().ReverseMap();
            CreateMap<Person, PersonEditVM>().ReverseMap();
            CreateMap<PersonVM, PersonCreateVM>().ReverseMap();
            CreateMap<PersonVM, PersonEditVM>().ReverseMap();

            CreateMap<Event, EventVM>().ReverseMap();
            CreateMap<Event, EventCreateVM>().ReverseMap();
            CreateMap<Event, EventEditVM>().ReverseMap();
            CreateMap<EventVM, EventCreateVM>().ReverseMap();
            CreateMap<EventVM, EventEditVM>().ReverseMap();
            
            CreateMap<Invitation, InvitationVM>().ReverseMap();
            CreateMap<Invitation, InvitationCreateVM>().ReverseMap();
            CreateMap<Invitation, InvitationEditVM>().ReverseMap();
            CreateMap<InvitationVM, InvitationCreateVM>().ReverseMap();
            CreateMap<InvitationVM, InvitationEditVM>().ReverseMap();            
            
            CreateMap<Participation, ParticipationVM>().ReverseMap();
            CreateMap<Participation, ParticipationCreateVM>().ReverseMap();
            CreateMap<Participation, ParticipationEditVM>().ReverseMap();
            CreateMap<ParticipationVM, ParticipationCreateVM>().ReverseMap();
            CreateMap<ParticipationVM, ParticipationEditVM>().ReverseMap(); 
            
            CreateMap<Location, LocationVM>().ReverseMap();
            CreateMap<Location, LocationCreateVM>().ReverseMap();
            CreateMap<Location, LocationEditVM>().ReverseMap();
            CreateMap<LocationVM, LocationCreateVM>().ReverseMap();
            CreateMap<LocationVM, LocationEditVM>().ReverseMap(); 
            
            CreateMap<Organizer, OrganizerVM>().ReverseMap();
            CreateMap<Organizer, OrganizerCreateVM>().ReverseMap();
            CreateMap<Organizer, OrganizerEditVM>().ReverseMap();
            CreateMap<OrganizerVM, OrganizerCreateVM>().ReverseMap();
            CreateMap<OrganizerVM, OrganizerEditVM>().ReverseMap();
            
            CreateMap<Notification, NotificationVM>().ReverseMap();
            CreateMap<Notification, NotificationCreateVM>().ReverseMap();
            CreateMap<Notification, NotificationEditVM>().ReverseMap();
            CreateMap<NotificationVM, NotificationCreateVM>().ReverseMap();
            CreateMap<NotificationVM, NotificationEditVM>().ReverseMap(); 
            
            CreateMap<Feedback, FeedbackVM>().ReverseMap();
            CreateMap<Feedback, FeedbackCreateVM>().ReverseMap();
            CreateMap<Feedback, FeedbackEditVM>().ReverseMap();
            CreateMap<FeedbackVM, FeedbackCreateVM>().ReverseMap();
            CreateMap<FeedbackVM, FeedbackEditVM>().ReverseMap();

        }


        
    
    }
}
