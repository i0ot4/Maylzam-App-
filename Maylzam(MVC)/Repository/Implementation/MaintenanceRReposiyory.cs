using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class MaintenanceRReposiyory : GenericRepository<MaintenanceR>, IMaintenanceRReposiyory
    {
        public MaintenanceRReposiyory(DbDbContext context) : base(context)
        {
        }
    }


}
