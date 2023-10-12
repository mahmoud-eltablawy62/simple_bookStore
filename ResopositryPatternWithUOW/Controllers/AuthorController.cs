
using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.core;


namespace ResopositryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        public AuthorController(IUnitOfWork _UnitOfWork)
        {
           UnitOfWork = _UnitOfWork;    
        }
        [HttpGet]
        public IActionResult Get() {
            return Ok(UnitOfWork.Authors.GetValue(1));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll () { 
             return Ok(UnitOfWork.Authors.GetAll());   
        }
      
    }
}
