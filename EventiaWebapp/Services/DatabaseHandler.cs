using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;

namespace EventiaWebapp.Services;

public class DatabaseHandler
{
    private readonly EpicEventsContext _context;

    public DatabaseHandler(EpicEventsContext context)
    {
        _context = context;
    }

    public async Task SeedTestData()
    {
        var attendes = new List<Attendee>
        {
            new() {Name = "Märta Hjalmarson", Email = "marta@hotmail.com"},
            new() {Name = "Pia Hagman", Email = "pia@hotmail.com"}
        };

        var organizers = new List<Organizer>
        {
            new() {Name = "Boardgames AB", Email = "info@boardgame.se"},
            new() {Name = "GymBeast AB", Email = "info@gymbeast.se"},
            new() {Name = "Wine Explorer AB", Email = "info@wineexplorer.se"}
        };

        var events = new List<Event>
        {
            new()
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
                    "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                Picture = "https://localhost:7086//images/gameControllerS.jpg"
            },
            new()
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
                    "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                Picture = "https://localhost:7086//images/gameControllerS.jpg"
            },
            new()
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
                    "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                Picture = "https://localhost:7086//images/gameControllerS.jpg"
            },
            new()
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
                    "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old",
                Picture = "https://localhost:7086//images/gymPicture.jpg"
            },
            new()
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
                    "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. ",
                Picture = "https://localhost:7086//images/gymPicture.jpg"
            },
            new()
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
                    "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. ",
                Picture = "https://localhost:7086//images/randomPicture.jpg"
            },
            new()
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
                    "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                Picture = "https://localhost:7086//images/whineGlassPicture.jpg"
            },
            new()
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
                    "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                Picture = "https://localhost:7086//images/whineGlassPicture.jpg"
            },
            new()
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
                    "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                Picture = "https://localhost:7086//images/whineGlassPicture.jpg"
            }
        };
        await _context.AddRangeAsync(attendes);
        await _context.AddRangeAsync(organizers);
        await _context.AddRangeAsync(events);

        await _context.SaveChangesAsync();
    }

    public async Task Recreate()
    {
        await _context.Database.EnsureDeletedAsync();
        await _context.Database.EnsureCreatedAsync();
    }

    public async Task RecreateAndSeed()
    {
        await Recreate();
        await SeedTestData();
    }

    public async Task CreateIfNotExist()
    {
        await _context.Database.EnsureCreatedAsync();
    }

    public async Task CreateAndSeedTestDataIfNotExist()
    {
        var didCreateDatabase = await _context.Database.EnsureCreatedAsync();
        if (didCreateDatabase) await SeedTestData();
    }
}