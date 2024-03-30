using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Maylzam_MVC_.Models
{
    public class TaxiDriverReport
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int DriverId { get; set; } 
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please Enter the Type of Report")]
        [Display(Name = "Type of Report")]
        public string? Type { get; set; }
        [Required(ErrorMessage = "Please Enter the Description")]
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Status of Report")]
        public string? Status { get; set; }
        [Display(Name = "Author")]
        public string? Author { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
