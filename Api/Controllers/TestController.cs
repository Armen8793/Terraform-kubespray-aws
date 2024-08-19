using ApiMicroservice.DataMap.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace ApiMicroservice.Controllers
{
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        [Route("/test")]
       public string? TestMessage()
        {
            CountriesDBContext db = new();
            return  db.Superheroes.FirstOrDefault()!.Align!;
        }
    }
}
