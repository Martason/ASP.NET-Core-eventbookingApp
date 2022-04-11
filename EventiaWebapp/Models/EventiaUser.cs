using Microsoft.AspNetCore.Identity;

namespace EventiaWebapp.Models
{
    public class EventiaUser : IdentityUser
    {
      
        public string? OrganizerName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //public bool? SeeksOrganizerRole { get; set; }

        public OrganizerApplication? Application { get; set; }
        public virtual ICollection<OrganizerApplication>? HandledApplications { get; set; }
        public virtual ICollection<Event> JoinedEvents { get; set; }
        public virtual ICollection<Event> HostedEvents { get; set; }


        //Roll har mer med rättigheter att göra. 
        //Bool blir lite fattigt som lösning eftersom de bara ger två värden. 
        //Claim based autherization
        //Extra tabell bara för applications 
    }
}
