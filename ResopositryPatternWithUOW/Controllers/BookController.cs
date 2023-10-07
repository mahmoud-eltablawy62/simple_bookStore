using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.core.Interfaces;
using Repository_Pattern.core.Models;

namespace ResopositryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly Irepositiry<Book> Book_Repo;
        public BookController(Irepositiry<Book> repo)
        {
            Book_Repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Book_Repo.GetValue(1));
        }
    }
}
