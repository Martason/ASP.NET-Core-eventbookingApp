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

            else if (UserToHandleRole == "User")
            {
                UserToHandle = await _userHandler.GetEventiaUser(user);
            }
        }
        //Inte anv�nda POST h�r? Update och Delete? Eller Nej pga vi anv�nder ingen API h�r? 
        //Bond property, g�r att jag kan skriva �ver och skicka med till n�sta
        public async Task<IActionResult> OnPostUserAccountChange(string userId)
        {
            return RedirectToPage("./UserAccountChange", new{userId});
        }
        public async Task<IActionResult> OnPostDeleteUser(string userId)
        {
            return RedirectToPage("./DeleteUser", new { userId });
        }
        

    }
}
