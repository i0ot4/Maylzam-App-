using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class AutomMechanicNotificationReposiyory : GenericRepository<AutoMechanicNotification>, IAutomMechanicNotificationReposiyory
    {
        public AutomMechanicNotificationReposiyory(DbDbContext context) : base(context)
        {
        }
    }


}
