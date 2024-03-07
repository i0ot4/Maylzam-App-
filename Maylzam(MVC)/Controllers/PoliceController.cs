using Maylzam_App_.Model;
using Maylzam_MVC_.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{
	public class PoliceController : Controller
	{
        private readonly ITrafficPoliceReposiyory repository;

        public PoliceController(ITrafficPoliceReposiyory repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var res = await repository.GetAll(x => x.IsDelete == false);

            return View(res);
        }

        public async Task<IActionResult> GetDeleted()
        {
            var res = await repository.GetAll(x=>x.IsDelete == true);
            return View(res);
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(TrafficPolice entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            await repository.Add(entity);
            entity.Created_At = DateTime.Now;
            entity.IsDelete = false;
            await repository.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var res = await repository.GetById(id);

            return View(res);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Edit(TrafficPolice entity)
        {
            if (!ModelState.IsValid) { 
                return View(entity); 
            }

            repository.Update(entity);
            entity.Updated_At= DateTime.Now;
            entity.IsDelete= false;
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
        public async Task<IActionResult> DisRemove(int id)
        {
            var res = await repository.GetById(id);
            res.IsDelete = false;
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
