using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;

namespace EventiaWebapp.Services
{
    public class EventsHandler
    {
        // Metod som returnerar en lista på alla events
        // Metod som returnerar en defoult deltagarlista (alltid samma i denna uppgift)
        // En metod som registerar ett givet deltagatobjekt med att givet eventobjekt
        // En metod som returnerar en lista på alla events ett givet deltagar objekt registrerat sig på

        private readonly EpicEventsContext _context;
        public List<Event> EventsList { get; set; }
        public List<Attendee> AttendeesList { get; set; }

        public List<Event> GetEventList()
        {
            return _context.Events.ToList();
        }

        // public async Task<List<Event>> GetEventsAsync()
        // {
        //     var query = _context.Events.Where(e => e.Date > DateTime.UtcNow).ToList();
        //     EventsList = query;
        //
        //     return EventsList;
        // }

        public Attendee GetAttendee()
        {
            return _context.Attendees.FirstOrDefault();
        }

        public bool JoinEvent(Event evt, Attendee attendee)
        {
            return true;
        }

        public List<Event> GetAttendeeForEvent(Attendee attendee)
        {
            var _EventList = EventsList.Where(e
                => (e.Attendees == attendee)).ToList();

            return _EventList;

        }

        public EventsHandler(EpicEventsContext context)
        {
            _context = context;

            var organizer = new Organizer {Name = "Boardgames AB", Email = "info@boardgame.se"};

            EventsList = new List<Event>()
            {
                new Event
                {
                    Title = "Gameing Event1", Date = new DateTime(2022, 06, 15, 18, 30, 00), Place = "Göteborg",
                    Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                    Organizer = organizer,Id=1,
                    InfoLong =
                        "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"
                },
                new Event
                {
                    Title = "Gameing Event2", Date = new DateTime(2022, 07, 15, 17, 30, 00), Place = "Göteborg",
                    Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                    Organizer = organizer,Id=2,
                    InfoLong =
                        "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"

                },
                new Event
                {
                    Title = "Gameing Event3", Date = new DateTime(2022, 08, 15, 20, 30, 00), Place = "Göteborg",
                    Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                    Organizer = organizer, Id=3,
                    InfoLong =
                        "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"

                },
                new Event
                {
                    Title = "Gameing Event4", Date = new DateTime(2022, 09, 15, 15, 30, 00), Place = "Göteborg",
                    Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                    Organizer = organizer, Id=4,
                    InfoLong =
                        "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"

                },
            };
        }

    }
}
