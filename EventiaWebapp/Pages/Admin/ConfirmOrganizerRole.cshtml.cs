using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    public class ConfirmOrganizerRoleModel : PageModel
    {
        [Authorize(Roles = "Admin")]
        public void OnGet()
        {
        }
    }
}
