using Microsoft.EntityFrameworkCore;

namespace Hotel_Listing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name="Jamaica",
                    ShortName = "JM"
                },
                new Country
                {
                    Id = 2,
                    Name = "Nepal",
                    ShortName = "NP"
                },
                new Country
                {
                    Id = 3,
                    Name = "Bahamas",
                    ShortName = "BS"
                }
            );

            builder.Entity<Hotel>().HasData(
               new Hotel
               {
                   Id = 1,
                   Name = "Sandals Resort and Spa",
                   Address = "Negril",
                   Rating = 4.5,
                   CountryId = 3
               },
               new Hotel
               {
                   Id = 2,
                   Name = "Sangrila Hotel",
                   Address = "Negril",
                   Rating = 4.5,
                   CountryId = 2
               },
               new Hotel
               {
                   Id = 3,
                   Name = "Hotel Yak And Yeti",
                   Address = "Negril",
                   Rating = 4.5,
                   CountryId = 2
               }
           );
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
