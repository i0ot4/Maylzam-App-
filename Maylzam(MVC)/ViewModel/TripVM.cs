using Maylzam_MVC_.Models;

namespace Maylzam_MVC_.ViewModel
{
    public class TripVM
    {
        public Trip Trip { get; set; }
        public int Id { get; set; }
        public IFormFile? FormFileImage { get; set; }


    }
}
