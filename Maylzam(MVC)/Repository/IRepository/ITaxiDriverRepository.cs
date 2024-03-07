using Maylzam_App_.Model;

namespace Maylzam_MVC_.Repository.IRepository
{
    public interface ITaxiDriverRepository : IGenericRepository<TaxiDriver>
    {

    }

    public interface IVechicleRepository : IGenericRepository<Vechicle>
    {

    }

    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        
    }

    public interface ITripRepository : IGenericRepository<Trip>
    {
        
    }

    public interface IPaymentRepository : IGenericRepository<Payment>
    {

    }

    public interface INotificationRepository : IGenericRepository<Notification>
    {

    }

    public interface IReportRepository : IGenericRepository<Report>
    {

    }

    public interface IAcceptedTripRepository : IGenericRepository<AcceptedTrip>
    {

    }




    /// <summary>
    /// مهندس السيارات
    /// </summary>
    public interface ISkillReposiyory : IGenericRepository<Skill>
    {

    }

    public interface IEmployeeReposiyory : IGenericRepository<Employee>
    {

    }

    public interface IAutomMechanicReposiyory : IGenericRepository<AutomMechanic>
    {

    }
    public interface IMNotificationReposiyory : IGenericRepository<MNotification>
    {

    }
    public interface IMaintenanceRReposiyory : IGenericRepository<MaintenanceR>
    {

    }
    public interface IAcceptedMRReposiyory : IGenericRepository<AcceptedMR>
    {

    }
    public interface IMReportReposiyory : IGenericRepository<MReport>
    {

    }

    /// <summary>
    /// Traffic police
    /// </summary>
    public interface ITrafficPoliceReposiyory : IGenericRepository<TrafficPolice>
    {

    }

    public interface ITPNotificationReposiyory : IGenericRepository<TPNotification>
    {

    }
    public interface ITPRequestReposiyory : IGenericRepository<TPRequest>
    {

    }
    public interface ITPAcceptedRequestReposiyory : IGenericRepository<TPAcceptedRequest>
    {

    }
}
