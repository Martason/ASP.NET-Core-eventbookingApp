using EventiaWebapp.Models;

namespace EventiaWebapp.Services
{
    public class EventsHandler
    {

        public List<Event> EventsList { get; init; }

        public List<Attendee> AttendeesList { get; set; }


        // Metod som returnerar en lista på alla events
        public List<Event> GetEvents()
        {
            return EventsList;
        }

        // Metod som returnerar en defoult deltagarlista (alltid samma i denna uppgift)
        public List<Attendee> GetAttendees()
        {
            return AttendeesList;
        }

        // En metod som registerar ett givet deltagatobjekt med att givet eventobjekt
        public bool JoinEvent(Event evt, Attendee attendee)
        {
            return true;
        }

        // En metod som returnerar en lista på alla events ett givet deltagar objekt registrerat sig på
        public List<Event> GetAttendeeForEvent(Attendee attendee)
        {
            var _EventList = EventsList.Where(e
                => (e.Attendees == attendee)).ToList();

            return _EventList;

        }

        public EventsHandler()
        {
            var organizer = new Organizer {Name = "Boardgames AB", Email = "info@boardgame.se"};

            EventsList = new List<Event>()
            {
                new Event
                {
                    Title = "GameEvent1", Date = new DateTime(2022, 06, 15), Place = "Göteborg",
                    Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                    Organizer = organizer, Info = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"
                },
                new Event
                {
                    Title = "GameEvent2", Date = new DateTime(2022, 07, 15), Place = "Göteborg",
                    Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                    Organizer = organizer, Info = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"

                },
                new Event
                {
                    Title = "GameEvent3", Date = new DateTime(2022, 08, 15), Place = "Göteborg",
                    Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                    Organizer = organizer, Info = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"

                },
                new Event
                {
                    Title = "GameEvent4", Date = new DateTime(2022, 09, 15), Place = "Göteborg",
                    Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                    Organizer = organizer, Info = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"

                },
            };
        }

    }
}
