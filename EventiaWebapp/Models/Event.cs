using System.ComponentModel.DataAnnotations;

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

        [Required]
        public Organizer Organizer { get; set; }
        public ICollection<Attendee> Attendees { get; set; }
    }
}
