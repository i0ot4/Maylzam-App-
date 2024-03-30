using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{
    public class AutoMechanicEmpController : Controller
    {
        private readonly IAutomMechanicEmployeeReposiyory employeeReposiyory;
public AutoMechanicEmpController(IAutomMechanicEmployeeReposiyory employeeReposiyory)
        {
            this.employeeReposiyory = employeeReposiyory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var res = await employeeReposiyory.GetAll(x => x.IsDelete == false && x.IsActive == true);
            return View(res);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id,AutoMechanicEmployee entity,IFormFile? uploadFile)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }


            await employeeReposiyory.Add(entity);
            entity.Id = 0;
            entity.AutomMechanicId = id;
            entity.IsDelete = false;
            entity.IsActive = true;
            entity.Created_At = DateTime.Now;

            if (uploadFile != null && uploadFile.Length > 0)
            {
                var fileName = Path.GetFileName(uploadFile.FileName);
                var filePath = Path.Combine("wwwroot/images/Employee/", fileName);
                entity.Personal_Photo = "images/Employee/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(fileSrteam);
                }
            }
            else
            {
                entity.Personal_Photo = "images/MaylZam.png";
            }
            await employeeReposiyory.SaveChanges();
            return RedirectToAction("Profile","AutoMechanic",new { id = entity.AutomMechanicId});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var respo = await employeeReposiyory.GetById(id);
            return View(respo);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AutoMechanicEmployee entity, IFormFile? uploadFile)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            entity.IsDelete = false;
            entity.IsActive = true;
            entity.Updated_At = DateTime.Now;

            if (uploadFile != null && uploadFile.Length > 0)
            {
                var fileName = Path.GetFileName(uploadFile.FileName);
                var filePath = Path.Combine("wwwroot/images/Employee/", fileName);
                entity.Personal_Photo = "images/Employee/" + fileName;


                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(fileSrteam);
                }
            }
            else
            {
                entity.Personal_Photo = "images/MaylZam.png";
            }
            employeeReposiyory.Update(entity);
            await employeeReposiyory.SaveChanges();
            return RedirectToAction("Profile", "AutoMechanic", new { id = entity.AutomMechanicId });
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var res = await employeeReposiyory.GetById(id);
            res.IsDelete = true;
            employeeReposiyory.Update(res);
            await employeeReposiyory.SaveChanges();
            return RedirectToAction("Profile", "AutoMechanic", new { id = res.AutomMechanicId });
        }

        [HttpGet]
        public async Task<IActionResult> Active(int id)
        {
            var res = await employeeReposiyory.GetById(id);
            res.IsActive = true;
            employeeReposiyory.Update(res);
            await employeeReposiyory.SaveChanges();
            return RedirectToAction("Profile", "AutoMechanic", new { id = res.AutomMechanicId });
        }

        [HttpGet]
        public async Task<IActionResult> DisActive(int id)
        {
            var res = await employeeReposiyory.GetById(id);
            res.IsActive = false;
            employeeReposiyory.Update(res);
            await employeeReposiyory.SaveChanges();
            return RedirectToAction("Profile", "AutoMechanic", new { id = res.AutomMechanicId });
        }

        [HttpGet]
        public async Task<IActionResult> DisDelete(int id)
        {
            var res = await employeeReposiyory.GetById(id);
            res.IsDelete = false;
            employeeReposiyory.Update(res);
            await employeeReposiyory.SaveChanges();
            return RedirectToAction("Profile", "AutoMechanic", new { id = res.AutomMechanicId });
        }
    }
}
