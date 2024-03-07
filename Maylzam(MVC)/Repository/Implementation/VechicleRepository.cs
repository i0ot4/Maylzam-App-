using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class VechicleRepository : GenericRepository<Vechicle>, IVechicleRepository
    {
        public VechicleRepository(DbDbContext context) : base(context)
        {
        }
    }


}
