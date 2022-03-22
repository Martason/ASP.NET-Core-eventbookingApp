using System.ComponentModel.DataAnnotations;

namespace EventiaWebapp.Models
{
    public class Event
    {
        public Event()
        {
            Attendees = new HashSet<Attendee>();
        }
        /*
          Its your navigation property (ICollection<product>) that defines the relationship. TODO The code in the constructor just initializes it so its not null
         *
          HashSet implements a hash table that is very efficient for a lot of operations, for instance searching a large set for a single item.
         *
          HashSet is initialization step of ICollection interface inside model's constructor which guarantees equality between each related model members".
          EF itself doesn't care what implementations should be apply on ICollection for table models, you can use List<T> in constructor replacing HashSet<T>
          and many-to-many relationship still doesn't affected.
         *
          I considered it good practice to use HashSet<> for large amount of data operations.
         *
            - IEnumerable<T> is read-only
            - You can add and remove items to an ICollection<T>
            - You can do random access (by index) to a List<T>

            Out of those, ICollection and IEnumerable map well to database operations, since querying and adding/removing entities are things you might do in a DB.
            Random access by index doesn't map as well, since you'd have to have an existing query result to iterate over, or each random access would query the
            database again. Also, what would the index map to? Row number? There aren't a lot of row number queries you'd want to do, and it isn't useful at all
            in building up bigger queries. So they simply don't support it. ICollection<T> is supported, and will allow you to both query and change data, so use that.

            The reason List<T> works to begin with is because the EF implementation ends up returning one in the end. But that's at the end of your query chain, 
            not at the beginning. So making your properties ICollection<T> will make it more obvious that the EF creates a bunch of SQL and only returns a List<T> at 
            the end, rather than doing queries for each level of Linq that you use.
        *
         */

        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Adress { get; set; }
        public int SpotsAvalable { get; set; }

        public string InfoLong { get; set; }
        public string InfoShort { get; set; }

        public string Picture { get; set; }

        [Required]
        public Organizer Organizer { get; set; }
        public ICollection<Attendee> Attendees { get; set; }
    }
}
