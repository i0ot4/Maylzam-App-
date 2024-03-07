using Maylzam_App_.Model;
using Maylzam_App_.Repository.IRepository;

namespace Maylzam_App_.Repository.Implementation
{
    public class TaxiDriverRepository : GenericRepository<TaxiDriver>, ITaxiDriverRepository
    {
        public TaxiDriverRepository(DbDbContext context) : base (context)
        {
        }
    }
    public class VechicleRepository : GenericRepository<Vechicle>, IVechicleRepository
    {
        public VechicleRepository(DbDbContext context) : base(context)
        {
        }
    }

    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbDbContext context) : base(context)
        {
        }
    }
    public class TripRepository : GenericRepository<Trip>, ITripRepository
    {
        public TripRepository(DbDbContext context) : base(context)
        {
        }
    }
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DbDbContext context) : base(context)
        {
        }
    }

    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(DbDbContext context) : base(context)
        {
        }
    }
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        public ReportRepository(DbDbContext context) : base(context)
        {
        }
    }
    public class AcceptedTripRepository : GenericRepository<AcceptedTrip>, IAcceptedTripRepository
    {
        public AcceptedTripRepository(DbDbContext context) : base(context)
        {
        }
    }

    /// <summary>
    /// مهندس السيارات
    /// </summary>

    public class SkillReposiyory : GenericRepository<Skill>, ISkillReposiyory
    {
        public SkillReposiyory(DbDbContext context) : base(context)
        {
        }
    }

    public class EmployeeReposiyory : GenericRepository<Employee>, IEmployeeReposiyory
    {
        public EmployeeReposiyory(DbDbContext context) : base(context)
        {
        }
    }

    public class AutomMechanicReposiyory : GenericRepository<AutomMechanic>, IAutomMechanicReposiyory
    {
        public AutomMechanicReposiyory(DbDbContext context) : base(context)
        {
        }
    }
    public class MNotificationReposiyory : GenericRepository<MNotification>, IMNotificationReposiyory
    {
        public MNotificationReposiyory(DbDbContext context) : base(context)
        {
        }
    }
    
    public class MaintenanceRReposiyory : GenericRepository<MaintenanceR>, IMaintenanceRReposiyory
{
        public MaintenanceRReposiyory(DbDbContext context) : base(context)
        {
        }
    }
    
    public class AcceptedMRReposiyory : GenericRepository<AcceptedMR>, IAcceptedMRReposiyory
    {
        public AcceptedMRReposiyory(DbDbContext context) : base(context)
        {
        }

    }
    
    public class MReportReposiyory : GenericRepository<MReport>, IMReportReposiyory
    {
        public MReportReposiyory(DbDbContext context) : base(context)
        {
        }

    }

    /// <summary>
    /// شرطه المرور
    /// </summary>

    public class TrafficPoliceReposiyory : GenericRepository<TrafficPolice>, ITrafficPoliceReposiyory
    {
        public TrafficPoliceReposiyory(DbDbContext context) : base(context)
        {
        }

    }

    public class TPNotificationReposiyory : GenericRepository<TPNotification>, ITPNotificationReposiyory
    {
        public TPNotificationReposiyory(DbDbContext context) : base(context)
        {
        }

    }

    public class TPRequestReposiyory : GenericRepository<TPRequest>, ITPRequestReposiyory
    {
        public TPRequestReposiyory(DbDbContext context) : base(context)
        {
        }

    }

    public class TPAcceptedRequestReposiyory : GenericRepository<TPAcceptedRequest>, ITPAcceptedRequestReposiyory
    {
        public TPAcceptedRequestReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
