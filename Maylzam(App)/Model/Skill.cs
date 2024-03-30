namespace Maylzam_App_.Model
{
    //AutomMechanic
    public class Skill
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsDelete { get; set; }

    }

}
