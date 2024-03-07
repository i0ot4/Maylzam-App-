using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class EmployeeReposiyory : GenericRepository<Employee>, IEmployeeReposiyory
    {
        public EmployeeReposiyory(DbDbContext context) : base(context)
        {
        }
    }


}
