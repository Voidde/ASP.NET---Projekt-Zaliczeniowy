using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Projekt.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Artist> Artists{ get; set; }
        public DbSet<Ticket> Tickets{ get; set; }
        public DbSet<Place> Places { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>().HasData(
                new Event() { EventId = 1, EventName = "Noc z Szotem!", Description = "Całonocna zabawa z Szotem!", TypeOfEvent = "Koncert", DateOfEvent = new DateTime(2023, 2, 1, 18, 30, 0), TicketPrice = 40, PlaceId = 3 },
                new Event() { EventId = 2, EventName = "Romeo i Julia", Description = "Spektakl teatralny ", TypeOfEvent = "Teatr", DateOfEvent = new DateTime(2023, 4, 12, 12, 0, 0), TicketPrice = 30, PlaceId = 1 },
                new Event() { EventId = 3, EventName = "Opera", Description = "Opera", TypeOfEvent = "Opera", DateOfEvent = new DateTime(2023, 5, 14, 15, 0, 0), TicketPrice = 50, PlaceId = 2 }
                );
               
            modelBuilder.Entity<Artist>().HasData(
                new Artist() { ArtistId = 1, Name = "Adam", Surname = "Kwieciński", Nickname = "Szot" },
                new Artist() { ArtistId = 2, Name = "Paweł", Surname = "Jakubczyk", Nickname = "Pawełek" },
                new Artist() { ArtistId = 3, Name = "Kamil", Surname = "Kowalczyk", Nickname = "Kamson" }
                );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket() { ClientId = "asad", EventId = 1, TicketId = 1, TicketPrice = 40 },
                new Ticket() { ClientId = "dasd", EventId = 1, TicketId = 2, TicketPrice = 40 },
                new Ticket() { ClientId = "dfsdfa", EventId = 1, TicketId = 3, TicketPrice = 40 } 
                );

            modelBuilder.Entity<Place>().HasData(
                new Place() { PlaceId = 1, PlaceName = "Toro", City = "Kraków", Address = "Młyńska", AddressNr = "3", PostalCode = "00-000", PlaceDescription = "abcd" },
                new Place() { PlaceId = 2, PlaceName = "Poro", City = "Warszawa", Address = "Szczecińska", AddressNr = "4", PostalCode = "58-402", PlaceDescription = "abcd" },
                new Place() { PlaceId = 3, PlaceName = "Horo", City = "Katowice", Address = "Powstańców", AddressNr = "13", PostalCode = "21-370", PlaceDescription = "abcd" }
                );

            modelBuilder.Entity<Artist>()
                .HasMany<Event>(a => a.Events)
                .WithMany(b => b.Artists)              
                .UsingEntity(join => join.HasData(
                    new { ArtistsArtistId = 1, EventsEventId = 1 },
                    new { ArtistsArtistId = 2, EventsEventId = 3 },
                    new { ArtistsArtistId = 3, EventsEventId = 2 }
                    ));


        }
        
    }
}
