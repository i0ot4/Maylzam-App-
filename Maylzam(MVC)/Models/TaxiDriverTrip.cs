using System.ComponentModel.DataAnnotations;

namespace Maylzam_MVC_.Models
{
    public class TaxiDriverTrip
    {
       
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Please enter the Method")]
        [Display(Name = "Payment Method")] 
        public int? PaymentId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerImage { get; set; }
        [Required(ErrorMessage = "Please enter the locate")]
        [Display(Name = "Locate")]
        public string? CurrentLocation { get; set; }
        [Required(ErrorMessage = "Please enter the End Location")]
        [Display(Name = "End Location")]
        public string? EndLocation  { get; set; }
        [Required(ErrorMessage = "Please enter the Description")]
        [Display(Name = "Description")]
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
