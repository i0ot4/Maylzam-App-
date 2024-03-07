using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Maylzam_MVC_.Models
{
    public class TPRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerImage { get; set; }
        [Required(ErrorMessage = "Please locate.")]
        [Display(Name = "Your Location")]
        public string? CurrentLocation { get; set; }
        [Display(Name = "The Type Of The action")]
        public string? Type { get; set; }
        [Required(ErrorMessage = "Please enter the Description.")]
        [Display(Name = "Description")]
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
