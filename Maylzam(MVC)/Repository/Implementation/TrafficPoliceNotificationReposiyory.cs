using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TrafficPoliceNotificationReposiyory : GenericRepository<TrafficPoliceNotification>, ITrafficPoliceNotificationReposiyory
    {
        public TrafficPoliceNotificationReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
