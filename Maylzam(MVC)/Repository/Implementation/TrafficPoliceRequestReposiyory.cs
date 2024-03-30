using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TrafficPoliceRequestReposiyory : GenericRepository<TrafficPoliceRequest>, ITrafficPoliceRequestReposiyory
    {
        public TrafficPoliceRequestReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
