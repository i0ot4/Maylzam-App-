using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class AutomMechanicRequestReposiyory : GenericRepository<AutoMechanicRequest>, IAutomMechanicRequestReposiyory
    {
        public AutomMechanicRequestReposiyory(DbDbContext context) : base(context)
        {
        }
    }


}
