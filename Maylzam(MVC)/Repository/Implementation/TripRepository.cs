using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TripRepository : GenericRepository<Trip>, ITripRepository
    {
        public TripRepository(DbDbContext context) : base(context)
        {
        }
    }


}
