using Maylzam_App_.Model;
using Maylzam_App_.Repository.IRepository;
using Maylzam_App_.Result;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_App_.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository repository;

        public PaymentController(IPaymentRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("GetAll")]
        public async  Task<IActionResult> GetAll()
        {
            try
            {
                var respo = await repository.GetAll(x => x.IsDelete == false);
                return Ok(Result<List<Payment>>.Sucess((List<Payment>)respo));
            }catch(Exception ex)
            {
                return Ok(Result<List<Payment>>.Fail(ex.Message));
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var respo = await repository.GetById(id);
                return Ok(respo);
            }catch(Exception ex)
            {
                return Ok(Result<List<Payment>>.Fail(ex.Message));
            }
        }

        [HttpPost("Add")]
        public async Task<Payment> Add(Payment entity)
        {
            entity.IsDelete = false;
            await repository.Add(entity);
            await repository.SaveChanges();
            return entity;
        }

        [HttpPost("Updata")]
        public async Task<Payment> Updata(Payment entity)
        {
            var respo = await repository.GetById(entity.Id);
            if (respo != null)
            {
                respo.Method = entity.Method;
                respo.Amount = entity.Amount;
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
        public async Task<Payment> Remove(int id)
        {
            var respo = await repository.GetById(id);
            if(respo != null)
            {
                respo.IsDelete = true;
                repository.Remove(respo);
                await repository.SaveChanges();
            }
            return respo;
        }
    }
}
