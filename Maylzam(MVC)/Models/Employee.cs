namespace Maylzam_MVC_.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Skill { get; set; }
        public string? Phone { get; set; }
        public byte[]? Personal_Photo { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
