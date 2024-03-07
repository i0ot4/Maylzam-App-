using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Maylzam_MVC_.Controllers
{
	public class AutoMechanicController : Controller
	{
        private readonly IAutomMechanicReposiyory repository;
        readonly private ICustomerRepository customerrepository;

        public AutoMechanicController(IAutomMechanicReposiyory repository, ICustomerRepository customerrepository)
        {
            this.repository = repository;
            this.customerrepository = customerrepository;
        }

        public async Task<IActionResult> Index()
        {
            var res = await repository.GetAll(x => x.IsDelete == false);

            return View(res);
        }

        public async Task<IActionResult> GetDeleted()
        {
            var res = await repository.GetAll(x => x.IsDelete == true);

            return View(res);
        }







        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var respo = await customerrepository.GetById(id);
            return View(respo);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer entity, AutomMechanic entities)
        {
            entities.Id = 0;
            entities.Created_At = DateTime.Now;
            entities.IsDelete = false;
            entity.worked = "AutomMechanic";
            customerrepository.Update(entity);
            await customerrepository.SaveChanges();
            await repository.Add(entities);
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
        public async Task<IActionResult> Edit(AutomMechanic entity)
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
