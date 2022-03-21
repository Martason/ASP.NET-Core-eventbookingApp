using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class DatabaseHandler
    {
        /*
        IDbContextFactory<TContext> Interface
        
        A factory for creating derived DbContext instances. Implement this interface to enable
        design-time services for context types that do not have a public default constructor.
        At design-time, derived DbContext instances can be created in order to enable specific 
        design-time experiences such as model rendering, DDL generation etc. 
        
        To enable design-time instantiation for derived DbContext types that do not have a public, 
        default constructor, implement this interface. Design-time services will auto-discover implementations 
        of this interface that are in the same assembly as the derived DbContext type.*/

        private readonly IDbContextFactory<EpicEventsContext> _factory;

            public DatabaseHandler(IDbContextFactory<EpicEventsContext> factory)
            {
                _factory = factory;
            }

            public async Task SeedTestData()
            {
                await using var context = await _factory.CreateDbContextAsync();

                var attendes = new List<Attendee>
                {
                    new Attendee {Name = "Märta Hjalmarson", Email = "marta@hotmail.com"},
                    new Attendee {Name = "Pia Hagman", Email = "pia@hotmail.com"}
                };

                var organizers = new List<Organizer>
                {
                    new Organizer {Name = "Boardgames AB", Email = "info@boardgame.se"},
                    new Organizer {Name = "GymBeast AB", Email = "info@gymbeast.se"},
                    new Organizer {Name = "Wine Explorer AB", Email = "info@wineexplorer.se"}
                };

                var events = new List<Event>
                {
                    new Event
                    {
                        Title = "Eclipse Event",
                        Date = new DateTime(2022, 06, 15, 18, 30, 00),
                        Place = "Göteborg",
                        Adress = "Föreningsgatan 14, 411 28 Göteborg",
                        SpotsAvalable = 6,
                        Organizer = organizers[0],
                        InfoLong =
                            "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness.",
                        InfoShort =
                            "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old."
                    },
                    new Event
                    {
                        Title = "Small World Event",
                        Date = new DateTime(2022, 07, 15, 18, 30, 00),
                        Place = "Göteborg",
                        Adress = "Föreningsgatan 14, 411 28 Göteborg",
                        SpotsAvalable = 6,
                        Organizer = organizers[0],
                        InfoLong =
                            "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. ",
                        InfoShort =
                            "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old."
                    },
                    new Event
                    {
                        Title = "Terraforming Mars",
                        Date = new DateTime(2022, 08, 15, 18, 30, 00),
                        Place = "Göteborg",
                        Adress = "Föreningsgatan 14, 411 28 Göteborg",
                        SpotsAvalable = 6,
                        Organizer = organizers[0],
                        InfoLong =
                            "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness.",
                        InfoShort =
                            "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old."
                    },
                    new Event
                    {
                        Title = "Gym challange",
                        Date = new DateTime(2022, 09, 15, 18, 30, 00),
                        Place = "Göteborg",
                        Adress = "Föreningsgatan 14, 411 28 Göteborg",
                        SpotsAvalable = 6,
                        Organizer = organizers[1],
                        InfoLong =
                            "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. ",
                        InfoShort =
                            "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old"
                    },
                    new Event
                    {
                        Title = "Bodypump",
                        Date = new DateTime(2022, 04, 15, 18, 30, 00),
                        Place = "Göteborg",
                        Adress = "Föreningsgatan 14, 411 28 Göteborg",
                        SpotsAvalable = 15,
                        Organizer = organizers[1],
                        InfoLong =
                            "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness.",
                        InfoShort =
                            "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. "
                    },
                    new Event
                    {
                        Title = "Göteborgsvarvet",
                        Date = new DateTime(2022, 05, 15, 18, 30, 00),
                        Place = "Göteborg",
                        Adress = "Föreningsgatan 14, 411 28 Göteborg",
                        SpotsAvalable = 15,
                        Organizer = organizers[1],
                        InfoLong =
                            "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness.",
                        InfoShort =
                            "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. "
                    },
                    new Event
                    {
                        Title = "Riesling tasting",
                        Date = new DateTime(2022, 06, 15, 18, 30, 00),
                        Place = "Göteborg",
                        Adress = "Föreningsgatan 14, 411 28 Göteborg",
                        SpotsAvalable = 15,
                        Organizer = organizers[2],
                        InfoLong =
                            "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness.",
                        InfoShort =
                            "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old."
                    },
                    new Event
                    {
                        Title = "Cabernet Souvigion tasting",
                        Date = new DateTime(2022, 06, 15, 18, 30, 00),
                        Place = "Göteborg",
                        Adress = "Föreningsgatan 14, 411 28 Göteborg",
                        SpotsAvalable = 15,
                        Organizer = organizers[2],
                        InfoLong =
                            "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness.",
                        InfoShort =
                            "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old."
                    },
                    new Event
                    {
                        Title = "Zinfandel tasting",
                        Date = new DateTime(2022, 06, 15, 18, 30, 00),
                        Place = "Göteborg",
                        Adress = "Föreningsgatan 14, 411 28 Göteborg",
                        SpotsAvalable = 15,
                        Organizer = organizers[2],
                        InfoLong =
                            "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness.",
                        InfoShort =
                            "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old."
                    },
                };
                await context.AddRangeAsync(attendes);
                await context.AddRangeAsync(organizers);
                await context.AddRangeAsync(events);

                await context.SaveChangesAsync();
            }

            public async Task Recreate()
            {
                await using var context = await _factory.CreateDbContextAsync();
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();
            }

            public async Task RecreateAndSeed()
            {
                await Recreate();
                await SeedTestData();
            }
        //TODO fråga Björn om await även på using statemaent?
        /*
         * When the lifetime of an IDisposable object is limited to a single method,
         * you should declare and instantiate it in the using statement or using
         * declaration. The using declaration calls the Dispose method on the object
         * in the correct way when it goes out of scope. The using statement causes
         * the object itself to go out of scope as soon as Dispose is called.
         *
         * Within the using block, the object is read-only and can't be modified or
         * reassigned. A variable declared with a using declaration is read-only.
         * If the object implements IAsyncDisposable instead of IDisposable,
         * either using form calls the DisposeAsync and awaits the returned ValueTask.
         */
        public async Task CreateIfNotExist()
            {
            using var context = await _factory.CreateDbContextAsync();
            await context.Database.EnsureCreatedAsync();
            }

            public async Task CreateAndSeedTestDataIfNotExist()
            {
                using var context = await _factory.CreateDbContextAsync();
                var didCreateDatabase = await context.Database.EnsureCreatedAsync();
                if (didCreateDatabase)
                {
                    await SeedTestData();
                }


        }
    }
    
}
