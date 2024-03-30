using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TaxiDriverNotificationRepository : GenericRepository<TaxiDriverNotification>, ITaxiDriverNotificationRepository
    {
        public TaxiDriverNotificationRepository(DbDbContext context) : base(context)
        {
        }
    }


}
