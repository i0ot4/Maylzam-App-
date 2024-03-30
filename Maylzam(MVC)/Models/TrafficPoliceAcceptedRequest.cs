namespace Maylzam_MVC_.Models
{
    public class TrafficPoliceAcceptedRequest
    {
        public int Id { get; set; }
        public int TrafficPoliceId { get; set; }
        public int RequestId { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Completed_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
