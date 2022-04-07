using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;

namespace EventiaWebapp.Pages.Organizer
{
    [Authorize(Roles = "Organizer")]
    public class NewEventModel : PageModel
    {

        private readonly UserManager<EventiaUser> _userManager;
        private readonly EventsHandler _eventsHandler;

        public NewEventModel(UserManager<EventiaUser> userManager, EventsHandler eventsHandler)
        {
            _userManager = userManager;
            _eventsHandler = eventsHandler;
        }

        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            public string Title { get; set; }
            [Required]
            public DateTime Date { get; set; }
            [Required]
            public string Place { get; set; }
            [Required]
            public string Adress { get; set; }
            [Required]
            public int SpotsAvailable { get; set; }
         
            public string InfoLong { get; set; }
       
            public string InfoShort { get; set; }
        }
        
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var LogedInOrganizer = await _userManager.GetUserAsync(User);

                if(await _eventsHandler.NewEvent(
                       LogedInOrganizer, 
                       Input.Title,
                       Input.Date, 
                       Input.Place, 
                       Input.Adress,
                       Input.SpotsAvailable,
                       Input.InfoLong,
                       Input.InfoShort)
                   )
                {
                    return RedirectToPage("./Index");

                }
                
            } 
            
            return Page();

        }


    }
}
