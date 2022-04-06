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

 
        /// <summary>
        /// Gets the joined events for a specified EventiaUser from the database
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of Joined Events including orginizers for that user</returns>
        public List<Event> GetEventList(string userId)
        { 
            var attendee = _context.Users
                .Include(u=>u.JoinedEvents)
                .ThenInclude(e=>e.Organizer)
                .FirstOrDefault(user => user.Id == userId);

           if (attendee == null) return null;

            return attendee.JoinedEvents.ToList();

        }
        /// <summary>
        /// Gets a specified EventiaUser from the database
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>EventiaUser including events</returns>
        public async Task<EventiaUser> GetUserAsynch(string userId)
        {
            var attende = await _context.Users
                .Include(u => u.JoinedEvents)
                .ThenInclude(u => u.Organizer)
                .FirstOrDefaultAsync(user => user.Id == userId);

            return attende;
        }



        public List<EventiaUser> GetAttendees()
        {
            return null; // _context.Users.Include(a=>a.Event).ThenInclude(e=>e.Organizer).ToList();
        }

        public EventiaUser getAttende(string userId)
        {
            var attende = _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.JoinedEvents);
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
