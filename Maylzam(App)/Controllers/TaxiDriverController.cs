using Maylzam_App_.Model;
using Maylzam_App_.Repository.IRepository;
using Maylzam_App_.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maylzam_App_.Controllers

// هو عباره عن كلاس من نوع 
// controller
//يحتوي هذا الكلاس على دوال أيه بي اي التي سوف يتم ربطها بالتطبيق للوصول الى قواعد البيانات وعمل الاضافه والتعديل والحذف والعرض عن طريقها

{
    [ApiController] // لكي يتم التعرف على ان هذا الكلاس من نوع ايه بي اي
    [Route("[controller]")]
    public class TaxiDriverController : Controller
    {
        private readonly ITaxiDriverRepository repository;
        
        

        public TaxiDriverController(ITaxiDriverRepository repository)
        {
            
            this.repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var allTaxi = await repository.GetAll(x => x.IsDelete == false);
                return Ok(Result<List<TaxiDriver>>.Sucess((List<TaxiDriver>)allTaxi));
            }
            catch(Exception ex)
            {
                return Ok(Result<List<TaxiDriver>>.Fail(ex.Message));
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
            catch(Exception ex)
            {
                return Ok(Result<List<TaxiDriver>>.Fail(ex.Message));
            }
        }

        [HttpPost("Add")]
        public async Task<TaxiDriver> Add(TaxiDriver taxi)
        {
            taxi.IsDelete = false;
            await repository.Add(taxi);
            await repository.SaveChanges();
                return taxi;
           
        }

        [HttpPost("Update")]
      
        public async Task<TaxiDriver> Update(TaxiDriver entity)
        {
            var respo = await repository.GetById(entity.Id);
           
            if(respo != null)
            {
                respo.Name = entity.Name;
                respo.Email = entity.Email;
                respo.Password = entity.Password;
                respo.Phone = entity.Phone;
                respo.Driver_License = entity.Driver_License;
                respo.Personal_Card = entity.Personal_Card;
                respo.Profile_Image = entity.Profile_Image;
                respo.IsDelete = entity.IsDelete;
                respo.Updated_At = entity.Updated_At;
                respo.IsActive=entity.IsActive;
                var temp = repository.UpdateAndReturn(respo);

               await repository.SaveChanges();
                return temp.Entity;
            }
            return respo;
        }
        


        [HttpPost("Remove")]
        public async Task<TaxiDriver> Remove(int id)
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
