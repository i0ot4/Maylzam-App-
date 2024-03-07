using Maylzam_App_.Model;
using Maylzam_App_.Repository.IRepository;
using Maylzam_App_.Result;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_App_.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AcceptedTripController : Controller
    {
        private readonly IAcceptedTripRepository repository;

        public AcceptedTripController(IAcceptedTripRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await repository.GetAll(x => x.IsDelete == false);
                return Ok(Result<List<AcceptedTrip>>.Sucess((List<AcceptedTrip>)result));
            }
            catch (Exception ex)
            {
                return Ok(Result<List<AcceptedTrip>>.Fail(ex.Message));
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
            catch (Exception ex)
            {
                return Ok(Result<List<AcceptedTrip>>.Fail(ex.Message));

            }
        }
        [HttpPost("Add")]
        public async Task<AcceptedTrip> Add(AcceptedTrip entity)
        {
            entity.IsDelete = false;
            await repository.Add(entity);
            await repository.SaveChanges();
            return entity;
        }

        [HttpPost("Updata")]
        public async Task<AcceptedTrip> Updata(AcceptedTrip entity)
        {
            var respo = await repository.GetById(entity.Id);
            if (respo != null)
            {
                respo.Status = entity.Status;
                respo.Completed_At = entity.Completed_At;
                respo.IsActive = entity.IsActive;
                respo.IsDelete = entity.IsDelete;
                var temp = repository.UpdateAndReturn(respo);
                await repository.SaveChanges();
                return temp.Entity;
            }
            return respo;
        }

        [HttpPost("Remove")]
        public async Task<AcceptedTrip> Remove(int id)
        {
            var respo = await repository.GetById(id);
            if (respo != null)
            {
                respo.IsDelete=true;
                repository.Update(respo);
                await repository.SaveChanges();
            }
            return respo;
        }

    }
}
