namespace Maylzam_App_.Model
{
    public class MNotification
    {
        public int Id { get; set; }
        public int AutomMechanicId { get; set; }
        public int CustomerId { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
