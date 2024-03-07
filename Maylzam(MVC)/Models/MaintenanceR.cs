using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Maylzam_MVC_.Models
{
    public class MaintenanceR
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "The Payment Methods")]
        public int PaymentId { get; set; }
        [Display(Name = "The Type Of The Skill")]
        public int SkillId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerImage { get; set; }
        [Required(ErrorMessage = "Please Locate")]
        [Display(Name = "The car Location")]
        public string? CurrentLocation { get; set; }
        [Required(ErrorMessage = "Please Enter The Car Type")]
        [Display(Name = "The Type Of The Car")]
        public string? CarType { get; set; }
        [Required(ErrorMessage = "Please Enter The Description")]
        [Display(Name = "The Description")]
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
