namespace Maylzam_MVC_.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string? Method { get; set; }
        public float Amount { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
