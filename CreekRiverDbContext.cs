using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
            new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
            new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
            new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
            new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, FirstName = "Saygin", LastName = "Gecener", Email = "saygin@aol.com"},
            new UserProfile {Id = 2, FirstName = "Luna", LastName = "Dawg", Email = "luna@example.com"}
        });
       
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, UserProfileId = 1, CampsiteId = 1, CheckInDate = new DateTime(2024, 11, 14), CheckoutDate = new DateTime(2024, 11, 18)},
            new Reservation {Id = 2,  UserProfileId = 2, CampsiteId = 2, CheckInDate = new DateTime(2024, 01, 26), CheckoutDate = new DateTime(2024, 01, 30)},
            new Reservation {Id = 3, UserProfileId = 1, CampsiteId = 4, CheckInDate = new DateTime(2024, 12, 12), CheckoutDate = new DateTime(2024, 12, 13)}
        });
    }
}