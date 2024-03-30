using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;
using Maylzam_MVC_.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Maylzam_MVC_.Controllers
{
    public class CCustomerController : Controller
    {
        readonly private ICustomerRepository repository;
        private readonly ITaxiDriverRepository taxirepository;
        private readonly IAutomMechanicReposiyory autorepository;
        private readonly ITrafficPoliceReposiyory policereposiyory;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public CCustomerController(ICustomerRepository repository, ITaxiDriverRepository taxirepository, IAutomMechanicReposiyory autorepository, ITrafficPoliceReposiyory policereposiyory, IWebHostEnvironment hostingEnvironment)
        {
            this.repository = repository;
            this.taxirepository = taxirepository;
            this.autorepository = autorepository;
            this.policereposiyory = policereposiyory;
            this.taxirepository = taxirepository;
            this.autorepository = autorepository;
            this.policereposiyory = policereposiyory;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var res = await repository.GetAll(x => x.IsDelete == false && x.WorkingIn == "Customer");

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
        public async Task<IActionResult> Add(Customer entity,IFormFile? uploadFile)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            await repository.Add(entity);
            entity.Id = 0;
            entity.WorkingIn = "Customer";
            entity.Created_At = DateTime.Now;
            entity.IsDelete = false;
            if (uploadFile != null && uploadFile.Length > 0)
            {
                var fileName = Path.GetFileName(uploadFile.FileName);
                var filePath = Path.Combine("wwwroot/images/", fileName);
                entity.Profile_Image = "images/"+fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(fileSrteam);
                }
            }
            else
            {
                entity.Profile_Image = "images/MaylZam.png";
            }
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
        public async Task<IActionResult> Edit(Customer entity, IFormFile? uploadFile)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            if (uploadFile != null && uploadFile.Length > 0)
            {
                var fileName = Path.GetFileName(uploadFile.FileName);
                var filePath = Path.Combine("wwwroot/images/", fileName);
                entity.Profile_Image = "images/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(fileSrteam);
                }
            }
            else
            {
                entity.Profile_Image = "images/MaylZam.png";
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

