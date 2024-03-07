using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Maylzam_MVC_.Controllers
{

    public class TaxiController : Controller
    {
        private readonly ITaxiDriverRepository repository;
        readonly private ICustomerRepository customerrepository;

        public TaxiController(ITaxiDriverRepository repository, ICustomerRepository customerrepository = null)
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








                    /*هذه الداله*/

        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            var respo = await repository.GetById(id);
            return View(respo);
        }


        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var respo = await customerrepository.GetById(id);
            return View(respo);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer entity, TaxiDriver entities)
        {
            entities.Id = 0;
            entities.Created_At = DateTime.Now;
            entities.IsDelete = false;
            await repository.Add(entities);
            await repository.SaveChanges();

            entity.worked = "TaxiDriver";
            customerrepository.Update(entity);
            await customerrepository.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var respo = await repository.GetById(id);
            return View(respo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaxiDriver entity)
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

