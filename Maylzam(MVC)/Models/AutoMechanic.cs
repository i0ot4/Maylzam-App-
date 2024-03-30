using Microsoft.AspNetCore.Identity;

namespace Maylzam_MVC_.Models
{
    public class AutoMechanic
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string? CenterName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Profile_Image { get; set; }
        public string? Phone { get; set; }
        public string? Center_Location { get; set; }
        public string? Rental_License { get; set; }
        public string? Personal_Card { get; set; }
        public string? Personal_Cardback { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }

}
