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

        private IDbContextFactory<EpicEventsContext> factory;
        public List<Event> EventsList { get; set; }

        public EventsHandler(IDbContextFactory<EpicEventsContext> factory)
        {
            this.factory = factory;
        }

        public List<Event> GetEventList()
        {
            using var context = factory.CreateDbContext();
            return context.Events.Include(e => e.Organizer).ToList();
        }

        public Attendee GetAttendee()
        {
            using var context = factory.CreateDbContext();
            return context.Attendees.FirstOrDefault();
        }

        public bool ConfirmBooking(int id)
        {
            using var context = factory.CreateDbContext();

            var query = context.Events.Where(e => e.Id == id).Include(e=>e.Attendees);

            var evt = query.FirstOrDefault();
            if (evt == null) return false;

            var query2 = context.Attendees.Include(a => a.Event);
            var attendee = query2.FirstOrDefault();

            if (attendee == null) return false;
            
            attendee.Event.Add(evt);
            evt.Attendees.Add(attendee);

            context.Update(attendee);

            context.Update(evt);
            context.SaveChanges();

            return true;

            //TODO Query 2 va fan?! :P Veroica och Joakim


        }
    }
}
