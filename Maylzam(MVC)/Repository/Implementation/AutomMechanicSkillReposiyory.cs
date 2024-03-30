using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    /// <summary>
    /// مهندس السيارات
    /// </summary>

    public class AutomMechanicSkillReposiyory : GenericRepository<AutoMechanicSkill>, IAutomMechanicSkillReposiyory
    {
        public AutomMechanicSkillReposiyory(DbDbContext context) : base(context)
        {
        }
    }


}
