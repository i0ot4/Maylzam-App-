using Maylzam_MVC_.Repository.IRepository;
using Maylzam_MVC_.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{
    public class TrafficPoliceAcceptedRequestController : Controller
    {


        private readonly ITrafficPoliceAcceptedRequestReposiyory repository;
        private readonly ITrafficPoliceRequestReposiyory requestrepository;

        public TrafficPoliceAcceptedRequestController(ITrafficPoliceAcceptedRequestReposiyory repository, ITrafficPoliceRequestReposiyory requestrepository)
        {
            this.repository = repository;
            this.requestrepository = requestrepository;
        }

        public async Task<IActionResult> Index()
        {
            var res = await repository.GetAll(x => x.IsDelete == false);

            return View(res.ToList());
        }





        [HttpGet]
        public IActionResult Add(int id, int userid)
        {
            return View(new TrafficPoliceAcceptedRequestVM { Id = id, UserId = userid });
        }


        [HttpPost]
        public async Task<IActionResult> Add(TrafficPoliceAcceptedRequestVM entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            var res = await requestrepository.GetById(entity.Id);

            entity.AcceptedRequest.Id = 0;

            entity.AcceptedRequest.RequestId = res.Id;

            entity.AcceptedRequest.TrafficPoliceId = entity.UserId;

            entity.AcceptedRequest.Status = "UnderDelivery";
            entity.AcceptedRequest.Created_At = DateTime.Now;
            entity.AcceptedRequest.IsDelete = false;

            await repository.Add(entity.AcceptedRequest);

            await repository.SaveChanges();

            res.Status = "Disavailable";
            res.Updated_At = DateTime.Now;
            requestrepository.Update(res);
            await requestrepository.SaveChanges();

            return RedirectToAction("Profile", "TrafficPolice", new { id = entity.UserId });
        }


        [HttpGet]
        public async Task<IActionResult> Complete(int id)
        {
            var res = await repository.GetById(id);
            res.Status = "Complete";
            res.Completed_At = DateTime.Now;
            repository.Update(res);
            await repository.SaveChanges();
            return RedirectToAction("Profile", "TrafficPolice", new { id = res.TrafficPoliceId });
        }

        [HttpGet]
        public async Task<IActionResult> failed(int id)
        {
            var res = await repository.GetById(id);
            res.Status = "failed";
            res.Completed_At = DateTime.Now;
            repository.Update(res);
            await repository.SaveChanges();
            return RedirectToAction("Profile", "TrafficPolice", new { id = res.TrafficPoliceId });
        }


    }
}
