using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TaxiDriverAcceptedTripRepository : GenericRepository<TaxiDriverAcceptedTrip>, ITaxiDriverAcceptedTripRepository
    {
        public TaxiDriverAcceptedTripRepository(DbDbContext context) : base(context)
        {
        }
    }


}
