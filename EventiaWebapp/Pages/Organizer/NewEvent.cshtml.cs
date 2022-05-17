using System.ComponentModel.DataAnnotations;
using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Organizer
{
    [Authorize(Roles = "Organizer")]
    public class NewEventModel : PageModel
    {
      
        private readonly UserManager<Models.EventiaUser> _userManager;
        private readonly EventsHandler _eventsHandler;

        public NewEventModel(UserManager<Models.EventiaUser> userManager, EventsHandler eventsHandler)
        {
            _userManager = userManager;
            _eventsHandler = eventsHandler;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public string Title { get; set; }

            public DateTime Date { get; set; }

            public string Place { get; set; }

            public string Adress { get; set; }

            [Display(Name = "Spots available")]
            public int SpotsAvailable { get; set; }

            [Display(Name = "Long description")]
            public string InfoLong { get; set; }

            [Display(Name = "Short description")]
            public string InfoShort { get; set; }
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            var logedInOrganizer = await _userManager.GetUserAsync(User);

            if(await _eventsHandler.NewEvent(
                   logedInOrganizer, 
                   Input.Title,
                   Input.Date, 
                   Input.Place, 
                   Input.Adress,
                   Input.SpotsAvailable,
                   Input.InfoLong,
                   Input.InfoShort))
            {
                return RedirectToPage("./Index");

            }

            return Page();

        }

    }

}
