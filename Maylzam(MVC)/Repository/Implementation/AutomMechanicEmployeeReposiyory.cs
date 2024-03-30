using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class AutomMechanicEmployeeReposiyory : GenericRepository<AutoMechanicEmployee>, IAutomMechanicEmployeeReposiyory
    {
        public AutomMechanicEmployeeReposiyory(DbDbContext context) : base(context)
        {
        }
    }


}
