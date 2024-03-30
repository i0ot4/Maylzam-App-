using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;
using Maylzam_MVC_.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Maylzam_MVC_.Controllers
{
    [Authorize("C", )]

    public class TaxiDriverController : Controller
    {
        private readonly ITaxiDriverRepository repository;
        readonly private ICustomerRepository customerrepository;

        public TaxiDriverController(ITaxiDriverRepository repository, ICustomerRepository customerrepository)
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
        public async Task<IActionResult> Deatils(int id)
        {
            var res = await repository.GetById(id);
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> Confirm(int id)
        {
            var res = await repository.GetById(id);
            if (!ModelState.IsValid)
            {
                return View(res);
            }
            res.IsConfirm = true;
            res.Updated_At = DateTime.Now;
            repository.Update(res);
            await repository.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> DisConfirm(int id)
        {
            var res = await repository.GetById(id);
            if (!ModelState.IsValid)
            {
                return View(res);
            }

            var respo = await customerrepository.GetById(res.Id);
            respo.WorkingIn = "Customer";
            respo.Updated_At = DateTime.Now;
            customerrepository.Update(respo);
            await customerrepository.SaveChanges();
            repository.Remove(res);
            await repository.SaveChanges();
            return RedirectToAction("Index");

        }








        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            
            var respo = await customerrepository.GetById(id);
            return View(respo);
        }



        [HttpGet]
        public IActionResult Add()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id, TaxiDriver entity, IFormFile? uploadpersonalcard, IFormFile? uploadpersonalcardback, IFormFile? uploadDriverCard)
        {

            if (uploadpersonalcard != null && uploadpersonalcard.Length > 0)
            {
                var fileName = Path.GetFileName(uploadpersonalcard.FileName);
                var filePath = Path.Combine("wwwroot/images/TaxiDriver/", fileName);
                entity.Personal_Card = "images/TaxiDriver/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadpersonalcard.CopyToAsync(fileSrteam);
                }
            }

            if (uploadpersonalcardback != null && uploadpersonalcardback.Length > 0)
            {
                var fileName = Path.GetFileName(uploadpersonalcardback.FileName);
                var filePath = Path.Combine("wwwroot/images/TaxiDriver/", fileName);
                entity.Personal_Cardback = "images/TaxiDriver/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadpersonalcardback.CopyToAsync(fileSrteam);
                }
            }

            if (uploadDriverCard != null && uploadDriverCard.Length > 0)
            {
                var fileName = Path.GetFileName(uploadDriverCard.FileName);
                var filePath = Path.Combine("wwwroot/images/TaxiDriver/", fileName);
                entity.Driver_License = "images/TaxiDriver/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadDriverCard.CopyToAsync(fileSrteam);
                }
            }


            var respo = await customerrepository.GetById(id);
            entity.Id = id;
            entity.Profile_Image = respo.Profile_Image;
            entity.Name = respo.Name;
            entity.Password = respo.Password;
            entity.Phone = respo.Phone;
            entity.Email = respo.Email;
            entity.Created_At = DateTime.Now;
            entity.IsDelete = false;
            await repository.Add(entity);
            await repository.SaveChanges();

            respo.WorkingIn = "TaxiDriver";
            customerrepository.Update(respo);
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

