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

        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<EventiaUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<EventiaUser>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
            });
        }

    }
}
