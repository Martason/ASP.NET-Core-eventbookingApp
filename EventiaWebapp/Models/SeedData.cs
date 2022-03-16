using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EpicEventsContext(
                       serviceProvider.GetRequiredService<
                       DbContextOptions<EpicEventsContext>>()))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                // // Från msdn
                // if (context.Movie.Any())
                // {
                //     return;   // DB has been seeded
                // }

                var attende = new Attendee()
                {
                    Name = "Märta Hjalmarson",
                    Email = "marta@hotmail.com"
                };

                context.Add(attende);
                context.SaveChanges();

                var organizers = new List<Organizer>
                {
                    new Organizer{Name = "Boardgames AB", Email = "info@boardgame.se"},
                    new Organizer{Name = "GymBeast AB", Email = "info@gymbeast.se"}

                };

                context.AddRange(organizers);
                context.SaveChanges();

                var events = new List<Event>
                {
                    new Event {Title = "Gameing Event1", Date = new DateTime(2022,06,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                        Organizer = organizers[0], Info = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"
                    },
                    new Event {Title = "Gameing Event2", Date = new DateTime(2022,07,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                        Organizer = organizers[0], Info = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"
                    },
                    new Event {Title = "Gameing Event3", Date = new DateTime(2022,08,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                        Organizer = organizers[0],Info = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"
                    },
                    new Event {Title = "Gameing Event4", Date = new DateTime(2022,09,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                        Organizer = organizers[0],Info = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"
                    },
                    new Event {Title = "Gym Event1", Date = new DateTime(2022,04,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 15,
                        Organizer = organizers[1],Info = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"
                    },
                    new Event {Title = "Gym Event2", Date = new DateTime(2022,05,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 15,
                        Organizer = organizers[1],Info = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"
                    },
                    new Event {Title = "Gym Event2", Date = new DateTime(2022,06,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 15,
                        Organizer = organizers[1],Info = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful"
                    },

                };

                context.AddRange(events);
                context.SaveChanges();



            }

        }
    }
}
