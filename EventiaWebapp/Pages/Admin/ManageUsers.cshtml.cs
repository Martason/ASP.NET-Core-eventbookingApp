using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class ManageUsersModel : PageModel
    {
        private readonly EventiaUserHandler _userHandler;

        public ManageUsersModel(EventiaUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        public List<Models.EventiaUser> EventiaUsers { get; set; }
        public List<Models.EventiaUser> Organizers { get; set; }
        public List<Models.EventiaUser> Admin { get; set; }
        public List<Models.EventiaUser> AllEventiaUsers { get; set; }
        public async Task OnGet()
        {
            Organizers = await _userHandler.GetOgranizersAndHostedEvents();
            EventiaUsers = await _userHandler.GetEventiaUsersAndJoinedEvents();
            Admin = await _userHandler.GetAdmin();
            AllEventiaUsers = _userHandler.GetAllUsers();
        }

        
    }
}
