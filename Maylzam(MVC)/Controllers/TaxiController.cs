using Maylzam_App_.Model;
using Maylzam_MVC_.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{

    public class TaxiController : Controller
    {
        private readonly ITaxiDriverRepository repository;

        public TaxiController(ITaxiDriverRepository repository)
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
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(TaxiDriver entity, IFormFile driverLicenseFile, IFormFile personalCardFile, IFormFile profileImageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            // قم بحفظ ملفات الصور في المكان المناسب (مثلاً في القرص أو السحابة) واحتفظ بالمسارات في قاعدة البيانات
            if (driverLicenseFile != null && driverLicenseFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await driverLicenseFile.CopyToAsync(memoryStream);
                    entity.Driver_License = memoryStream.ToArray();
                }
            }

            if (personalCardFile != null && personalCardFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await personalCardFile.CopyToAsync(memoryStream);
                    entity.Personal_Card = memoryStream.ToArray();
                }
            }

            if (profileImageFile != null && profileImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await profileImageFile.CopyToAsync(memoryStream);
                    entity.Profile_Image = memoryStream.ToArray();
                }
            }

            await repository.Add(entity);
            entity.Created_At = DateTime.Now;
            entity.IsDelete = false;
            await repository.SaveChanges();

            return RedirectToAction("Index");
        }



        /* [HttpPost]
         public async Task<IActionResult> Add(TaxiDriver entity)
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
         }*/





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

    /*
        [HttpPost]
        public async Task<IActionResult> Add(TaxiDriver entity, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            if (imageFile == null || imageFile.Length == 0)
            {
                // تحقق من وجود ملف صورة صالح
                return BadRequest("يرجى تحديد ملف صورة.");
            }

            // قراءة بيانات الصورة وتحويلها إلى مصفوفة بايتات
            byte[] imageData;
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }
            await repository.Add(entity);
            // إنشاء نموذج الصورة وتعيين قيمه
            entity.Profile_Image = imageData;
            entity.Created_At = DateTime.Now;
            entity.IsDelete = false;
            await repository.SaveChanges();

            return RedirectToAction("Index");
        }*/

    public class TaxiTripController : Controller
    {
        private readonly ITripRepository repository;

        public TaxiTripController(ITripRepository repository)
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
            var res = await repository.GetAll(x => x.IsDelete == true);

            return View(res);
        }






        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Trip entity)
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




    /*..
     * 
     * 
     * */

        public class TaxiVechicleController : Controller
        {
            private readonly IVechicleRepository repository;

            public TaxiVechicleController(IVechicleRepository repository)
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
                var res = await repository.GetAll(x => x.IsDelete == true);

                return View(res);
            }






            [HttpGet]
            public IActionResult Add()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Add(Vechicle entity)
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
                var respo = await repository.GetById(id);
                return View(respo);
            }
            [HttpPost]
            public async Task<IActionResult> Edit(Vechicle entity)
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

     public class TaxiReportController : Controller
        {
            private readonly IReportRepository repository;

            public TaxiReportController(IReportRepository repository)
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
                var res = await repository.GetAll(x => x.IsDelete == true);

                return View(res);
            }






            [HttpGet]
            public IActionResult Add()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Add(Report entity)
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
                var respo = await repository.GetById(id);
                return View(respo);
            }
            [HttpPost]
            public async Task<IActionResult> Edit(Report entity)
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

        [HttpGet]
        public async Task<IActionResult> Reviewed(int id)
        {
            var res = await repository.GetById(id);
            res.Status = "Reviewed";
            repository.Update(res);
            await repository.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UnderReview(int id)
        {
            var res = await repository.GetById(id);
            res.Status = "Under Review";
            repository.Update(res);
            await repository.SaveChanges();
            return RedirectToAction("Index");
        }




    }
    
    
    
    public class PaymentsController : Controller
        {
            private readonly IPaymentRepository repository;

            public PaymentsController(IPaymentRepository repository)
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
                var res = await repository.GetAll(x => x.IsDelete == true);

                return View(res);
            }






            [HttpGet]
            public IActionResult Add()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Add(Payment entity)
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
                var respo = await repository.GetById(id);
                return View(respo);
            }
            [HttpPost]
            public async Task<IActionResult> Edit(Payment entity)
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

