using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;
using Maylzam_MVC_.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{
    public class AutoMechanicRequestController : Controller
    {
        private readonly IMaintenanceRReposiyory repository;

        private readonly ICustomerRepository customerrepository;

        public AutoMechanicRequestController(IMaintenanceRReposiyory repository, ICustomerRepository customerrepository)
        {
            this.repository = repository;
            this.customerrepository = customerrepository;
        }

        public async Task<IActionResult> Index()
        {

            var temp = await customerrepository.GetAll();
            var res = await repository.GetAll(x => x.IsDelete == false);

            return View(res.ToList());
        }



        public async Task<IActionResult> GetDeleted()
        {
            var res = await repository.GetAll(x => x.IsDelete == true);

            return View(res);
        }







        [HttpGet]
        public IActionResult Add(int id)
        {

            return View(new AutoMechanicRequestVM { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AutoMechanicRequestVM entity)
        {

            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            entity.Request.Id = 0;
            var res = await customerrepository.GetById(entity.Id);
            /*
                        var c = repository.Entities.Count<Trip>();
                        entity.Id = c + 1;*/
            // entity.PaymentId = 1;
            entity.Request.CustomerId = res.Id;
            entity.Request.CustomerName = res.Name;
            entity.Request.CustomerPhone = res.Phone;
            entity.Request.Created_At = DateTime.Now;
            entity.Request.IsDelete = false;

            await repository.Add(entity.Request);

            await repository.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var respo = await repository.GetById(id);
            return View(respo);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MaintenanceR entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            entity.IsDelete = false;
            entity.Updated_At = DateTime.Now;
            repository.Update(entity);
            await repository.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var res = await repository.GetById(id);
            res.IsDelete = true;
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

        [HttpGet]
        public async Task<IActionResult> DisDelete(int id)
        {
            var res = await repository.GetById(id);
            res.IsDelete = false;
            repository.Update(res);
            await repository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
