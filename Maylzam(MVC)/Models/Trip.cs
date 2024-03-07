using System.ComponentModel.DataAnnotations;

namespace Maylzam_MVC_.Models
{
    public class Trip
    {
       
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        [Required(ErrorMessage ="يرجى اختيار طريقة الدفع")]
        [Display(Name = "طريقة الدفع")] 
        public int? PaymentId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerImage { get; set; }
        public string? CurrentLocation { get; set; }
        public string? EndLocation  { get; set; }
       
        public string? Payment { get; set; }
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
