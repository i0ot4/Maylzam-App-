using Maylzam_App_.Model;
using Maylzam_App_.Repository.IRepository;
using Maylzam_App_.Result;
using Microsoft.AspNetCore.Mvc;

namespace Maylzam_App_.Controllers
{
    [ApiController] // لكي يتم التعرف على ان هذا الكلاس من نوع ايه بي اي
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository repository;

        public CustomerController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customer = await repository.GetAll(x => x.IsDelete == false);
                return Ok(Result<List<Customer>>.Sucess((List<Customer>)customer));
            }
            catch(Exception ex)
            {
                return BadRequest(Result<List<Customer>>.Fail(ex.Message));
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
                return BadRequest(Result<List<Customer>>.Fail(ex.Message));
            }

        }

        [HttpPost("Add")]
        public async Task<Customer> Add(Customer entity)
        {
                entity.IsDelete = false;
                await repository.Add(entity);
                await repository.SaveChanges();
                return entity;
            
        }

        [HttpPost("Update")]
        public async Task<Customer> Update(Customer entity)
        {
            var respo = await repository.GetById(entity.Id);
            if(respo != null)
            {
                respo.Name = entity.Name;
                respo.Email = entity.Email;
                respo.Phone = entity.Phone;
                respo.Password = entity.Password;
                respo.Profile_Image = entity.Profile_Image;
                respo.Created_At = entity.Created_At;
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
        public async Task<Customer> Remove(int id)
        {
            var respo = await repository.GetById(id);
            if(respo != null)
            {
                respo.IsDelete = true;
                repository.Update(respo);
                await repository.SaveChanges();
            }
            return respo;
        }

    }
}
