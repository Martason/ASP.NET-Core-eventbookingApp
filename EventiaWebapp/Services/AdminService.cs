using System.Diagnostics.Metrics;
using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class AdminService
    {
        private readonly EpicEventsContext _context;
        private readonly UserManager<EventiaUser> _userManager;

        public AdminService(EpicEventsContext context, UserManager<EventiaUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> ChangeOrganizerToUserAccount(string organizerId, EventiaUser admin)
        {
            var organizer = await _context.Users
                .Include(u => u.Application)
                .FirstOrDefaultAsync(user => user.Id == organizerId);

            if (organizer == null) return false;

            await _userManager.RemoveFromRoleAsync(organizer, "Organizer");
            await _userManager.AddToRoleAsync(organizer, "User");

            var accountChange = new AccountChange
            {
                OrganizerChangedToUser = true,
                OrganizerChangedToUserDate = DateTime.Today,
                Admin = admin
            };

            if (organizer.Application == null) return false;


            organizer.Application.Changed = true;
            organizer.Application.AccountChange = accountChange;


            _context.Update(organizer);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
