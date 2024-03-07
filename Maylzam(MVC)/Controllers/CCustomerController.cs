using Maylzam_App_.Model;
using Maylzam_MVC_.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{
    public class CCustomerController : Controller
    {
        readonly private ICustomerRepository repository;
        private readonly ITaxiDriverRepository taxirepository;
        private readonly IAutomMechanicReposiyory autorepository;
        private readonly ITrafficPoliceReposiyory policereposiyory;

        public CCustomerController(ICustomerRepository repository, ITaxiDriverRepository taxirepository,
            IAutomMechanicReposiyory autorepository,ITrafficPoliceReposiyory policereposiyory)
        {
            this.repository = repository;
            this.taxirepository = taxirepository;
            this.autorepository = autorepository;
            this.policereposiyory = policereposiyory;
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
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Customer entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            await repository.Add(entity);
            entity.worked = "Customer";
            entity.Created_At = DateTime.Now;
            entity.IsDelete = false;
            await repository.SaveChanges();

            return RedirectToAction("Index");
        }




        [HttpGet]
        public async Task<IActionResult> AddToTaxi(int id)
        {
            var respo = await repository.GetById(id);
            return View(respo);
        }

        [HttpPost]
        public async Task<IActionResult> AddToTaxi(Customer entity, TaxiDriver entities)
        {
            entities.Created_At = DateTime.Now;
            entities.IsDelete = false;
            await taxirepository.Add(entities);
            entity.worked = "TaxiDriver";
            repository.Update(entity);
            await repository.SaveChanges();
            await taxirepository.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddToPolice(int id)
        {
            var respo = await repository.GetById(id);
            return View(respo);
        }

        [HttpPost]
        public async Task<IActionResult> AddToPolice(Customer entity, TrafficPolice entities)
        {
            entities.Created_At = DateTime.Now;
            entities.IsDelete = false;
            entity.worked = "TrafficPolice";
            repository.Update(entity);
            await repository.SaveChanges();
            await policereposiyory.Add(entities);
            await policereposiyory.SaveChanges();

            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public async Task<IActionResult> AddToAuto(int id)
        {
            var respo = await repository.GetById(id);
            return View(respo);
        }

        [HttpPost]
        public async Task<IActionResult> AddToAuto(Customer entity, AutomMechanic entities)
        {
            entities.Created_At = DateTime.Now;
            entities.IsDelete = false;
            entity.worked = "AutomMechanic";
            repository.Update(entity);
            await repository.SaveChanges();
            await autorepository.Add(entities);
            await autorepository.SaveChanges();

            return RedirectToAction("Index");
        }





        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var respo = await repository.GetById(id);
            return View(respo);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Customer entity)
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

