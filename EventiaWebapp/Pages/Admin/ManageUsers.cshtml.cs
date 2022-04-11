using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    public class ManageUsersModel : PageModel
    {
        private readonly EventiaUserHandler _userHandler;

        public ManageUsersModel(EventiaUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        public List<EventiaUser> EventiaUsers { get; set; }
        public List<EventiaUser> Organizers { get; set; }
        public List<EventiaUser> Admin { get; set; }

        public List<EventiaUser> AllEventiaUsers { get; set; }
        public async Task OnGet()
        {
            Organizers = await _userHandler.GetOrganizers();
            EventiaUsers = await _userHandler.GetEventiaUsers();
            Admin = await _userHandler.GetAdmin();
            AllEventiaUsers = _userHandler.GetAllUsers();
        }
    }
}
