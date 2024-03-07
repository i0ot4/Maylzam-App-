using Microsoft.EntityFrameworkCore;

namespace Maylzam_MVC_.Models
{

    //يستخدم هذا الكلاس لبناء الجدوال في قواعد البيانات من خلال تعريف كائن من موديل معين لبناءه في قواعد البيانات
    public class DbDbContext : DbContext
    {
        public DbDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TaxiDriver> TaxiDrivers { get; set; } // TaxiDrivers لبناء جدوال في قاعدة البيانات اسمه

        public DbSet<Vechicle> Vechicles { get; set; } // Vechicles لبناء جدوال في قاعدة البيانات اسمه

        public DbSet<Customer> customers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<AcceptedTrip> AcceptedTrips { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Skill> skills { get; set; }

        public DbSet<Employee> employees { get; set; }
        public DbSet<AutomMechanic> automMechanics { get; set; }
        public DbSet<MNotification> mNotifications { get; set; }
        public DbSet<MaintenanceR> maintenanceRs { get; set; }
        public DbSet<AcceptedMR> acceptedMRs { get; set; }
        public DbSet<MReport> mReports { get; set; }
        public DbSet<TrafficPolice> trafficPolices { get; set; }
        public DbSet<TPNotification> tpNotifications { get; set; }
        public DbSet<TPRequest> tpRequests { get; set; }
        public DbSet<TPAcceptedRequest> tpAcceptedRequests { get; set; }


    }
}
