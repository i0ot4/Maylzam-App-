using Maylzam_App_.Model;
using Maylzam_App_.Repository.IRepository;
using Maylzam_App_.Result;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_App_.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
    public class ReportController : Controller
    {
        private readonly IReportRepository repository;

        public ReportController(IReportRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await repository.GetAll(x => x.IsDelete == false);
                return Ok(Result<List<Report>>.Sucess((List<Report>)result));
            }
            catch (Exception ex)
            {
                return Ok(Result<List<Report>>.Fail(ex.Message));
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
                return Ok(Result<List<Report>>.Fail(ex.Message));

            }
        }
        [HttpPost("Add")]
        public async Task<Report> Add(Report entity)
        {
            entity.IsDelete = false;
            await repository.Add(entity);
            await repository.SaveChanges();
            return entity;
        }

        [HttpPost("Updata")]
        public async Task<Report> Updata(Report entity)
        {
            var respo = await repository.GetById(entity.Id);
            if (respo != null)
            {
                respo.Type = entity.Type;
                respo.Description = entity.Description;
                respo.Status = entity.Status;
                respo.Updated_At = entity.Updated_At;
                respo.IsActive = entity.IsActive;
                respo.IsDelete = entity.IsDelete;
                var temp = repository.UpdateAndReturn(respo);
                await repository.SaveChanges();
                return temp.Entity;
            }
            return respo;
        }

        [HttpPost("Remove")]
        public async Task<Report> Remove(int id)
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
