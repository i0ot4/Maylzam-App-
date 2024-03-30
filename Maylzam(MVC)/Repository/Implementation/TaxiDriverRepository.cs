using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TaxiDriverRepository : GenericRepository<TaxiDriver>, ITaxiDriverRepository
    {
        public TaxiDriverRepository(DbDbContext context) : base (context)
        {
        }
    }


}
