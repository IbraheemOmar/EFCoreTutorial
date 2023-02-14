
using EFCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial.Context
{
    public class MusicContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ToDo Change this to match the Database name as needed
          //  string connectionString = @"Data Source=localhost;Initial Catalog=MusicTesting1;Integrated Security=True;Encrypt=False";
            string connectionString="Server=(localdb)\\mssqllocaldb;Database=MusicTesting;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, FirstName = "Johnny", LastName = "Cash" },
                new Artist { Id = 2, FirstName = "Jimmy", LastName = "Buffet" },
                new Artist { Id = 3, FirstName = "Home", LastName = "Free" }

                );
            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Title = "Your Heartless", ArtistId = 1 },
                new Song { Id = 2, Title = "Ride Bikes", ArtistId = 1 },
                new Song { Id = 3, Title = "Your Heartless", ArtistId = 3 },
                new Song { Id = 4, Title = "Your not Heartless", ArtistId = 1 },
                new Song { Id = 5, Title = "Son of a Sailor", ArtistId = 2 },
                new Song { Id = 6, Title = "Sea Shanty", ArtistId = 3 },
                new Song { Id = 7, Title = "Island", ArtistId = 2 }
                );
        }
    }
}
