using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TPNotificationReposiyory : GenericRepository<TPNotification>, ITPNotificationReposiyory
    {
        public TPNotificationReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
