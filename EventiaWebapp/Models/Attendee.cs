namespace EventiaWebapp.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Event> Event { get; set; }

    }
}
