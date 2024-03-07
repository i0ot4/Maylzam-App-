using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class AutomMechanicReposiyory : GenericRepository<AutomMechanic>, IAutomMechanicReposiyory
    {
        public AutomMechanicReposiyory(DbDbContext context) : base(context)
        {
        }
    }


}
