using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class AcceptedMRReposiyory : GenericRepository<AcceptedMR>, IAcceptedMRReposiyory
    {
        public AcceptedMRReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
