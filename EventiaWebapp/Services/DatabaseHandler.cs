using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;
using Microsoft.AspNetCore.Identity;

namespace EventiaWebapp.Services;

public class DatabaseHandler
{
    private readonly EpicEventsContext _context;
    private readonly UserManager<EventiaUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public DatabaseHandler(EpicEventsContext context, UserManager<EventiaUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedTestData()
    {

        var events = new List<Event>
        {
            new()
            {
                Title = "Eclipse Event",
                Date = new DateTime(2022, 06, 15, 18, 30, 00),
                Place = "Göteborg",
                Adress = "Föreningsgatan 14, 411 28 Göteborg",
                SpotsAvalable = 6,
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
                InfoLong =
                    "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness.",
                InfoShort =
                    "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                Picture = "https://localhost:7086//images/whineGlassPicture.jpg"
            }

        };
        var users = new List<EventiaUser>
        {
            new()
            {
                UserName = "admin@Eventia.com", Email = "admin@Eventia.com",
            },

            new()
            {
                UserName = "info@boardgames.se", OrganizerName = "Boardgames AB", Email = "info@boardgames.se",
                HostedEvents = new[] {events[0], events[1], events[2]},
            },
            new()
            {
                UserName ="info@gymbeast.com", OrganizerName = "Gymbeast AB", Email = "info@gymbeast.com",
                 HostedEvents = new[] {events[3], events[4], events[5]},
            },
            new()
            {
                UserName ="info@wineexplorer.se", OrganizerName = "Wineexplorer AB", Email = "info@wineexplorer.se",
                 HostedEvents = new[] {events[6], events[7], events[8]},
            },
            new()
            {
                UserName = "Ateende@Eventia.se", FirstName ="Namn", LastName ="Namnson", Email = "Ateende@Eventia.se",
                JoinedEvents = new[] {events[0], events[3], events[6]},
            },
             new()
            {
                 UserName = "wannabe@Eventia.se", FirstName ="Namn", LastName ="Namnson", Email = "wannabe@Eventia.se",
                
            },
             new()
             {
                 UserName = "wannabe2@Eventia.se", FirstName ="Namn", LastName ="Namnson", Email = "wannabe2@Eventia.se",
             },

        };

        await _context.AddRangeAsync(events);
        var roles = new List<IdentityRole>
            {
                new() {Name = "Admin"},
                new() {Name = "Organizer"},
                new() {Name = "User"},
            };

        await _roleManager.CreateAsync(roles[0]);
        await _roleManager.CreateAsync(roles[1]);
        await _roleManager.CreateAsync(roles[2]);

        await _userManager.CreateAsync(users[0], "Passw0rd!");
        await _userManager.CreateAsync(users[1], "Passw0rd!");
        await _userManager.CreateAsync(users[2], "Passw0rd!");
        await _userManager.CreateAsync(users[3], "Passw0rd!");
        await _userManager.CreateAsync(users[4], "Passw0rd!");
        await _userManager.CreateAsync(users[5], "Passw0rd!");
        await _userManager.CreateAsync(users[6], "Passw0rd!");


        await _userManager.AddToRoleAsync(users[0], "Admin");
        await _userManager.AddToRoleAsync(users[1], "Organizer");
        await _userManager.AddToRoleAsync(users[2], "Organizer");
        await _userManager.AddToRoleAsync(users[3], "Organizer");
        await _userManager.AddToRoleAsync(users[4], "User");
        await _userManager.AddToRoleAsync(users[5], "User");
        await _userManager.AddToRoleAsync(users[6], "User");

        var applications = new List<OrganizerApplication>
        {
            new()
            {
                Applicant = users[5],
                ApplicationDate = DateTime.Today,
                Handled = false
            },
            new()
            {
                Applicant = users[6],
                ApplicationDate = DateTime.Today,
                Handled = false
            }
        };

       
        await _context.AddRangeAsync(applications);
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