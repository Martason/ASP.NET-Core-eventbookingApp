using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventiaWebapp.Services
{
    public class EventsHandler
    {
        private readonly EpicEventsContext _context;

        public EventsHandler(EpicEventsContext context)
        {
            _context = context;
        }
        public List<Event> GetEventList()
        {
            return _context.Events.Include(e => e.Organizer).Include(e=>e.Attendees).ToList();
        }

        public List<Attendee> GetAttendees()
        {
            return _context.Attendees.Include(a=>a.Event).ThenInclude(e=>e.Organizer).ToList();
        }

        public bool ConfirmBooking(int eventId)
        {
            var query = _context.Events.Where(e => e.Id == eventId).Include(e => e.Attendees);

            var evt = query.FirstOrDefault();
            if (evt == null) return false;

            var query2 = _context.Attendees.Include(a => a.Event);
            var attendee = query2.FirstOrDefault();

            if (attendee == null) return false;

            attendee.Event.Add(evt);
            // Räcker med att uppdatera en. 

            _context.Update(attendee);
            _context.SaveChanges();

            return true;

            //TODO Query 2 va fan?! :P Veroica och Joakim
        }

        public List<Event> GetEventList(int attendeId)
        {

            var query = _context.Attendees
                .Include(a => a.Event);

            if (!query.Any()) return null;

            var attende = query.FirstOrDefault(a => a.Id == attendeId);

            return attende.Event.ToList();
        }

    }
}
