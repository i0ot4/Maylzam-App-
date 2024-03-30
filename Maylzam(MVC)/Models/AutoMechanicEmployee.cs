using System.ComponentModel.DataAnnotations;

namespace Maylzam_MVC_.Models
{
    public class AutoMechanicEmployee
    {
        public int Id { get; set; }
        public int AutomMechanicId { get; set; }
        public int SkillId { get; set; }
        [Display(Name = "Employee Name")]
        public string? Name { get; set; }
        [Display(Name = "Employee Phone Number")]
        public string? Phone { get; set; }
        [Display(Name = "Personal Photo")]
        public string? Personal_Photo { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        [Display(Name = "Activity")]
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
