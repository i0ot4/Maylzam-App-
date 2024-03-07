
using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;
using Maylzam_MVC_.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{

    public class TaxiTripController : Controller
    {
        private readonly ITripRepository repository;
        private readonly ICustomerRepository customerrepository;

        public TaxiTripController(ITripRepository repository, ICustomerRepository customerrepository)
        {
            this.repository = repository;
            this.customerrepository = customerrepository;
        }

        public async Task<IActionResult> Index()
        {

         var temp=   await customerrepository.GetAll();
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

            return View(new TripVM { Id=id});
        }

        [HttpPost]
        public async Task<IActionResult> Add(TripVM entity)
        {

            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            entity.Trip.Id = 0;
            var res = await customerrepository.GetById(entity.Id);
            entity.Trip.CustomerId = res.Id;
            entity.Trip.CustomerName = res.Name;
            entity.Trip.CustomerPhone = res.Phone;
            entity.Trip.Created_At = DateTime.Now;
            entity.Trip.IsDelete = false;

            await repository.Add(entity.Trip);
         
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
        public async Task<IActionResult> Edit(Trip entity)
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

