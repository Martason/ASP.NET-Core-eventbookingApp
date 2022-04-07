using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class ConfirmOrganizerRoleModel : PageModel
    {
       
        private readonly EventiaUserHandler _userHandler;

        public ConfirmOrganizerRoleModel(EventiaUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        public EventiaUser EventiaUser { get; set; }
      
        public async Task OnGet(string userId)
        {
            EventiaUser = await _userHandler.GetEventiaUser(userId);
        }
    }
}
