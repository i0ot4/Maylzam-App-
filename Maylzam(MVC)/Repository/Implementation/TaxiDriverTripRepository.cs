using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TaxiDriverTripRepository : GenericRepository<TaxiDriverTrip>, ITaxiDriverTripRepository
    {
        public TaxiDriverTripRepository(DbDbContext context) : base(context)
        {
        }
    }


}
