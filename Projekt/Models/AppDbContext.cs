using Microsoft.EntityFrameworkCore;

namespace Projekt.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
                new Event() { EventId = 1, Name = "Noc z Szotem!", Description = "Całonocna zabawa z Szotem!", TypeOfEvent = "Koncert", DateOfEvent = new DateTime (2023,2,1,18,30,0), TicketPrice = 40},
                new Event() { EventId = 1, Name = "Romeo i Julia", Description = "Spektakl teatralny ", TypeOfEvent = "Teatr", DateOfEvent = new DateTime(2023, 4, 12, 12, 0, 0), TicketPrice = 30 },
                new Event() { EventId = 1, Name = "Opera", Description = "Opera", TypeOfEvent = "Opera", DateOfEvent = new DateTime(2023, 5, 14, 15, 0, 0), TicketPrice = 50 }
                );

            modelBuilder.Entity<Artist>().HasData(
                new Artist() { ArtistId = 1, Name = "Adam", Surname = "Kwieciński", Nickname = "Szot" },
                new Artist() { ArtistId = 2, Name = "Paweł", Surname = "Jakubczyk", Nickname = "Pawełek" },
                new Artist() { ArtistId = 3 , Name = "Kamil", Surname = "Kowalczyk", Nickname = "Kamson" }
                );

            modelBuilder.Entity<Event>()
                .HasMany<Artist>(a => a.Artists)
                .WithMany(b => b.Events)
                .UsingEntity(join => join.HasData(
                    new { EventId = 1, ArtisId= 2 },
                    new { EventId = 3, ArtisId = 1 },
                    new { EventId = 2, ArtisId = 3 }
                    ));
            


        }
    }
}
