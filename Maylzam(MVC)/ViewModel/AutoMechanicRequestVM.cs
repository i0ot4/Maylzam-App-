using Maylzam_MVC_.Models;

namespace Maylzam_MVC_.ViewModel
{
    public class AutoMechanicRequestVM
    {
        public MaintenanceR Request { get; set; }
        public int Id { get; set; }
        public IFormFile? FormFileImage { get; set; }
    }
}
