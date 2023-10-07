using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.core.Interfaces;
using Repository_Pattern.core.Models;

namespace ResopositryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositiryController : ControllerBase
    {
        private readonly Irepositiry<Author> Author_Repo;
        public RepositiryController(Irepositiry<Author> repo)
        {
            Author_Repo = repo;
        }
        [HttpGet]
        public IActionResult Get() {
            return Ok(Author_Repo.GetValue(1));
        }
    }
}
