using Maylzam_MVC_.Models;

namespace Maylzam_MVC_.ViewModel
{
    public class ProfileVM
    {
        public List<Customer>? ListCustomer { get; set; }
        public Customer Customer { get; set; }
        public List<Trip>? Trip { get; set; }
        public List<MaintenanceR>? MaintenanceR { get; set; }
        public List<TPRequest>? TPRequest { get; set; }
        public int Id { get; set; }
        public String Name { get; set; }
        public String Worked { get; set; }
    }
}
