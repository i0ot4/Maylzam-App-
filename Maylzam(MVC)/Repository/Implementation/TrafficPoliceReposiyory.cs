using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    /// <summary>
    /// شرطه المرور
    /// </summary>

    public class TrafficPoliceReposiyory : GenericRepository<TrafficPolice>, ITrafficPoliceReposiyory
    {
        public TrafficPoliceReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
