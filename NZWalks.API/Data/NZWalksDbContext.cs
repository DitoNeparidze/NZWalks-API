using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
namespace NZWalks.API.Data;


public class NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Image> Images { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var difficulties = new List<Difficulty>
        {
            new Difficulty
            {
                Id = Guid.Parse("543b461f-ccb5-4b6c-a4b6-f4613cbe45fe"),
                Name = "Easy"
            },
            new Difficulty
            {
                Id = Guid.Parse("b8f1bfe5-d42e-4383-95f6-97aedb16eae5"),
                Name = "Medium"
            },
            new Difficulty
            {
                Id = Guid.Parse("a2ac30a3-b0af-4bfc-8b7b-10500d090aa8"),
                Name = "Hard"
            }

        };


        modelBuilder.Entity<Difficulty>().HasData(difficulties);

        var regions = new List<Region>
        {
            new Region
            {
                Id = Guid.Parse("9ac3a0f6-6ff7-4b76-adde-c948fb0b7015"),
                Name = "Auckland",
                Code = "AKL",
                RegionImageUrl = "https://images.pexels.com/photos/17824133/pexels-photo-17824133.jpeg"
            },
            new Region
            {
                Id = Guid.Parse("a945243c-27eb-47d1-b6d6-aadc97d83dc2"),
                Name = "Nelson",
                Code = "NSN",
                RegionImageUrl = "https://images.pexels.com/photos/3396855/pexels-photo-3396855.jpeg"
            },
            new Region
            {
                Id = Guid.Parse("1dd49446-5834-4e1c-9dbf-ad1c2a7c9d7b"),
                Name = "Bay Of Plenty",
                Code = "BOP",
                RegionImageUrl = "https://images.pexels.com/photos/32947345/pexels-photo-32947345.jpeg"
            },
            new Region
            {
                Id = Guid.Parse("9327e0b5-314f-43b1-bfcc-e95b1775c965"),
                Name = "Wellington",
                Code = "WGN",
                RegionImageUrl = "https://images.pexels.com/photos/10097260/pexels-photo-10097260.jpeg"
            },
            new Region
            {
                Id = Guid.Parse("1c748ec2-980e-4f96-b644-e7fbf64ce600"),
                Name = "Southland",
                Code = "STL",
                RegionImageUrl = "https://images.pexels.com/photos/34549718/pexels-photo-34549718.jpeg"
            },
            new Region
            {
                Id = Guid.Parse("f35a94fe-b583-42fd-868b-dc53496adc5a"),
                Name = "Northland",
                Code = "NTL",
                RegionImageUrl = "https://images.pexels.com/photos/32947330/pexels-photo-32947330.jpeg"
            }
        };

        modelBuilder.Entity<Region>().HasData(regions);
    }
}
