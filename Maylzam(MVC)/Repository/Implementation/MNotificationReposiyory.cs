using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class MNotificationReposiyory : GenericRepository<MNotification>, IMNotificationReposiyory
    {
        public MNotificationReposiyory(DbDbContext context) : base(context)
        {
        }
    }


}
