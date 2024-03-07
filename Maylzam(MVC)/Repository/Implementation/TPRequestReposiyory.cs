using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TPRequestReposiyory : GenericRepository<TPRequest>, ITPRequestReposiyory
    {
        public TPRequestReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
