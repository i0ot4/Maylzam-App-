
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Maylzam_MVC_.Models
{
    // هو عباره عن كلاس يحتوي على الجداول التي سوف يتم بناءها في قواعد البيانات والذي سوف يتم عمل دوال إيه بي اي عليها


    public class Customer
    {

        [Display(Name = "ID")]
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
        [Display(Name = "Profile Image")]
        public string? Profile_Image { get; set; }
        [Display(Name = "Date of created")]
        public DateTime Created_At { get; set; }
        [Display(Name = "Date of updated")]
        public DateTime Updated_At { get; set; }
        [Display(Name = "Working in")]
        public string? WorkingIn { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Delete")]
        public bool IsDelete { get; set; }
    }

}
