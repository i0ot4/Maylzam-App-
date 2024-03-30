using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{
    /*..
     * 
     * 
     * */

    public class TaxiDriverVechicleController : Controller
        {
            private readonly ITaxiDriverVechicleRepository repository;
            private readonly ITaxiDriverRepository taxirepository;

        public TaxiDriverVechicleController(ITaxiDriverVechicleRepository repository, ITaxiDriverRepository taxirepository)
        {
            this.repository = repository;
            this.taxirepository = taxirepository;
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
        public async Task<IActionResult> Add(int id, TaxiDriverVechicle entity, IFormFile? uploadvehicleLicenseCardImage)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }


            await repository.Add(entity);
            entity.Id = 0;
            entity.DriverId = id;
            entity.IsDelete = false;
            entity.IsConfirm = false;
            entity.IsActive = true;
            entity.Created_At = DateTime.Now;

            if (uploadvehicleLicenseCardImage != null && uploadvehicleLicenseCardImage.Length > 0)
            {
                var fileName = Path.GetFileName(uploadvehicleLicenseCardImage.FileName);
                var filePath = Path.Combine("wwwroot/images/Employee/", fileName);
                entity.vehicleLicenseCardImage = "images/Employee/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadvehicleLicenseCardImage.CopyToAsync(fileSrteam);
                }
            }
            else
            {
                entity.vehicleLicenseCardImage = "images/MaylZam.png";
            }
            await repository.SaveChanges();
            return RedirectToAction("Profile", "TaxiDriver", new { id = entity.DriverId });
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
            return RedirectToAction("Profile","TaxiDriver",new { id = res.DriverId});

        }

        [HttpGet]
        public async Task<IActionResult> DisConfirm(int id)
        {
            var res = await repository.GetById(id);
            if (!ModelState.IsValid)
            {
                return View(res);
            }

            repository.Remove(res);
            await repository.SaveChanges();
            return RedirectToAction("Profile", "TaxiDriver", new { id = res.DriverId });

        }




        [HttpGet]
            public async Task<IActionResult> Edit(int id)
            {
                var respo = await repository.GetById(id);
                return View(respo);
            }
            [HttpPost]
            public async Task<IActionResult> Edit(TaxiDriverVechicle entity)
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
                return RedirectToAction("Profile", "TaxiDriver", new { id = res.DriverId });
            }

            [HttpGet]
            public async Task<IActionResult> DisActive(int id)
            {
                var res = await repository.GetById(id);
                res.IsActive = false;
                repository.Update(res);
                await repository.SaveChanges();
                return RedirectToAction("Profile","TaxiDriver",new { id = res.DriverId});
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

