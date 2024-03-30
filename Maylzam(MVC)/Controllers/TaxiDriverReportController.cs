using Maylzam_MVC_.Models;
using Maylzam_MVC_.Repository.IRepository;
using Maylzam_MVC_.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_MVC_.Controllers
{
    public class TaxiDriverReportController : Controller
    {

        private readonly ITaxiDriverReportRepository reportRepository;
        private readonly ITaxiDriverAcceptedTripRepository AcceptedTripRepository;
        readonly private ITaxiDriverTripRepository triprepository;
        readonly private ICustomerRepository customerrepository;

        public TaxiDriverReportController(ITaxiDriverReportRepository reportRepository, ITaxiDriverTripRepository triprepository, ICustomerRepository customerrepository, ITaxiDriverAcceptedTripRepository acceptedTripRepository)
        {
            this.reportRepository = reportRepository;
            this.triprepository = triprepository;
            this.customerrepository = customerrepository;
            AcceptedTripRepository = acceptedTripRepository;
        }


        public async Task<IActionResult> Index()
        {
            var res = await reportRepository.GetAll(x => x.IsDelete == false);

            return View(res);
        }




        [HttpGet]
        public IActionResult Add(int id, int driverid)
        {
            return View(new TaxiDriverReportVM { Id = id, DriverId = driverid });


        }
        [HttpPost]
        public async Task<IActionResult> Add(TaxiDriverReportVM entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            if(entity.DriverId == 0) {
                var res = await triprepository.GetById(entity.Id);
                entity.Report.CustomerId = res.CustomerId;
                var res2 = await customerrepository.GetById(res.CustomerId);
                entity.Report.Author = res2.WorkingIn;
                entity.Report.TripId = entity.Id;
                entity.Report.Id = 0;
                entity.Report.Status = "UnderReview";
                entity.Report.Created_At = DateTime.Now;
                entity.Report.IsDelete = false;
                entity.Report.IsActive = true;

                await reportRepository.Add(entity.Report);

                await reportRepository.SaveChanges();

                if (res2.WorkingIn == "TrafficPolice")
                {
                    return RedirectToAction("Profile", "TrafficPolice", new { id = res2.Id });
                }
                else if (res2.WorkingIn == "AutoMechanic")
                {
                    return RedirectToAction("Profile", "AutoMechanic", new { id = entity.Report.CustomerId });
                }
                else
                {
                    return RedirectToAction("Profile", "CCustomer", new { id = res2.Id });
                }
            }
            else
            {
                var res = await AcceptedTripRepository.GetById(entity.Id);
                res.Status = "failed";
                AcceptedTripRepository.Update(res);
                await AcceptedTripRepository.SaveChanges();
                entity.Report.DriverId = res.DriverId;
                entity.Report.TripId = res.TripId;
                entity.Report.Author = "TaxiDriver";
                entity.Report.Id = 0;
                entity.Report.Status = "UnderReview";
                entity.Report.Created_At = DateTime.Now;
                entity.Report.IsDelete = false;
                entity.Report.IsActive = true;

                await reportRepository.Add(entity.Report);

                await reportRepository.SaveChanges();

                return RedirectToAction("Profile", "TaxiDriver", new { id = res.DriverId });
                
            }

            

        }


        [HttpGet]
        public async Task<IActionResult> Reviewed(int id, int Userid)
        {
            var res = await reportRepository.GetById(id);
            res.Status = "Reviewed";
            reportRepository.Update(res);
            await reportRepository.SaveChanges();

            if (Userid != 0)
            {

                var res2 = await customerrepository.GetById(Userid);
                if (res2.WorkingIn == "TrafficPolice")
                {
                    return RedirectToAction("Profile", "TrafficPolice", new { id = res2.Id });
                }
                else if (res2.WorkingIn == "AutoMechanic")
                {
                    return RedirectToAction("Profile", "AutoMechanic", new { id = res2.Id });
                }
                else
                {
                    return RedirectToAction("Profile", "CCustomer", new { id = res2.Id });
                }
            }
            else
            {
                return RedirectToAction("Profile", "TaxiDriver", new { id = res.DriverId });
            }


        }

        [HttpGet]
        public async Task<IActionResult> UnderReview(int id, int Userid)
        {
            var res = await reportRepository.GetById(id);
            res.Status = "UnderReview";
            reportRepository.Update(res);
            await reportRepository.SaveChanges();
            if (Userid != 0)
            {

                var res2 = await customerrepository.GetById(Userid);
                if (res2.WorkingIn == "TrafficPolice")
                {
                    return RedirectToAction("Profile", "TrafficPolice", new { id = res2.Id });
                }
                else if (res2.WorkingIn == "AutoMechanic")
                {
                    return RedirectToAction("Profile", "AutoMechanic", new { id = res2.Id });
                }
                else
                {
                    return RedirectToAction("Profile", "CCustomer", new { id = res2.Id });
                }
            }
            else
            {
                return RedirectToAction("Profile", "TaxiDriver", new { id = res.DriverId });
            }

          }   



        }


    }

        

    

