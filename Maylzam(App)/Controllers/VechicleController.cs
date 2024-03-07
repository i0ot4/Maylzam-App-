using Maylzam_App_.Model;
using Maylzam_App_.Repository.IRepository;
using Maylzam_App_.Result;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_App_.Controllers
{

    [ApiController] // لكي يتم التعرف على ان هذا الكلاس من نوع ايه بي اي
    [Route("[controller]")]
    public class VechicleController : Controller
    {
        private readonly IVechicleRepository repository;

        public VechicleController(IVechicleRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var allTaxi = await repository.GetAll(x => x.IsDelete == false);
                return Ok(Result<List<Vechicle>>.Sucess((List<Vechicle>)allTaxi));
            }
            catch (Exception ex)
            {
                return Ok(Result<List<Vechicle>>.Fail(ex.Message));
            }
        }



        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {

                var allTaxi = await repository.GetById(id);
                return Ok(allTaxi);
            }
            catch (Exception ex)
            {
                return Ok(Result<List<Vechicle>>.Fail(ex.Message));
            }
        }

        [HttpPost("Add")]
        public async Task<Vechicle> Add(Vechicle entity)
        {
            entity.IsDelete = false;
            await repository.Add(entity);
            await repository.SaveChanges();
            return entity;

        }

        [HttpPost("Update")]

        public async Task<Vechicle> Update(Vechicle entity)
        {
            var respo = await repository.GetById(entity.Id);

            if (respo != null)
            {
                respo.DriverId = entity.Id;
                respo.VNumber = entity.VNumber;
                respo.Type = entity.Type;
                respo.Model = entity.Model;
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
        public async Task<Vechicle> Remove(int id)
        {
            var respo = await repository.GetById(id);
            if (null != respo)
            {
                respo.IsDelete = true;
                repository.Remove(respo);
                await repository.SaveChanges();
            }
            return respo;
        }
    }
}
