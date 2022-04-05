using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Organizer
{
    [Authorize(Roles = "Organizer")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
