using Maylzam_MVC_.Repository.IRepository;
using Maylzam_MVC_.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{
    public class AutomMechanicAcceptedRequestController : Controller
    {

        private readonly IAutomMechanicAcceptedRequestReposiyory repository;
        private readonly IAutomMechanicRequestReposiyory requestrepository;

        public AutomMechanicAcceptedRequestController(IAutomMechanicAcceptedRequestReposiyory repository, IAutomMechanicRequestReposiyory requestrepository)
        {
            this.repository = repository;
            this.requestrepository = requestrepository;
        }

        public async Task<IActionResult> Index()
        {
            var res = await repository.GetAll(x => x.IsDelete == false);

            return View(res.ToList());
        }


        public async Task<IActionResult> GetNewTrip()
        {
            var res = await requestrepository.GetAll(x => x.IsDelete == false && x.Status == "Available");

            return View(res.ToList());
        }



        [HttpGet]
        public IActionResult Add(int id, int autoid)
        {
            return View(new AutoMechanicAcceptedRequestVM { Id = id, AutoId = autoid });
        }


        [HttpPost]
        public async Task<IActionResult> Add(AutoMechanicAcceptedRequestVM entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            var res = await requestrepository.GetById(entity.Id);

            entity.AcceptedRequest.Id = 0;

            entity.AcceptedRequest.MaintenanceRequestId = res.Id;

            entity.AcceptedRequest.AutomMechanicId = entity.AutoId;

            entity.AcceptedRequest.Status = "UnderDelivery";
            entity.AcceptedRequest.Created_At = DateTime.Now;
            entity.AcceptedRequest.IsDelete = false;

            await repository.Add(entity.AcceptedRequest);

            await repository.SaveChanges();

            res.Status = "Disavailable";
            res.Updated_At = DateTime.Now;
            requestrepository.Update(res);
            await requestrepository.SaveChanges();

            return RedirectToAction("Profile", "AutoMechanic", new { id = entity.AutoId });
        }


        [HttpGet]
        public async Task<IActionResult> Complete(int id)
        {
            var res = await repository.GetById(id);
            res.Status = "Complete";
            res.Completed_At = DateTime.Now;
            repository.Update(res);
            await repository.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Active(int id)
        {
            var res = await repository.GetById(id);
            res.IsActive = true;
            repository.Update(res);
            await repository.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DisActive(int id)
        {
            var res = await repository.GetById(id);
            res.IsActive = false;
            repository.Update(res);
            await repository.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
