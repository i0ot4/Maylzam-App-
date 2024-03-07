namespace Maylzam_App_.Model
{
    public class AutomMechanic
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Center_Location { get; set; }
        public byte[]? Rental_License { get; set; }
        public byte[]? Personal_Card { get; set; }
        public byte[]? Profile_Image { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }

}
