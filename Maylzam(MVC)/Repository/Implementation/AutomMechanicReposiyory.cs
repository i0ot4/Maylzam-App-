using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class AutomMechanicReposiyory : GenericRepository<AutoMechanic>, IAutomMechanicReposiyory
    {
        public AutomMechanicReposiyory(DbDbContext context) : base(context)
        {
        }
    }


}
