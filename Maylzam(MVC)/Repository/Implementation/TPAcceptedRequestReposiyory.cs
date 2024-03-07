using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TPAcceptedRequestReposiyory : GenericRepository<TPAcceptedRequest>, ITPAcceptedRequestReposiyory
    {
        public TPAcceptedRequestReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
