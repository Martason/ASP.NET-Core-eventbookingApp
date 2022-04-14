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


        public EventiaUserHandler(EpicEventsContext context, UserManager<EventiaUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// async function that gets a specefic EventiaUser
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>EventiaUser or null</returns>
        public async Task<EventiaUser> GetEventiaUser(string userId)
        {
            var user =  await _context.Users
                .FirstOrDefaultAsync(user => user.Id == userId);
            if (user == null) return null;
            return user;

        }

        // /// <summary>
        // /// Gets a list off all organizers
        // /// </summary>
        // /// <returns>List of all organizers or null</returns>
        // ///
        // public async Task<List<EventiaUser>> GetOrganizers()
        // {
        //     var organizers = await _userManager.GetUsersInRoleAsync("Organizer");
        //
        //     return organizers == null ? null : organizers.ToList();
        // }

        /// <summary>
        /// Gets a list off all EventiaUsers
        /// </summary>
        /// <returns>List of all Eventia Users or null</returns>
        ///
        public async Task<List<EventiaUser>> GetEventiaUsers()
        {
            var eventiaUsers = await _userManager.GetUsersInRoleAsync("User");

            return eventiaUsers == null ? null : eventiaUsers.ToList();
        }

        /// <summary>
        /// Gets a list off all admin personel
        /// </summary>
        /// <returns>List of all admin personel or null</returns>
        ///
        public async Task<List<EventiaUser>> GetAdmin()
        {
            var admin = await _userManager.GetUsersInRoleAsync("Admin");

            return admin == null ? null : admin.ToList();
        }

        public async Task<List<EventiaUser>> GetEventiaUsersAndJoinedEvents()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");

            foreach (var user in users)
            {
                await _context.Entry(user)
                    .Collection(b => b.JoinedEvents)
                    .LoadAsync();
            }

            return users.ToList();
        }
        /// <summary>
        /// Gets organizer included HostedEvents and organizer application
        /// </summary>
        /// <returns>List of EventiaUsers</returns>
        public async Task<EventiaUser> GetOrganizer(EventiaUser organizer)
        {
            var user = await _context.Users
                .Include(u => u.HostedEvents)
                .Include(u => u.Application)
                .ThenInclude(a=>a.Admin)
                .FirstOrDefaultAsync(u => u.Id == organizer.Id);

            return user;
        }

        /// <summary>
        /// Get users with the organizer role included HostedEvents
        /// </summary>
        /// <returns>List of EventiaUsers</returns>
        public async Task<List<EventiaUser>> GetOrganizer()
        {
            var organizers = await _userManager.GetUsersInRoleAsync("Organizer");

            foreach (var organizer in organizers)
            {
                await _context.Entry(organizer)
                    .Collection(b => b.HostedEvents)
                    .LoadAsync();
            }

            return organizers.ToList();
        }
        /// <summary>
        /// Get a list of all users in the datebase
        /// </summary>
        /// <returns>A list of EventiaUsers</returns>
        //TODO Denna behöver inte vara asynch va?
        public List<EventiaUser> GetAllUsers()
        {
            return _context.Users
                .ToList();
        }


        /// <summary>
        ///     adds an organizerApplication to the eventiaUser
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The created organizer application or null</returns>
        public async Task<bool> OrganizerAccountApplication(EventiaUser user)
        {
            var newApplication = new OrganizerApplication
            {
                Applicant = user,
                ApplicationDate = DateTime.Today,
                Handled = false
            };
            
            await _context.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Gets a list off all EveniaUsers applying for organizer roles
        /// </summary>
        /// <returns>List of Eventia Users or null</returns>
        public List<OrganizerApplication> GetSeeksOrganizers()
        {
            var organizationApplications = _context.OrganizerApplications
                .Where(application => application.Handled == false)
                .Include(application => application.Applicant)
                .ToList();

            if (organizationApplications == null) return null;

            return organizationApplications;

        }

        /// <summary>
        /// Approves an OrganizerApplication request
        /// </summary>
        /// <param name="applicantId"></param>
        /// <param name="admin"></param>
        /// <returns>true if success</returns>
        public async Task<bool> ApproveForOrganizerRole(string applicantId, EventiaUser admin)
        {
            var eventiaUser = _context.Users
               .Include(user=>user.Application)
                .FirstOrDefault(user => user.Id == applicantId);

           if (eventiaUser == null) return false;

           await _userManager.RemoveFromRoleAsync(eventiaUser, "User");
            await _userManager.AddToRoleAsync(eventiaUser, "Organizer");
            eventiaUser.Application.Handled = true;
            eventiaUser.Application.Confirmed = true;
            eventiaUser.Application.ConfirmedDate = DateTime.Today;
            eventiaUser.Application.Admin = admin;

            _context.Update(eventiaUser);
           await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Declines an OrganizerApplication request
        /// </summary>
        /// <param name="applicantId"></param>
        /// <param name="admin"></param>
        /// <returns>true if success</returns>
        public async Task<bool> DeclineForOrganizerRole(string applicantId, EventiaUser admin)
        {
            var eventiaUser = _context.Users
                .Include(user => user.Application)
                .FirstOrDefault(user => user.Id == applicantId);

            if (eventiaUser == null) return false;


            eventiaUser.Application.Handled = true;
            eventiaUser.Application.Declined = true;
            eventiaUser.Application.DeclinedDate = DateTime.Today;
            eventiaUser.Application.Admin = admin;

            _context.Update(eventiaUser);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
