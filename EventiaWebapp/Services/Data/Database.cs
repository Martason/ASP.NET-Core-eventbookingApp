using EventiaWebapp.Models;

namespace EventiaWebapp.Services.Data
{
    public class Database
    {
        public void CreateAndSeedDb()
        {
            using (var ctx = new EpicEventsContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var attende = new Attendee()
                {
                    Name = "Märta Hjalmarson",
                    Email = "marta@hotmail.com"
                };

                ctx.Add(attende);
                ctx.SaveChanges();

                var organizers = new List<Organizer>
                {
                    new Organizer{Name = "Boardgames AB", Email = "info@boardgame.se"},
                    new Organizer{Name = "GymBeast AB", Email = "info@gymbeast.se"}

                };

                ctx.AddRange(organizers);
                ctx.SaveChanges();

                var events = new List<Event>
                {
                    new Event {Title = "GameEvent1", Date = new DateTime(2022,06,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6, 
                        Organizer = organizers[0]},
                    new Event {Title = "GameEvent2", Date = new DateTime(2022,07,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                        Organizer = organizers[0]},
                    new Event {Title = "GameEvent3", Date = new DateTime(2022,08,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                        Organizer = organizers[0]},
                    new Event {Title = "GameEvent4", Date = new DateTime(2022,09,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 6,
                        Organizer = organizers[0]},
                    new Event {Title = "GymEvent1", Date = new DateTime(2022,04,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 15,
                        Organizer = organizers[1]},
                    new Event {Title = "GymEvent2", Date = new DateTime(2022,05,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 15,
                        Organizer = organizers[1]},
                    new Event {Title = "GymEvent2", Date = new DateTime(2022,06,15), Place = "Göteborg", Adress = "Föreningsgatan 14, 411 28 Göteborg", SpotsAvalable = 15,
                        Organizer = organizers[1]}

                };

                ctx.AddRange(events);
                ctx.SaveChanges();

               
            }
        }
    }
}

