using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;

namespace Maylzam_MVC_.Repository.Implementation
{
    /// <summary>
    /// مهندس السيارات
    /// </summary>

    public class SkillReposiyory : GenericRepository<Skill>, ISkillReposiyory
    {
        public SkillReposiyory(DbDbContext context) : base(context)
        {
        }
    }


}
