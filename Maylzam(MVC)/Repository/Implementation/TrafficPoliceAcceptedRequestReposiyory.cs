using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TrafficPoliceAcceptedRequestReposiyory : GenericRepository<TrafficPoliceAcceptedRequest>, ITrafficPoliceAcceptedRequestReposiyory
    {
        public TrafficPoliceAcceptedRequestReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
