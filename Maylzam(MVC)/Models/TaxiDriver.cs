using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Maylzam_MVC_.Models
{

    public class TaxiDriver
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Customer Name")]
        [Display(Name = "TaxiDriver Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Check email entry correctly")]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter the Password")]
        [Display(Name = "Password")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please enter the Phone Number")]
        [Display(Name = "Phone number")]
        public string? Phone { get; set; }/*
        [Required(ErrorMessage = "Please Take a photo for your Driver License")]*/
        [Display(Name = "Driver License photo")]
        public string? Driver_License { get; set; }/*
        [Required(ErrorMessage = "Please Take a photo for your Personal Card")]*/
        [Display(Name = "The Front Of Personal Card photo")]
        public string? Personal_Card { get; set; }
        [Display(Name = "The Back Of Personal Card photo")]
        public string? Personal_Cardback { get; set; }
        [Display(Name = "Profile Image")]
        public string? Profile_Image { get; set; }
        [Display(Name = "Profile Image")]
        public DateTime Created_At { get; set; }
        [Display(Name = "Date of created")]
        public DateTime Updated_At { get; set; }
        public bool IsConfirm { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Delete")]
        public bool IsDelete { get; set; }
    }

}
