using Maylzam_App_.Model;
using Maylzam_App_.Repository.IRepository;
using Maylzam_App_.Result;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_App_.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TripController : Controller
    {
        private readonly ITripRepository repository;

        public TripController(ITripRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await repository.GetAll(x => x.IsDelete == false);
                return Ok(Result<List<Trip>>.Sucess((List<Trip>)result));
            }catch(Exception ex)
            {
                return Ok(Result<List<Trip>>.Fail(ex.Message));
            }
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var respo = await repository.GetById(id);
                return Ok(respo);
            }
            catch(Exception ex)
            {
                return Ok(Result<List<Trip>>.Fail(ex.Message));

            }
        }
        [HttpPost("Add")]
        public async Task<Trip> Add(Trip entity)
        {
            entity.IsDelete = false;
            await repository.Add(entity);
            await repository.SaveChanges();
            return entity;
        }

        [HttpPost("Update")]
        public async Task<Trip> Updata(Trip entity)
        {
            var respo = await repository.GetById(entity.Id);
            if (respo != null)
            {
                respo.PaymentId = entity.PaymentId;
                respo.CurrentLocation = entity.CurrentLocation;
                respo.EndLocation = entity.EndLocation;
                respo.Payment = entity.Payment;
                respo.Description = entity.Description;
                respo.Updated_At = entity.Updated_At;
                respo.IsDelete = entity.IsDelete;
                respo.IsActive = entity.IsActive;
                var temp = repository.UpdateAndReturn(respo);
                await repository.SaveChanges();
                return temp.Entity;
            }
            return respo;
        }

        [HttpPost("Remove")]
        public async Task<Trip> Remove(int id)
        {
            var respo = await repository.GetById(id);
            if (respo != null)
            {
                respo.IsDelete = true;
                repository.Remove(respo);
                await repository.SaveChanges();
            }
            return respo;
        }
    }
}
