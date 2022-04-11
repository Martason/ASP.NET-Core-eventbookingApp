using EventiaWebapp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services.Data
{
    public class EpicEventsContext : IdentityDbContext<EventiaUser>
    {

        public EpicEventsContext(DbContextOptions<EpicEventsContext> options) : base(options)
         {
         }

        public DbSet<Event> Events { get; set; }
        public DbSet<OrganizerApplication> OrganizerApplications { get; set; }

        //DbSet<EventiaUser> Users { get; set; } behövs inte! För det görs redan i IdentityDbContext<EventiaUser> 



    }
}
