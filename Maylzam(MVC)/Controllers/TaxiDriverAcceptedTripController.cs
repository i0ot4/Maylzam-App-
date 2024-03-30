using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;
using Maylzam_MVC_.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{
    public class TaxiDriverAcceptedTripController : Controller
    {
        private readonly ITaxiDriverAcceptedTripRepository repository;
        private readonly ITaxiDriverTripRepository triprepository;

        public TaxiDriverAcceptedTripController(ITaxiDriverAcceptedTripRepository repository, ITaxiDriverTripRepository triprepository)
        {
            this.repository = repository;
            this.triprepository = triprepository;
        }

        public async Task<IActionResult> Index()
        {
            var res = await repository.GetAll(x => x.IsDelete == false);

            return View(res.ToList());
        }


        public async Task<IActionResult> GetNewTrip()
        {
            var res = await triprepository.GetAll(x => x.IsDelete == false && x.Status == "Available");

            return View(res.ToList());
        }



        [HttpGet]
        public IActionResult Add(int id , int driverid)
        {
            return View(new TaxiDriverAcceptedTripVM { Id = id, DriverId = driverid });
        }


        [HttpPost]
        public async Task<IActionResult> Add(TaxiDriverAcceptedTripVM entity)
        { 
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            var res = await triprepository.GetById(entity.Id);

            entity.AcceptedTrip.Id = 0;

            entity.AcceptedTrip.TripId = res.Id;

            entity.AcceptedTrip.DriverId = entity.DriverId ;

            entity.AcceptedTrip.Status = "UnderDelivery";
            entity.AcceptedTrip.Created_At = DateTime.Now;
            entity.AcceptedTrip.IsDelete = false;

            await repository.Add(entity.AcceptedTrip);

            await repository.SaveChanges();

            res.Status = "Disavailable";
            res.Updated_At = DateTime.Now;
            triprepository.Update(res);
            await triprepository.SaveChanges();

            return RedirectToAction("Profile","TaxiDriver",new {id = entity.DriverId});
        }


        [HttpGet]
        public async Task<IActionResult> Complete(int id)
        {
            var res = await repository.GetById(id);
            res.Status = "Complete";
            res.Completed_At = DateTime.Now;
            repository.Update(res);
            await repository.SaveChanges();
            return RedirectToAction("Profile","TaxiDriver",new {id = res.DriverId});
        }




       /* 
        [HttpGet]
        public async Task<IActionResult> failed(int id)
        {
            var res = await repository.GetById(id);
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> failed(TaxiDriverAcceptedTrip acceptedTrip, TaxiDriverReport entity)
        {
            entity.TripId = acceptedTrip.TripId;
            entity.DriverId = acceptedTrip.DriverId;
            entity.Author = "TaxiDriver";
            entity.Status = "";

          
            acceptedTrip.Status = "failed";
            acceptedTrip.Completed_At = DateTime.Now;
            repository.Update(acceptedTrip);
            await repository.SaveChanges();
            return RedirectToAction("Index");


        }*/





    }
}
