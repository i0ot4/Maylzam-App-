using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class TaxiDriverVechicleRepository : GenericRepository<TaxiDriverVechicle>, ITaxiDriverVechicleRepository
    {
        public TaxiDriverVechicleRepository(DbDbContext context) : base(context)
        {
        }
    }


}
