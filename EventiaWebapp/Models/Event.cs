using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventiaWebapp.Models
{
    public class Event
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Adress { get; set; }
        public int SpotsAvalable { get; set; }

        public string InfoLong { get; set; }
        public string InfoShort { get; set; }

        public string? Picture { get; set; }

        [InverseProperty("HostedEvents")]
        public EventiaUser Organizer { get; set; }

        [InverseProperty("JoinedEvents")]
        public ICollection<EventiaUser>? Attendees { get; set; }
    }
}
