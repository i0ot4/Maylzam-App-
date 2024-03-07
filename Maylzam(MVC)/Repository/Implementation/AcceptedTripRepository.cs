using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class AcceptedTripRepository : GenericRepository<AcceptedTrip>, IAcceptedTripRepository
    {
        public AcceptedTripRepository(DbDbContext context) : base(context)
        {
        }
    }


}
