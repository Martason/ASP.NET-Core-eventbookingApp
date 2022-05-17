using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class EventsHandler
    {
        private readonly EpicEventsContext _context;

        public EventsHandler(EpicEventsContext context)
        {
            _context = context;
        }

        public async Task<Event> GetEvent(int eventId)
        {
            var evt = await _context.Events
                .Include(e=>e.Organizer)
                .FirstOrDefaultAsync(e => e.Id == eventId);
            return evt ?? null;
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

        public bool CancelBooking(int eventId, string userId)
        {
            var query = _context.Events
                .Where(e => e.Id == eventId)
                .Include(e => e.Attendees);

            var evt = query.FirstOrDefault();

            if (evt == null) return false;

            var attendee = getAttende(userId);
            if (attendee == null) return false;

            evt.Attendees.Remove(attendee);

            _context.Update(evt);
            _context.SaveChanges();

            return true;

        }
        public async Task<bool> NewEvent(
            EventiaUser organizer,
            string title,
            DateTime date,
            string place,
            string adress,
            int spotsAvalale,
            string infoLong,
            string infoShort)
        {
            var newEvent = new Event
            {
                Title = title,
                Date = date,
                Place = place,
                Adress = adress,
                SpotsAvalable = spotsAvalale,
                InfoLong = infoLong,
                InfoShort = infoShort,
                Organizer = organizer
            };

            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
