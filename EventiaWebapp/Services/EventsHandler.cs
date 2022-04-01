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
        public List<Event> GetEventList(string userId)
        {
            var attende = _context.Users
                .Where(a=>a.Id == userId)
                .Include(a => a.Event)
                .FirstOrDefault();

            return attende.Event.ToList();
        }
        public List<EventiaUser> GetAttendees()
        {
            return _context.Users.Include(a=>a.Event).ThenInclude(e=>e.Organizer).ToList();
        }

        public EventiaUser getAttende(string userId)
        {
            var attende = _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Event);
            return attende.FirstOrDefault();
        }

        public bool ConfirmBooking(int eventId, string userId)
        {
            var query = _context.Events
                .Where(e => e.Id == eventId)
                .Include(e => e.Attendees);

            var evt = query.FirstOrDefault();
            if (evt == null) return false;

            var attendee = getAttende(userId);
            if (attendee == null) return false;

            evt.Attendees.Add(attendee);
            // Räcker med att uppdatera en. 

            _context.Update(evt);
            _context.SaveChanges();

            return true;

        }

    

    }
}
