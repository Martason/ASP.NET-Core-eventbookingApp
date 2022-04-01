using Microsoft.AspNetCore.Identity;

namespace EventiaWebapp.Models
{
    public class EventiaUser : IdentityUser
    {
        //public int Id { get; set; }
        //public string Username { get; set; }    
        //public string Password { get; set; }

        //public string Email { get; set; }

        public virtual ICollection<Event> Event { get; set; }

    }
}
