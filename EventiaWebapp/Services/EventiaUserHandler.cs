using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class EventiaUserHandler

    {
        private readonly EpicEventsContext _context;

        public EventiaUserHandler(EpicEventsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Sets propperty SeeksOrganizerRole to true 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>bool true if database change is a success, false if not</returns>
        public bool OrganizerAccountApplication(string userId)
        {
            var eventiaUser = _context.Users
                .FirstOrDefault(user => user.Id == userId);

            if (eventiaUser == null) return false;

            eventiaUser.SeeksOrganizerRole = true;

            _context.Update(eventiaUser);
            _context.SaveChanges();
            return true;

            //TODO använd usermanager istället för context
        }

        public List<EventiaUser> UsersSeekingOrganizerRole()
        {
            var usersSeekingOrganizerRole = _context.Users
                .Where(user => user.SeeksOrganizerRole == true)
                .ToList();

            if (usersSeekingOrganizerRole == null) return null;
            return usersSeekingOrganizerRole;

        }
    }
}
