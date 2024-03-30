using Microsoft.EntityFrameworkCore;

namespace Maylzam_MVC_.Models
{

    //يستخدم هذا الكلاس لبناء الجدوال في قواعد البيانات من خلال تعريف كائن من موديل معين لبناءه في قواعد البيانات
    public class DbDbContext : DbContext
    {
        public DbDbContext(DbContextOptions options) : base(options)
        {

        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(x=> x.IsActive).HasDefaultValue(true);
            modelBuilder.Entity<Customer>().Property(x=> x.IsActive).HasDefaultValueSql("(getdate())");


            modelBuilder.Entity<>
        }
        public DbSet<TaxiDriver> TaxiDriver { get; set; } // TaxiDrivers لبناء جدوال في قاعدة البيانات اسمه

        public DbSet<TaxiDriverVechicle> TaxiDriverVechicle { get; set; } // Vechicles لبناء جدوال في قاعدة البيانات اسمه

        public DbSet<Customer> Customer { get; set; }
        public DbSet<TaxiDriverTrip> TaxiDriverTrip { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<TaxiDriverReport> TaxiDriverReport { get; set; }
        public DbSet<TaxiDriverAcceptedTrip> TaxiDriverAcceptedTrip { get; set; }
        public DbSet<TaxiDriverNotification> TaxiDriverNotification { get; set; }
        public DbSet<AutoMechanicSkill> AutoMechanicSkill { get; set; }

        public DbSet<AutoMechanicEmployee> AutoMechanicEmployee { get; set; }
        public DbSet<AutoMechanic> AutoMechanic { get; set; }
        public DbSet<AutoMechanicNotification> AutoMechanicNotification { get; set; }
        public DbSet<AutoMechanicRequest> AutoMechanicRequest { get; set; }
        public DbSet<AutoMechanicAcceptedRequest> AutoMechanicAcceptedRequest { get; set; }
        public DbSet<AutoMechanicReport> AutoMechanicReport { get; set; }
        public DbSet<TrafficPolice> TrafficPolice { get; set; }
        public DbSet<TrafficPoliceNotification> TrafficPoliceNotification { get; set; }
        public DbSet<TrafficPoliceRequest> TrafficPoliceRequest { get; set; }
        public DbSet<TrafficPoliceAcceptedRequest> TrafficPoliceAcceptedRequest { get; set; }


    }
}
