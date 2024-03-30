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
        public async Task<IActionResult> Profile(int id)
        {

            var respo = await repository.GetById(id);
            return View(respo);
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id,AutoMechanic entity, IFormFile? uploadpersonalcard, IFormFile? uploadpersonalcardback, IFormFile? uploadrental)
        {
            if (uploadpersonalcard != null && uploadpersonalcard.Length > 0)
            {
                var fileName = Path.GetFileName(uploadpersonalcard.FileName);
                var filePath = Path.Combine("wwwroot/images/autoConfirm/", fileName);
                entity.Personal_Card = "images/autoConfirm/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadpersonalcard.CopyToAsync(fileSrteam);
                }
            }

            if (uploadpersonalcardback != null && uploadpersonalcardback.Length > 0)
            {
                var fileName = Path.GetFileName(uploadpersonalcardback.FileName);
                var filePath = Path.Combine("wwwroot/images/autoConfirm/", fileName);
                entity.Personal_Cardback = "images/autoConfirm/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadpersonalcardback.CopyToAsync(fileSrteam);
                }
            }

            if (uploadrental != null && uploadrental.Length > 0)
            {
                var fileName = Path.GetFileName(uploadrental.FileName);
                var filePath = Path.Combine("wwwroot/images/autoConfirm/", fileName);
                entity.Rental_License = "images/autoConfirm/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadrental.CopyToAsync(fileSrteam);
                }
            }

            var res = await customerrepository.GetById(id);
            entity.Id = res.Id;
            entity.Profile_Image = res.Profile_Image;
            entity.Name = res.Name;
            entity.Phone = res.Phone;
            entity.Email = res.Email;
            entity.Password = res.Password;
            entity.Created_At = DateTime.Now;
            entity.IsDelete = false;
            entity.IsConfirm = false;
            res.WorkingIn = "AutoMechanic";
            customerrepository.Update(res);
            await customerrepository.SaveChanges();
            await repository.Add(entity);
            await repository.SaveChanges();

            return RedirectToAction("Index");
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
            res.Updated_At= DateTime.Now;
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
        public async Task<IActionResult> Edit(int id)
        {
            var respo = await repository.GetById(id);
            return View(respo);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AutoMechanic entity)
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
