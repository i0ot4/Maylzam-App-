namespace Maylzam_App_.Model
{
    public class TPAcceptedRequest
    {
        public int Id { get; set; }
        public int TrafficPoliceId { get; set; }
        public int TrafficPoliceRequestId { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Completed_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
