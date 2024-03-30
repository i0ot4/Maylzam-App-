using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Maylzam_MVC_.Models
{
    public class TaxiDriverVechicle
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        [Display(Name ="نوع السيارة")]
        public string? Type { get; set; }
        [Display(Name ="موديل السيارة")]
        public string? Model { get; set; }
        [Display(Name ="رقم اللوحة")]
        public string? licensePlateNumber { get; set; }
        [Display(Name = "بطاقة رخصة السيارة")]
        public string? vehicleLicenseCardImage { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
