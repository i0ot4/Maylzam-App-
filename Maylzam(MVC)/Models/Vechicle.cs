namespace Maylzam_MVC_.Models
{
    public class Vechicle
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public string? Type { get; set; }
        public string? Model { get; set; }
        public string? VNumber { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
