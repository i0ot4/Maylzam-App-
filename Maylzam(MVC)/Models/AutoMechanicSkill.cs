namespace Maylzam_MVC_.Models
{
    //AutomMechanic
    public class AutoMechanicSkill
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsDelete { get; set; }

    }

}
