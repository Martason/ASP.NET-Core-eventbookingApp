using System.ComponentModel.DataAnnotations.Schema;

namespace EventiaWebapp.Models
{
    public class AccountChange
    {
        public int Id { get; set; }
        public bool OrganizerChangedToUser { get; set; }
        public DateTime OrganizerChangedToUserDate { get; set; }


        [InverseProperty("HandledAccountChange")]
        public EventiaUser? Admin { get; set; }

        [InverseProperty("AccountChange")]
        public int OrganizerApplicationId { get; set; }
        public OrganizerApplication? OrganizerApplication { get; set; }
        


    }
}
