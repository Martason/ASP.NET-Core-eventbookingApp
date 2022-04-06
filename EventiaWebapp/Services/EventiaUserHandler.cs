using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class EventiaUserHandler

    {
        private readonly EpicEventsContext _context;
        private readonly UserManager<EventiaUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public EventiaUserHandler(EpicEventsContext context, UserManager<EventiaUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
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
        /// <summary>
        /// Gets a list off all EveniaUsers applying for organizer roles
        /// </summary>
        /// <returns>List of Eventia Users or null</returns>
        public List<EventiaUser> UsersSeekingOrganizerRole()
        {
            var usersSeekingOrganizerRole = _context.Users
                .Where(user => user.SeeksOrganizerRole == true)
                .ToList();

            if (usersSeekingOrganizerRole == null) return null;
            return usersSeekingOrganizerRole;

        }

        /// <summary>
        /// Adds the param UserId to Organizer role
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true if succes</returns>
        public bool ApproveForOrganizerRole(string userId)
        {
            var eventiaUser = _context.Users
                .FirstOrDefault(user => user.Id == userId);

            if (eventiaUser == null) return false;

            //_userManager.RemoveFromRoleAsync(eventiaUser, "User");
            _userManager.AddToRoleAsync(eventiaUser, "Organizer");
            _context.SaveChangesAsync();

            return true;

        }

    }
}
