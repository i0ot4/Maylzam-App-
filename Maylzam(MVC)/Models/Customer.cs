using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Maylzam_MVC_.Models
{
    // هو عباره عن كلاس يحتوي على الجداول التي سوف يتم بناءها في قواعد البيانات والذي سوف يتم عمل دوال إيه بي اي عليها


    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Customer Name")]
        [Display(Name = "Customer Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Check email entry correctly")]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter the Password")]
        [Display(Name = "Password")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please enter the Phone Number")]
        [Display(Name = "Phone number")]
        public string? Phone { get; set; }
        public byte[]? Profile_Image { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string? worked { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
