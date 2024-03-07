using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class MReportReposiyory : GenericRepository<MReport>, IMReportReposiyory
    {
        public MReportReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
