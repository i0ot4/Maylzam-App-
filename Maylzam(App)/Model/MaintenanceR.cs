namespace Maylzam_App_.Model
{
    public class MaintenanceR
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public int SkillId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerImage { get; set; }
        public string? CurrentLocation { get; set; }
        public string? EndLocation { get; set; }
        public string? Payment { get; set; }
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
