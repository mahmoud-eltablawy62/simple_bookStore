using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.core;
using Repository_Pattern.core.consts;
using Repository_Pattern.core.Models;

namespace ResopositryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        public BookController(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(UnitOfWork.Books.GetValue(1));
        }

        [HttpGet ("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(UnitOfWork.Books.GetAll());
        }

        [HttpGet("GetByName")]
        public IActionResult Getbyname()
        {
            return Ok(UnitOfWork.Books.Find(B => B.Tittle == "ummelsarasir" , new[] { "Authors" } ));
        }

        [HttpGet ("GetAllByName")]
        public IActionResult GetAllByName()
        {
            return Ok(UnitOfWork.Books.FindAll(B => B.Tittle == "ummelsarasir" , new[] { "Authors" } ));
        }
        [HttpGet("GetbyOrder")]
        public IActionResult GetOrder()
        {
            return Ok(UnitOfWork.Books.findAll(B => B.Tittle == "ummelsarasir", null, null, b => b.Id,OrderBy.Descending)); 
        }
        [HttpPost("AddOne")]
        public IActionResult Addone()
        {
            var book = UnitOfWork.Books.Add(new Book { Tittle="mahmoud/saied" , Auth_Id = 1 });
            UnitOfWork.Complete();
            return Ok(book);    
        }
    }
}
