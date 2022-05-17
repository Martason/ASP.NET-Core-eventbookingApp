using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class AccountChangeConfirmationModel : PageModel
    {

        private readonly UserManager<Models.EventiaUser> _userManager;

        public AccountChangeConfirmationModel(UserManager<Models.EventiaUser> userManager)
        {
            _userManager = userManager;
        }

        public Models.EventiaUser UserTohandle { get; set; }
        
        public async Task OnGet(string userToHandleId)
        {
            UserTohandle = await _userManager.FindByIdAsync(userToHandleId);

        }
    }
}
