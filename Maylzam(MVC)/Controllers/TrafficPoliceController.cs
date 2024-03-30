using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{
	public class TrafficPoliceController : Controller
	{
        private readonly ITrafficPoliceReposiyory repository;
        readonly private ICustomerRepository customerrepository;

        public TrafficPoliceController(ITrafficPoliceReposiyory repository, ICustomerRepository customerrepository)
        {
            this.repository = repository;
            this.customerrepository = customerrepository;
        }

        public async Task<IActionResult> Index()
        {
            var res = await repository.GetAll(x => x.IsDelete == false);

            return View(res);
        }



        public async Task<IActionResult> Profile(int id)
        {
            var res = await repository.GetById(id);

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
        public async Task<IActionResult> Add(int id,TrafficPolice entity, IFormFile? uploadpersonalcard, IFormFile? uploadpersonalcardback, IFormFile? uploadPolicer)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            if (uploadpersonalcard != null && uploadpersonalcard.Length > 0)
            {
                var fileName = Path.GetFileName(uploadpersonalcard.FileName);
                var filePath = Path.Combine("wwwroot/images/TrafficPolice/", fileName);
                entity.Personal_Card = "images/TrafficPolice/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadpersonalcard.CopyToAsync(fileSrteam);
                }
            }

            if (uploadpersonalcardback != null && uploadpersonalcardback.Length > 0)
            {
                var fileName = Path.GetFileName(uploadpersonalcardback.FileName);
                var filePath = Path.Combine("wwwroot/images/TrafficPolice/", fileName);
                entity.Personal_Cardback = "images/TrafficPolice/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadpersonalcardback.CopyToAsync(fileSrteam);
                }
            }

            if (uploadPolicer != null && uploadPolicer.Length > 0)
            {
                var fileName = Path.GetFileName(uploadPolicer.FileName);
                var filePath = Path.Combine("wwwroot/images/TrafficPolice/", fileName);
                entity.PolicerCardImage = "images/TrafficPolice/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadPolicer.CopyToAsync(fileSrteam);
                }
            }

            var res = await customerrepository.GetById(id);

            entity.Id = res.Id;
            entity.Name = res.Name;
            entity.Profile_Image = res.Profile_Image;
            entity.Phone = res.Phone;
            entity.Email = res.Email;
            entity.Password = res.Password;
            entity.Created_At = DateTime.Now;
            entity.IsDelete = false;
            entity.IsConfirm = false;
            entity.Profile_Image = res.Profile_Image;
            await repository.Add(entity);
            await repository.SaveChanges();

            res.WorkingIn = "TrafficPolice";
            res.Updated_At = DateTime.Now;
            customerrepository.Update(res);
            await customerrepository.SaveChanges();

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
