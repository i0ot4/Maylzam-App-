using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        public ReportRepository(DbDbContext context) : base(context)
        {
        }
    }


}
