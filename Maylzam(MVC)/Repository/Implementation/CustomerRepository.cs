using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbDbContext context) : base(context)
        {
        }
    }


}
