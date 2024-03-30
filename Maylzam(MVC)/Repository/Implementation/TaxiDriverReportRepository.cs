using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TaxiDriverReportRepository : GenericRepository<TaxiDriverReport>, ITaxiDriverReportRepository
    {
        public TaxiDriverReportRepository(DbDbContext context) : base(context)
        {
        }
    }


}
