namespace Maylzam_MVC_.Models
{
    public class AutoMechanicAcceptedRequest
    {
        public int Id { get; set; }
        public int AutomMechanicId { get; set; }
        public int MaintenanceRequestId { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Completed_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
