namespace Maylzam_App_.Model
{
    // هو عباره عن كلاس يحتوي على الجداول التي سوف يتم بناءها في قواعد البيانات والذي سوف يتم عمل دوال إيه بي اي عليها


    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public byte[]? Profile_Image { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string? worked { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
