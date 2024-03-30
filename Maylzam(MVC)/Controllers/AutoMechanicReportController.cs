using Maylzam_MVC_.Repository.IRepository;
using Maylzam_MVC_.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{
    public class AutoMechanicReportController : Controller
    {



        private readonly IAutomMechanicReportReposiyory reportrepository;
        private readonly IAutomMechanicAcceptedRequestReposiyory acceptedrepository;
        readonly private IAutomMechanicRequestReposiyory requestrepository;
        readonly private ICustomerRepository customerrepository;

        public AutoMechanicReportController(IAutomMechanicRequestReposiyory requestrepository, ICustomerRepository customerrepository, IAutomMechanicAcceptedRequestReposiyory acceptedrepository, IAutomMechanicReportReposiyory reportrepository)
        {
            this.requestrepository = requestrepository;
            this.customerrepository = customerrepository;
            this.acceptedrepository = acceptedrepository;
            this.reportrepository = reportrepository;
        }


        public async Task<IActionResult> Index()
        {
            var res = await reportrepository.GetAll(x => x.IsDelete == false);

            return View(res);
        }




        [HttpGet]
        public IActionResult Add(int id, int autoid)
        {
            return View(new AutoMechanicReportVM { Id = id, AutoId = autoid  });


        }
        [HttpPost]
        public async Task<IActionResult> Add(AutoMechanicReportVM entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            if (entity.AutoId == 0)
            {
                var res = await requestrepository.GetById(entity.Id);
                entity.Report.CustomerId = res.CustomerId;
                var res2 = await customerrepository.GetById(res.CustomerId);
                entity.Report.Author = res2.WorkingIn;
                entity.Report.MaintenanceRequestId = entity.Id;
                entity.Report.Id = 0;
                entity.Report.Status = "UnderReview";
                entity.Report.Created_At = DateTime.Now;
                entity.Report.IsDelete = false;
                entity.Report.IsActive = true;

                await reportrepository.Add(entity.Report);

                await reportrepository.SaveChanges();

                if (res2.WorkingIn == "TrafficPolice")
                {
                    return RedirectToAction("Profile", "TrafficPolice", new { id = res2.Id });
                }
                else if (res2.WorkingIn == "TaxiDriver")
                {
                    return RedirectToAction("Profile", "TaxiDriver", new { id = res2.Id });
                }
                else
                {
                    return RedirectToAction("Profile", "CCustomer", new { id = res2.Id });
                }
            }
            else
            {
                var res = await acceptedrepository.GetById(entity.Id);
                res.Status = "failed";
                acceptedrepository.Update(res);
                await acceptedrepository.SaveChanges();
                entity.Report.AutomMechanicId = res.AutomMechanicId;
                entity.Report.MaintenanceRequestId = res.MaintenanceRequestId;
                entity.Report.Author = "AutomMechanic";

                entity.Report.Id = 0;
                entity.Report.Status = "UnderReview";
                entity.Report.Created_At = DateTime.Now;
                entity.Report.IsDelete = false;
                entity.Report.IsActive = true;

                await reportrepository.Add(entity.Report);

                await reportrepository.SaveChanges();
                return RedirectToAction("Profile", "AutoMechanic", new { id = res.AutomMechanicId });

            }

            
        }


        [HttpGet]
        public async Task<IActionResult> Reviewed(int id,int Userid)
        {
            var res = await reportrepository.GetById(id);
            res.Status = "Reviewed";
            reportrepository.Update(res);
            await reportrepository.SaveChanges();

            if (Userid != 0)
            {

                var res2 = await customerrepository.GetById(Userid);
                if (res2.WorkingIn == "TrafficPolice")
                {
                    return RedirectToAction("Profile", "TrafficPolice", new { id = res2.Id });
                }
                else if (res2.WorkingIn == "TaxiDriver")
                {
                    return RedirectToAction("Profile", "TaxiDriver", new { id = res2.Id });
                }
                else
                {
                    return RedirectToAction("Profile", "CCustomer", new { id = res2.Id });
                }
            }
            else
            {
                return RedirectToAction("Profile", "AutoMechanic", new { id = Userid });
            }


        }

        [HttpGet]
        public async Task<IActionResult> UnderReview(int id,int Userid)
        {
            var res = await reportrepository.GetById(id);
            res.Status = "UnderReview";
            reportrepository.Update(res);
            await reportrepository.SaveChanges(); 
            
            if (Userid != 0)
            {

                var res2 = await customerrepository.GetById(Userid);
                if (res2.WorkingIn == "TrafficPolice")
                {
                    return RedirectToAction("Profile", "TrafficPolice", new { id = res2.Id });
                }
                else if (res2.WorkingIn == "TaxiDriver")
                {
                    return RedirectToAction("Profile", "TaxiDriver", new { id = res2.Id });
                }
                else
                {
                    return RedirectToAction("Profile", "CCustomer", new { id = res2.Id });
                }
            }
            else
            {
                return RedirectToAction("Profile", "AutoMechanic", new { id = Userid });
            }
        }


    }
}
