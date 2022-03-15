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
                    Organizer = organizer
                },
                new Event
                {
                    Title = "GameEvent2", Date = new DateTime(2022, 07, 15), Place = "Göteborg",
                    Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                    Organizer = organizer
                },
                new Event
                {
                    Title = "GameEvent3", Date = new DateTime(2022, 08, 15), Place = "Göteborg",
                    Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                    Organizer = organizer
                },
                new Event
                {
                    Title = "GameEvent4", Date = new DateTime(2022, 09, 15), Place = "Göteborg",
                    Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                    Organizer = organizer
                },
            };
        }

    }
}
