using Microsoft.AspNetCore.Identity;

namespace EventiaWebapp.Models
{
    public class EventiaUser : IdentityUser
    {
      
        public string? OrganizerName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        
        public OrganizerApplication? Application { get; set; }
        public virtual ICollection<OrganizerApplication>? HandledApplications { get; set; }
        public virtual ICollection<Event> JoinedEvents { get; set; }
        public virtual ICollection<Event> HostedEvents { get; set; }


    }
}
