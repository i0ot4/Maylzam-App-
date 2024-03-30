using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    public class AutomMechanicAcceptedRequestReposiyory : GenericRepository<AutoMechanicAcceptedRequest>, IAutomMechanicAcceptedRequestReposiyory
    {
        public AutomMechanicAcceptedRequestReposiyory(DbDbContext context) : base(context)
        {
        }

    }


}
