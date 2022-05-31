using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]

    public class UserAccountChangeModel : PageModel
    {
        private readonly UserManager<Models.EventiaUser> _userManager;
        private readonly EventiaUserHandler _userHandler;
        private readonly AdminService _adminService;

        public UserAccountChangeModel(UserManager<Models.EventiaUser> userManager, AdminService adminService, EventiaUserHandler userHandler)
        {
            _userManager = userManager;
            _adminService = adminService;
            _userHandler = userHandler;
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

        public async Task<RedirectToPageResult> OnPostChangeOrganizerAccount(string userToHandleId)
        {
            var admin = await _userManager.GetUserAsync(User);

           if( await _adminService.ChangeOrganizerToUserAccount(userToHandleId, admin))
           {
               return RedirectToPage("./AccountChangeConfirmation", new{userToHandleId});
           }

           return RedirectToPage("/Pages/Error");



        }
    }
}
