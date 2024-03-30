using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class AutomMechanicReportReposiyory : GenericRepository<AutoMechanicReport>, IAutomMechanicReportReposiyory
    {
        public AutomMechanicReportReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
