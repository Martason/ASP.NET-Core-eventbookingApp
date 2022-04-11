using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace EventiaWebapp.Models
{
    public class OrganizerApplication
    {
        public int Id { get; set; }

        public bool Confirmed { get; set; }
        public bool Declined { get; set; }

        public bool Handled { get; set; }
        public DateTime ConfirmedDate { get; set; }
        public DateTime DeclinedDate { get; set; }
        public DateTime ApplicationDate { get; set; }

        [InverseProperty("HandledApplications")]
        public EventiaUser Admin { get; set; }

        public string ApplicantId { get; set; }

        [InverseProperty("Application")]
        public EventiaUser Applicant { get; set; }
    }
}
