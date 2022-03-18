using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class EventsHandler
    {
        // Metod som returnerar en lista på alla events
        // Metod som returnerar en defoult deltagarlista (alltid samma i denna uppgift)
        // En metod som registerar ett givet deltagatobjekt med att givet eventobjekt
        //join
       /*
        *
        */
        // En metod som returnerar en lista på alla events ett givet deltagar objekt registrerat sig på

        private readonly EpicEventsContext _context;
        public List<Event> EventsList { get; set; }
    
        public EventsHandler(EpicEventsContext context)
        {
            _context = context;
        }

        public List<Event> GetEventList()
        {
            return _context.Events.Include(e=>e.Organizer).ToList();
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

    

        public List<Event> GetAttendeeForEvent(Attendee attendee)
        {
            var _EventList = EventsList.Where(e
                => (e.Attendees == attendee)).ToList();

            return _EventList;

        }

    

    }
}
