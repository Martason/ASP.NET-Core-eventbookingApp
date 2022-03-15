using EventiaWebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services.Data
{
    public class EpicEventsContext : DbContext
    {
        public EpicEventsContext()
        {
        }

        public EpicEventsContext(DbContextOptions<EpicEventsContext> options) : base(options)
        {
        }


        //För att säga vilka C# klasser som ska tolkas som databastabeller.
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }

        //För att styra anslutningen till databasservern.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=EpicEventDb");
        }

        //För att i detalj beskriva tabellerna och deras förhållanden.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

        }



    }
}
