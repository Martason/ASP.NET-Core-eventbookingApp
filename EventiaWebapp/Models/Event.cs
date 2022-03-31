using System.ComponentModel.DataAnnotations;

namespace EventiaWebapp.Models
{
    public class Event
    {
        public Event()
        {
            Attendees = new HashSet<EventiaUser>();
        }
        //TODO fråga till Björn. 
        /*
         Jag trodde att denna HashSet skulle lösa ett problem i min databas, men visade sig att felet berodde på nått annat. Blev att HashSet fick ligga kvar.
         Hittade den stackOverflow kommenteran nedan och blev lite fundersam huruvida jag bör ha kvar den eller inte? Finns det någon nackdel? Tänker inför nästa uppgift.
        
          Its your navigation property (ICollection<product>) that defines the relationship. The code in the constructor just initializes it so its not null
          HashSet implements a hash table that is very efficient for a lot of operations, for instance searching a large set for a single item.
          HashSet is initialization step of ICollection interface inside model's constructor which guarantees equality between each related model members".
          EF itself doesn't care what implementations should be apply on ICollection for table models, you can use List<T> in constructor replacing HashSet<T>
          and many-to-many relationship still doesn't affected.
         *
          I considered it good practice to use HashSet<> for large amount of data operations.                
         */

        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Adress { get; set; }
        public int SpotsAvalable { get; set; }

        public string InfoLong { get; set; }
        public string InfoShort { get; set; }

        public string? Picture { get; set; }

        [Required]
        public Organizer Organizer { get; set; }
        public ICollection<EventiaUser> Attendees { get; set; }
    }
}
