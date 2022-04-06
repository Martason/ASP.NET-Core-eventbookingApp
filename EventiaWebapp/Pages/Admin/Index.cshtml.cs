using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly EventiaUserHandler _userHandler;

        public IndexModel(EventiaUserHandler userHandler)
        {
            _userHandler = userHandler;
        }
        public List<EventiaUser> UsersSeekingOrganizerRole { get; set; }
        public void OnGet()
        {
            UsersSeekingOrganizerRole = _userHandler.UsersSeekingOrganizerRole();
        }
    }
}
