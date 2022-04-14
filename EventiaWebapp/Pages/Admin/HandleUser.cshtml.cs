using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class HandleUserModel : PageModel
    {
        private readonly EventiaUserHandler _userHandler;
        private readonly UserManager<Models.EventiaUser> _userManager;

        public HandleUserModel(EventiaUserHandler userHandler, UserManager<Models.EventiaUser> userManager)
        {
            _userHandler = userHandler;
            _userManager = userManager;
        }

        public Models.EventiaUser UserToHandle { get; set; }
        public string UserToHandleRole { get; set; } 
        public async Task OnGet(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var getRoles = await _userManager.GetRolesAsync(user);
            UserToHandleRole = getRoles[0];

            if (UserToHandleRole == "Organizer")
            {
                UserToHandle = await _userHandler.GetOrganizer(user);
            }
        }
        public async Task<IActionResult> OnPostUserAccountChange(string userId)
        {
            return RedirectToPage("./UserAccountChange", new{userId});
        }

    }
}
